using System.ComponentModel.DataAnnotations;

namespace GloomhavenCompanion.Data.Model;
public class Effect
{
[Key] 
public int Id { get; set; }
  public string Name { get; set; }
  public string Description { get; set; } = string.Empty;
  public string ImagePath { get; set; }
}
