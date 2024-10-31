namespace GloomhavenCompanion.Data.Model;
public class Player
{
	public string Name { get; set; }
	public int Coins { get; set; } = 0;
	public int Xp { get; set; } = 0;
	public Deck Deck { get; set; }
}