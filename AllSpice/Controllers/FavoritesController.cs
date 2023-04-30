using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AllSpice.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class FavoritesController : ControllerBase
{
  private readonly FavoritesService _favoritesService;
  private readonly Auth0Provider _auth;

  public FavoritesController(FavoritesService favoritesService, Auth0Provider auth)
  {
    _favoritesService = favoritesService;
    _auth = auth;
  }


  [HttpPost]
  public async Task<ActionResult<Favorite>> MakeFavorite([FromBody] Favorite favorData)
  {
    try {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      favorData.AccountId = userInfo.Id;
      Favorite favorite = _favoritesService.MakeFavorite(favorData);
      return Ok(favorite);
    }
    catch (Exception e)
    {
    return BadRequest(e.Message);
    }
  }
}
