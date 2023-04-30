

namespace AllSpice.Services;

public class RecipesService
{
  private readonly RecipesRepositories _repo;
  private readonly IngredientsService _ingredientsService;

  public RecipesService(RecipesRepositories repo, IngredientsService ingredientsService)
  {
    _repo = repo;
    _ingredientsService = ingredientsService;
  }

  internal Recipe CreateRecipe(Recipe recipeData)
  {
    Recipe recipe = _repo.CreateRecipe(recipeData);
    return recipe;
  }

  internal Recipe EditRecipe(Recipe recipeData, int recipeId)
  {
    Recipe originalRecipe = this.GetOne(recipeId);

    if (originalRecipe.CreatorId != recipeData.CreatorId) throw new Exception("This is not your recipe!");

    originalRecipe.Title = recipeData.Title ?? originalRecipe.Title;
    originalRecipe.Instructions = recipeData.Instructions ?? originalRecipe.Instructions;
    originalRecipe.Category = recipeData.Category ?? originalRecipe.Category;
    originalRecipe.Img = recipeData.Img ?? originalRecipe.Img;

    _repo.EditRecipe(originalRecipe);
    originalRecipe.UpdatedAt = DateTime.Now;
    return originalRecipe;
  }

  internal List<Recipe> GetAllRecipes()
  {
    List<Recipe> recipes = _repo.GetAllRecipes();
    return recipes;
  }

  internal List<Ingredient> GetIngredientsByRecipe(int recipeId)
  {
    Recipe recipe = GetOne(recipeId);
    if (recipe == null) throw new Exception($"There is no recipe with this ID {recipeId}");
    List<Ingredient> ingredients = _ingredientsService.GetIngredientsByRecipe(recipeId);
    return ingredients;
  }

  internal Recipe GetOne(int recipeId)
  {
Recipe recipe = _repo.GetOne(recipeId);
if (recipe == null) throw new Exception($"There is no recipe with this ID {recipeId}");
return recipe;
  }

  internal string RemoveRecipe(int recipeId, string userId)
  {
    Recipe recipe = GetOne(recipeId);
    
    if (recipe.CreatorId != userId) throw new Exception("It is not your recipe");

    _repo.RemoveRecipe(recipeId);

    return "Recipe was deleted";
  }
}
