namespace AllSpice.Services;

public class RecipesService
{
  private readonly RecipesRepositories _repo;

  public RecipesService(RecipesRepositories repo)
  {
    _repo = repo;
  }

  internal Recipe CreateRecipe(Recipe recipeData)
  {
    Recipe recipe = _repo.CreateRecipe(recipeData);
    return recipe;
  }

  internal List<Recipe> GetAllRecipes()
  {
    List<Recipe> recipes = _repo.GetAllRecipes();
    return recipes;
  }

  internal Recipe GetOne(int recipeId)
  {
Recipe recipe = _repo.GetOne(recipeId);
if (recipe == null) throw new Exception($"There is no recipe with this ID {recipeId}");
return recipe;
  }
}
