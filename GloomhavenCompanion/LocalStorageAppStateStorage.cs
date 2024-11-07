﻿namespace GloomhavenCompanion;

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

	public async Task SaveCampaignsAsync(List<CampainViewModel> teams)
	{
		var serializedTeams = JsonSerializer.Serialize(teams);
		await _localStorageService.SetItemAsync("Teams", serializedTeams);
	}

	public async Task<List<CampainViewModel>> LoadCampaignsAsync()
	{
		var savedTeamsJson = await _localStorageService.GetItemAsync<string>("Teams");
		if (string.IsNullOrEmpty(savedTeamsJson))
		{
			return new List<CampainViewModel>(); // Retourne une liste vide si aucun état n'est trouvé
		}

		return JsonSerializer.Deserialize<List<CampainViewModel>>(savedTeamsJson);
	}
}