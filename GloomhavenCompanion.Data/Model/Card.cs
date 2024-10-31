namespace GloomhavenCompanion.Data.Model;
public class Card
{
  public int Id { get; set; }
  public string Value { get; set; }
  public string ImagePath { get; set; }
  public bool NeedShuffle { get; set; } = false;
}