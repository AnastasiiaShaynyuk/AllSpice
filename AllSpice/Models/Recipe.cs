namespace AllSpice.Models;

public class Recipe : RepoItem<int>
{
  // public int Id { get; set; }
  public string Title { get; set; }
  public string Instruction { get; set; }
  public string Img { get; set; }
  public string Category { get; set; }
  public string CreatorId { get; set; }
  public Profile Creator { get; set; }

}