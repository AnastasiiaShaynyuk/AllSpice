using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllSpice.Services;

public class FavoritesService
{
  private readonly FavoritesRepository _repo;
  public FavoritesService(FavoritesRepository repo)
  {
    _repo = repo;
  }

  internal List<MyFavorites> GetMyFavoriteRecipes(string userId)
  {
    List<MyFavorites> myFavorites = _repo.GetMyFavoriteRecipes(userId);
    return myFavorites;
  }

  internal Favorite MakeFavorite(Favorite favorData)
  {
    Favorite favorite = _repo.MakeFavorite(favorData);
    return favorite;
  }
}