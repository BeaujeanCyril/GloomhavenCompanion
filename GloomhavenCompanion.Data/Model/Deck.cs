using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GloomhavenCompanion.Data.Model;

public class Deck
{

  [NotMapped]
  public List<Card> CardsHistoric { get; set; } = [];
  [Key]
  public int Id { get; set; }
  public string Name { get; set; }
  public List<Card> CardsList { get; set; } = [];
  public bool IsShowingBackCard { get; set; } // Pour savoir si on montre le dos de la carte
  public bool IsShuffled { get; set; } = false;


  public Deck()
  {
    InitializeDeckCards(); // Appeler la méthode d'initialisation lors de la création de l'objet
  }

  private void InitializeDeckCards()
  {
    var imageNumbers = Enumerable.Range(1, 20).ToList(); // Générez une liste de 1 à 20

    foreach (var number in imageNumbers)
    {
      bool NeedShuffle = false;
      var imagePath = $@"/img/DeckModifier/Monsters/gh-am-m-{number:D2}.png"; // Format 2 chiffres
      if (number == 19 || number == 20)
      {
        NeedShuffle = true;
      }
      this.CardsList.Add(new Card
      {
        Value = $"Card {number}", // La valeur peut être personnalisée selon tes besoins
        ImagePath = imagePath, // Chemin dynamique de l'image
        NeedShuffle = NeedShuffle
      });
    }
  }


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
    var annulCard = new Card
    {
      Id = GenerateUniqueId(),
      Value = "Annulé",
      NeedShuffle = false,
      ImagePath = $@"\img\DeckModifier\Monsters\gh-am-mm-01.png",
      IsTemporary = true,
    };

    CardsList.Add(annulCard);
    ShuffleDeck();
  }

  // Méthode pour ajouter une carte "X2" dans le deck
  public void AddX2Card()
  {
    var x2Card = new Card
    {
      Id = GenerateUniqueId(),
      Value = "x2",
      NeedShuffle = false,
      ImagePath = $@"\img\DeckModifier\Monsters\BenedictionCard.png",
      IsTemporary = true,
    };

    CardsList.Add(x2Card);
    ShuffleDeck();
  }

  // Méthode pour afficher la première carte et la déplacer à la fin du deck
  public string ShowAndMoveFirstCardToEnd()
  {
    if (CardsList.Count == 0)
      return "Le deck est vide.";

    // Récupérer la première carte
    var firstCard = CardsList.First();
    CardsHistoric.Add(firstCard);
    // Retirer la carte du début et l'ajouter à la fin
    CardsList.RemoveAt(0);
    if (!firstCard.IsTemporary)
    {
      CardsList.Add(firstCard);
    }
    // Retourner la valeur de la carte pour affichage
    return firstCard.Value;
  }
}
