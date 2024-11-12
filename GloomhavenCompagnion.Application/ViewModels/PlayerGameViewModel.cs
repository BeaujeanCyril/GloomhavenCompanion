namespace GloomhavenCompanion.Application.ViewModels
{
	public class PlayerGameViewModel
	{
		// Ajoutez un constructeur sans paramètre pour la désérialisation
		public PlayerGameViewModel()
		{
			Effects = new List<EffectViewModel>();
		}

		// Vous pouvez garder votre constructeur existant pour l'utilisation du constructeur avec PlayerViewModel
		public PlayerGameViewModel(PlayerViewModel globalPlayer)
		{
			Name = globalPlayer.Name;
			HealthPoints = globalPlayer.HealthPointsMax;
			HealthPointsMax = globalPlayer.HealthPointsMax;
			Coins = 0;
			Xp = 0;
			Deck = globalPlayer.Deck;
			Effects = new List<EffectViewModel>(globalPlayer.Effects);
		}

public int Id { get; set; }
		public string Name { get; set; }
		public int HealthPoints { get; set; }
		public int HealthPointsMax { get; set; }  // Changer en propriété en lecture-écriture si vous avez besoin de la désérialiser

		public int Coins { get; set; } = 0;
		public int Xp { get; set; } = 0;
		public DeckViewModel Deck { get; set; }
		public List<EffectViewModel> Effects { get; set; }
	}
}
