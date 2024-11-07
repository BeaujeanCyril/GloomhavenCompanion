namespace GloomhavenCompanion;

public class AppStateInitializer
{
  private readonly AppState _appState;

  public AppStateInitializer(AppState appState)
  {
    _appState = appState;
  }

  // Méthode d'initialisation de l'état, à appeler au lancement de l'application
  public async Task InitializeAsync()
  {
    // Charge les équipes à partir du stockage local
    await _appState.LoadCampaignsAsync();
    _appState.CurrentCampaign = _appState.Campaigns.FirstOrDefault();
  }
}
