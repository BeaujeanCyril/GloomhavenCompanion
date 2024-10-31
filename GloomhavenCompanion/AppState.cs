using GloomhavenCompanion.ViewModels;
namespace GloomhavenCompanion;

public class AppState
{
  public List<ElementViewModel> Elements { get; private set; }
  public int Round { get; private set; }
  public List<TeamViewModel> Teams { get; private set; }
  public List<DeckViewModel> Decks { get; set; } = [];
  public DeckViewModel MonsterDeck { get; set; }
  public PlayerViewModel CurrentPlayer { get; set; } 


  public AppState()
  {
    Round = 1;
    Teams = [];
    GenerateElements();


    CreateDeck("MonsterDeck");
    CurrentPlayer = new PlayerViewModel() { Name = "Monster", Deck = MonsterDeck };
  }

  #region Element
  private void GenerateElements()
  {
    Elements =
        [
            new() { Id = 1, Name = "Feu", ImagePath = "img/Elements/FirePicture.png" },
            new() { Id = 2, Name = "Ténèbre", ImagePath = "img/Elements/DarknessPicture.png" },
            new() { Id = 3, Name = "Terre", ImagePath = "img/Elements/EarthPicture.png" },
            new() { Id = 4, Name = "Vent", ImagePath = "img/Elements/WindPicture.png" },
            new() { Id = 5, Name = "Lumière", ImagePath = "img/Elements/LightPicture.png" },
            new() { Id = 6, Name = "Givre", ImagePath = "img/Elements/FrostPicture.png" }
        ];
  }
  #endregion Element

  #region Round
  public void NextRound()
  {
    Round++;
  }
  #endregion Round

  #region Team
  public void AddTeam(TeamViewModel team)
  {
    Teams.Add(team);
  }
  #endregion Team

  #region Deck

  public void CreateDeck(string name)
  {
    MonsterDeck = new DeckViewModel { Id = GenerateDeckId(), Name = name };
    InitializeDeckCards(MonsterDeck);
    Decks.Add(MonsterDeck);
  }

  private void InitializeDeckCards(DeckViewModel deck)
  {
    var imageNumbers = Enumerable.Range(1, 20).ToList(); // Générez une liste de 1 à 20

    foreach (var number in imageNumbers)
    {
      bool NeedShuffle = false;
      var imagePath = $@"\img\DeckModifier\Monsters\gh-am-m-{number:D2}.png"; // Format 2 chiffres
      if(number == 19 || number == 20){
        NeedShuffle = true;
      }
      deck.CardsList.Add(new CardViewModel
      {
        Id = number, // Utilise le numéro comme ID
        Value = $"Card {number}", // La valeur peut être personnalisée selon tes besoins
        ImagePath = imagePath, // Chemin dynamique de l'image
        NeedShuffle = NeedShuffle
      });
    }
  }

  private int GenerateDeckId()
  {
    // Logique pour générer un ID unique pour le deck
    return Decks.Count + 1; // Exemple simple d'ID
  }
  #endregion Deck
}