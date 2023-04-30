using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllSpice.Services;

public class IngredientsService
{
  private readonly IngredientsRepository _repo;

  public IngredientsService(IngredientsRepository repo)
  {
    _repo = repo;
  }

  internal Ingredient CreateIngredient(Ingredient ingredientData)
  {
    Ingredient ingredient = _repo.CreateIngredient(ingredientData);
    return ingredient;
  }

  internal List<Ingredient> GetIngredientsByRecipe(int recipeId)
  {
    List<Ingredient> ingredients = _repo.GetIngredientsByRecipe(recipeId);
    return ingredients;
  }


  internal Ingredient GetOne(int ingredientId)
  {
    Ingredient ingredient = _repo.GetOne(ingredientId);
    if (ingredient == null) throw new Exception($"There is no ingredient with this ID {ingredientId}");
    return ingredient;
  }

  internal string RemoveIngredient(int ingredientId, string userId)
  {
    Ingredient ingredient = GetOne(ingredientId);
    if (ingredient.CreatorId != userId) throw new Exception("It is not your ingredient");
    _repo.RemoveIngredient(ingredientId);
    return "Deleted ingredient!";
  }
}
