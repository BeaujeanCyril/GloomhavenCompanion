namespace GloomhavenCompanion;

using Blazored.LocalStorage;
using GloomhavenCompanion.ViewModels;
using System.Text.Json;

public class LocalStorageAppStateStorage : IAppStateStorage
{
	private readonly ILocalStorageService _localStorageService;

	public LocalStorageAppStateStorage(ILocalStorageService localStorageService)
	{
		_localStorageService = localStorageService;
	}

	public async Task SaveCampaignsAsync(List<CampainViewModel> campaigns)
	{
		var serializedTeams = JsonSerializer.Serialize(campaigns);
		await _localStorageService.SetItemAsync("Campaigns", serializedTeams);
	}

	public async Task<List<CampainViewModel>> LoadCampaignsAsync()
	{
		var savedCampaignsJson = await _localStorageService.GetItemAsync<string>("Campaigns");
		if (string.IsNullOrEmpty(savedCampaignsJson))
		{
			return new List<CampainViewModel>(); // Retourne une liste vide si aucun état n'est trouvé
		}

		return JsonSerializer.Deserialize<List<CampainViewModel>>(savedCampaignsJson);
	}
}