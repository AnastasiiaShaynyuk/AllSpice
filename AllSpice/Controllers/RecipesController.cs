using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AllSpice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
  private readonly RecipesService _recipesService;

  public RecipesController(RecipesService recipesService)
  {
    _recipesService = recipesService;
  }

  [HttpGet]
  public ActionResult<List<Recipe>> GetAllRecipes()
  {
    try {
      List<Recipe> recipes = _recipesService.GetAllRecipes();
      return Ok(recipes);
    }
    catch (Exception e)
    {
    return BadRequest(e.Message);
    }
  }

  [HttpGet("{recipeId}")]
  public ActionResult<Recipe> GetOne(int recipeId)
  {
    try {
      Recipe recipe = _recipesService.GetOne(recipeId);
      return Ok(recipe);
    }
    catch (Exception e)
    {
    return BadRequest(e.Message);
    }
  }
}
