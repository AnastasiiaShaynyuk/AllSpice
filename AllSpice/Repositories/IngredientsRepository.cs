using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllSpice.Repositories;

public class IngredientsRepository
{
  private readonly IDbConnection _db;

  public IngredientsRepository(IDbConnection db)
  {
    _db = db;
  }
  internal Ingredient CreateIngredient(Ingredient ingredientData)
  {
    string sql = @"
    INSERT INTO ingredients
    (name, quantity, recipeId, creatorId)
    VALUES
    (@Name, @Quantity, @RecipeId, @CreatorId);

    SELECT
    ing.*,
    creator.*
    FROM ingredients ing
    JOIN accounts creator ON ing.creatorId = creator.id
    WHERE ing.id = LAST_INSERT_ID()
    ;";

    Ingredient ingredient = _db.Query<Ingredient, Profile, Ingredient>(sql, (ingredient, creator) => {
      ingredient.Creator = creator;
      return ingredient;
    }, ingredientData).FirstOrDefault();
    ingredientData.CreatedAt = DateTime.Now;
    ingredientData.UpdatedAt = DateTime.Now;
    return ingredient;
  }

  internal List<Ingredient> GetIngredientsByRecipe(int recipeId)
  {
    string sql = @"
    SELECT
    ing.*,
    creator.*
    FROM ingredients ing
    JOIN accounts creator ON ing.creatorId = creator.id
    WHERE ing.recipeId = @recipeId
    ;";
    List<Ingredient> ingredients = _db.Query<Ingredient, Profile, Ingredient>(sql, (ingredient, creator) =>
    {
      ingredient.Creator = creator;
      return ingredient;
    }, new { recipeId }).ToList();
    return ingredients;
  }

  internal Ingredient GetOne(int ingredientId)
  {
string sql = "SELECT * FROM ingredients WHERE id = @ingredientId;";
    Ingredient ingredient = _db.Query<Ingredient>(sql, new { ingredientId }).FirstOrDefault();
    return ingredient;  }

  internal void RemoveIngredient(int ingredientId)
  {
    string sql = "DELETE FROM ingredients WHERE id = @ingredientId;";
    _db.Execute(sql, new { ingredientId });
  }
}
