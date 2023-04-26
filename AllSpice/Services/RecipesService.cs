using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllSpice.Services;

public class RecipesService
{
  private readonly RecipesRepositories _repo;

  public RecipesService(RecipesRepositories repo)
  {
    _repo = repo;
  }

  internal List<Recipe> GetAllRecipes()
  {
    List<Recipe> recipes = _repo.GetAllRecipes();
    return recipes;
  }
}
