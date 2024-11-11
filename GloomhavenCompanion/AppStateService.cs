namespace GloomhavenCompanion;

using GloomhavenCompanion.Application.ViewModels;
using System.Threading.Tasks;

public class AppStateService
{
	private readonly IAppStateStorage _appStateStorage;

	public AppStateService(IAppStateStorage appStateStorage)
	{
		_appStateStorage = appStateStorage;
	}

	// Sauvegarder les équipes dans le stockage
	public async Task SaveTeamsAsync(List<CampaignViewModel> teams)
	{
		await _appStateStorage.SaveCampaignsAsync(teams);
	}

	// Charger les équipes depuis le stockage
	public async Task<List<CampaignViewModel>> LoadTeamsAsync()
	{
		return await _appStateStorage.LoadCampaignsAsync();
	}
}