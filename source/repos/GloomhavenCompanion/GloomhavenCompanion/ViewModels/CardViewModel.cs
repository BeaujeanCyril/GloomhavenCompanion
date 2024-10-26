namespace GloomhavenCompanion.Model
{
  public class CardViewModel
  {
    public int Id { get; set; }
    public string Value { get; set; }
    public bool IsUsed { get; set; } = false;
    public bool NeedShuffle { get; set; } = false;
  }
}