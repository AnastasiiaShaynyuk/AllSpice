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

  internal List<Recipe> GetAllRecipes()
  {
    string sql = @"
    SELECT
    rec.*,
    creator.*
    FROM recipes rec
    JOIN accounts creator ON creator.id = rec.creatorId
    ;";
    List<Recipe> recipes = _db.Query<Recipe, Account, Recipe>(sql, (recipe, creator) =>
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
    Recipe recipe = _db.Query<Recipe, Account, Recipe>(sql, (recipe, creator) =>
    {
      recipe.Creator = creator;
      return recipe;
    }, new { recipeId }).FirstOrDefault();
    return recipe;
  }
}
