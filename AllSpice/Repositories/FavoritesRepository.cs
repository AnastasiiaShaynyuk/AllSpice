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
    rec.*,
    fav.*,
    creator.*
    FROM favorites fav
    JOIN recipes rec ON fav.recipeId = rec.id
    JOIN accounts creator ON rec.creatorId = creator.id
    WHERE fav.accountId = @userId
    ;";
    List<MyFavorites> myFavorites = _db.Query<MyFavorites, Favorite, Profile, MyFavorites>(sql, (myFavorites, recipes, creator) =>
    {
      
      myFavorites.FavoriteId = recipes.Id;
      myFavorites.Creator = creator;
      return myFavorites;
    }, new { userId }).ToList();
    return myFavorites;
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
  }


