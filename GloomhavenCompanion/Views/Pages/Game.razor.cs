namespace GloomhavenCompanion.Views.Pages
{
  public partial class Game
  {   private void NextRound()
    {
      AppState.NextRound();
      ReduceAllElements();
    }
    private string GetStateDescription(int state)
    {
      return state switch
      {
        0 => "Inerte",
        1 => "Faible",
        2 => "Fort",
        _ => "Inconnu" // Par sécurité, si jamais l'état est en dehors des limites
      };
    }
    private void SetElementStrong(int id)
    {
      var element = AppState.Elements.FirstOrDefault(e => e.Id == id);
      if (element != null)
      {
        if (element.State == 0 || element.State == 1)
        {
          element.State = 2; // Fort
        }
      }
    }
    private void UseElement(int id)
    {
      var element = AppState.Elements.FirstOrDefault(e => e.Id == id);
      if (element != null)
      {
        if (element.State == 2) element.State = 0; // Faible
        else if (element.State == 1) element.State = 0; // Inerte
      }
    }

    public void ReduceAllElements()
    {
      foreach (var element in AppState.Elements)
      {
        if (element.State == 2) element.State = 1; // Diminue de 2 à 1
        else if (element.State == 1) element.State = 0; // Diminue de 1 à 0
      }
    }

    private string GetStateColor(int state)
    {
      return state switch
      {
        0 => "gray", // Couleur par défaut pour "Inerte"
        1 => "orange", // Couleur pour "Faible"
        2 => "red", // Couleur pour "Fort"
        _ => "gray" // Par défaut si état inconnu
      };
    }
  }
}