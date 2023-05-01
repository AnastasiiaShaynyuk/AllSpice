using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllSpice.Repositories;

public class FavoritesRepository
{
  private readonly IDbConnection _db;

  public FavoritesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal List<MyFavorites> GetMyFavoriteRecipes(string userId)
  {
    string sql = @"
    SELECT
    fav.*,
    rec.*,
    creator.*
    FROM favorites fav
    JOIN recipes rec ON fav.recipeId = rec.id
    JOIN accounts creator ON rec.creatorId = creator.id
    WHERE fav.accountId = @userId
    ;";
    List<MyFavorites> recipes = _db.Query<Favorite, MyFavorites, Profile, MyFavorites>(sql, (myFavorites, recipes, creator) =>
    {
      recipes.FavoriteId = myFavorites.Id;
      recipes.Creator = creator;
      return recipes;
    }, new { userId }).ToList();
    return recipes;
  }

  internal Favorite GetOne(int id)
  {
    string sql = "SELECT * FROM favorites WHERE id = @id;";
    Favorite favorite = _db.Query<Favorite>(sql, new { id }).FirstOrDefault();
    return favorite;
  }

  internal Favorite MakeFavorite(Favorite favorData)
  {
    string sql = @"
    INSERT INTO
    favorites(recipeId, accountId)
    VALUES (@RecipeId, @AccountId);
    SELECT LAST_INSERT_ID()
    ;";
    int id = _db.ExecuteScalar<int>(sql, favorData);
    favorData.Id = id;
    return favorData;
    }

  internal void RemoveFavorite(int id)
  {
    string sql = "DELETE FROM favorites WHERE id = @id;";
    _db.Execute(sql, new { id });
  }
}


