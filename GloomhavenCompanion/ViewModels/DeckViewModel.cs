namespace GloomhavenCompanion.ViewModels
{
	public class DeckViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<CardViewModel> CardsList { get; set; } = [];

		public void ShuffleDeck()
		{
			Random rng = new();
			int n = CardsList.Count;

			// Algorithme de Fisher-Yates pour mélanger le deck
			for (int i = n - 1; i > 0; i--)
			{
				int j = rng.Next(0, i + 1);
				// Échanger les cartes à l'index i et j
				var temp = CardsList[i];
				CardsList[i] = CardsList[j];
				CardsList[j] = temp;
			}
		}

		// Méthode privée pour générer un ID unique
		private int GenerateUniqueId()
		{
			return CardsList.Any() ? CardsList.Max(c => c.Id) + 1 : 1;
		}

		// Méthode pour ajouter une carte "Annulé" dans le deck
		public void AddAnnulCard()
		{
			var annulCard = new CardViewModel
			{
				Id = GenerateUniqueId(),
				Value = "Annulé",
				NeedShuffle = true
			};

			CardsList.Add(annulCard);
		}

		// Méthode pour ajouter une carte "X2" dans le deck
		public void AddX2Card()
		{
			var x2Card = new CardViewModel
			{
				Id = GenerateUniqueId(),
				Value = "X2",
				NeedShuffle = true
			};

			CardsList.Add(x2Card);
		}

		// Méthode pour afficher la première carte et la déplacer à la fin du deck
		public string ShowAndMoveFirstCardToEnd()
		{
			if (CardsList.Count == 0)
				return "Le deck est vide.";

			// Récupérer la première carte
			var firstCard = CardsList.First();

			// Retirer la carte du début et l'ajouter à la fin
			CardsList.RemoveAt(0);
			CardsList.Add(firstCard);

			// Retourner la valeur de la carte pour affichage
			return firstCard.Value;
		}
	}


}
