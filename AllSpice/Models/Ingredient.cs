namespace AllSpice.Models;

public class Ingredient : RepoItem<int>
{
  public string Name { get; set; }
  public string Quantity { get; set; }
  public int RecipeId { get; set; }
  public string CreatorId { get; set; }
  public Profile Creator { get; set; }
}