namespace GloomhavenCompanion.ViewModels
{
  public class PlayerViewModel
  {
    public string Name { get; set; }
    public int Coins { get; set; } = 0;
    public int Xp { get; set; } = 0;
    public DeckViewModel Deck { get; set; } = new DeckViewModel();
  }
}