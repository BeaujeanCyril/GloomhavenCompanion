namespace GloomhavenCompanion.API.Model
{
  public class Card
  {
    public int Id { get; set; }
    public string Value { get; set; }
    public bool IsUsed { get; set; } = false;
    public bool NeedShuffle { get; set; } = false;
  }
}