using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllSpice.Repositories;

public class RecipesRepositories
{
  private readonly IDbConnection _db;

  public RecipesRepositories(IDbConnection db)
  {
    _db = db;
  }

  internal Recipe CreateRecipe(Recipe recipeData)
  {
    string sql = @"
    INSERT INTO recipes
    (title, instructions, img, category, creatorId)
    VALUES
    (@Title, @Instructions, @Img, @Category, @CreatorId);

    SELECT LAST_INSERT_ID()
    ;";


    int id = _db.ExecuteScalar<int>(sql, recipeData);

    recipeData.Id = id;
    recipeData.CreatedAt = DateTime.Now;
    recipeData.UpdatedAt = DateTime.Now;
    return recipeData;

  }

  internal void EditRecipe(Recipe originalRecipe)
  {
    string sql = @"
    UPDATE recipes
    SET
    title = @Title,
    instructions = @Instructions,
    img = @Img,
    category = @Category

    WHERE id = @Id
    ;";

    _db.Execute(sql, originalRecipe);
  }

  internal List<Recipe> GetAllRecipes()
  {
    string sql = @"
    SELECT
    rec.*,
    creator.*
    FROM recipes rec
    JOIN accounts creator ON creator.id = rec.creatorId
    ;";
    List<Recipe> recipes = _db.Query<Recipe, Profile, Recipe>(sql, (recipe, creator) =>
    {
      recipe.Creator = creator;
      return recipe;
    }).ToList();
    return recipes;
  }

  internal Recipe GetOne(int recipeId)
  {
    string sql = @"
    SELECT
    rec.*,
    creator.*
    FROM recipes rec
    JOIN accounts creator ON creator.id = rec.creatorId
    WHERE rec.id = @recipeId
    ;";
    Recipe recipe = _db.Query<Recipe, Profile, Recipe>(sql, (recipe, creator) =>
    {
      recipe.Creator = creator;
      return recipe;
    }, new { recipeId }).FirstOrDefault();
    return recipe;
  }

  internal void RemoveRecipe(int recipeId)
  {
    string sql = "DELETE FROM recipes WHERE id = @recipeId;";
    _db.Execute(sql, new { recipeId });
  }
}
