using System.Timers;

namespace GloomhavenCompanion.Views.Pages;
public partial class Game
{

  private bool showPopup = false;
  private bool showTimerPopup = false; // Contrôle l'affichage du pop-up après 5 minutes
  private System.Timers.Timer roundTimer;

  protected override void OnInitialized()
  {
    // Initialisation du timer pour 5 minutes (300 000 millisecondes)
    roundTimer = new System.Timers.Timer(300000);
    roundTimer.Elapsed += OnTimerElapsed;
    roundTimer.AutoReset = false; // Le timer se déclenche une seule fois après 5 minutes
  }


	private void TogglePopup()
	{
		showPopup = !showPopup;
	}
	private void NextRound()
    {
        AppState.NextRound();
        ReduceAllElements();
    // Redémarre le timer de 5 minutes
    showTimerPopup = false;
    roundTimer.Stop();
    roundTimer.Start();
  }

  private void OnTimerElapsed(object sender, ElapsedEventArgs e)
  {
    // Affiche le pop-up une fois que les 5 minutes sont écoulées
    showTimerPopup = true;
    InvokeAsync(StateHasChanged); // Met à jour l'UI pour afficher le pop-up
  }

  private void CloseTimerPopup()
  {
    showTimerPopup = false;
  }
  private void SetElementStrong(int id)
    {
        var element = AppState.Elements.FirstOrDefault(e => e.Id == id);
        if (element != null && (element.State == 0 || element.State == 1))
        {
            element.State = 2; // Fort
        }
    }

    private void UseElement(int id)
    {
        var element = AppState.Elements.FirstOrDefault(e => e.Id == id);
        if (element != null)
        {
            element.State = element.State == 2 ? 0 : (element.State == 1 ? 0 : element.State);
        }
    }

    private void ReduceAllElements()
    {
        foreach (var element in AppState.Elements)
        {
            element.State = element.State == 2 ? 1 : (element.State == 1 ? 0 : element.State);
        }
    }
}