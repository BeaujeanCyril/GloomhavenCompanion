namespace GloomhavenCompanion;

using GloomhavenCompanion.ViewModels;
using System.Threading.Tasks;

public class AppStateService
{
	private readonly IAppStateStorage _appStateStorage;

	public AppStateService(IAppStateStorage appStateStorage)
	{
		_appStateStorage = appStateStorage;
	}

	// Sauvegarder les équipes dans le stockage
	public async Task SaveTeamsAsync(List<TeamViewModel> teams)
	{
		await _appStateStorage.SaveTeamsAsync(teams);
	}

	// Charger les équipes depuis le stockage
	public async Task<List<TeamViewModel>> LoadTeamsAsync()
	{
		return await _appStateStorage.LoadTeamsAsync();
	}
}