namespace GloomhavenCompanion.Model
{
  public class PlayerViewModel
  {
    public string Name { get; set; }
    public int Coins { get; set; } = 0;
    public int Xp { get; set; } = 0;
    public List<CardViewModel> Deck { get; set; } = [];

    // Méthode pour mélanger le deck
    public void ShuffleDeck()
    {
      Random rng = new();
      int n = Deck.Count;

      // Algorithme de Fisher-Yates pour mélanger le deck
      for (int i = n - 1; i > 0; i--)
      {
        int j = rng.Next(0, i + 1);
        // Échanger les cartes à l'index i et j
        var temp = Deck[i];
        Deck[i] = Deck[j];
        Deck[j] = temp;
      }
    }

    // Méthode privée pour générer un ID unique
    private int GenerateUniqueId()
    {
      return Deck.Any() ? Deck.Max(c => c.Id) + 1 : 1;
    }

    // Méthode pour ajouter une carte "Annulé" dans le deck
    public void AddAnnulCard()
    {
      var annulCard = new CardViewModel
      {
        Id = GenerateUniqueId(),
        Value = "Annulé",
        IsUsed = false,
        NeedShuffle = true
      };

      Deck.Add(annulCard);
    }

    // Méthode pour ajouter une carte "X2" dans le deck
    public void AddX2Card()
    {
      var x2Card = new CardViewModel
      {
        Id = GenerateUniqueId(),
        Value = "X2",
        IsUsed = false,
        NeedShuffle = true
      };

      Deck.Add(x2Card);
    }

    // Méthode pour afficher la première carte et la déplacer à la fin du deck
    public string ShowAndMoveFirstCardToEnd()
    {
      if (Deck.Count == 0)
        return "Le deck est vide.";

      // Récupérer la première carte
      var firstCard = Deck.First();

      // Retirer la carte du début et l'ajouter à la fin
      Deck.RemoveAt(0);
      Deck.Add(firstCard);

      // Retourner la valeur de la carte pour affichage
      return firstCard.Value;
    }
  }
}