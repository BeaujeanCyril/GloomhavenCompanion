using Blazored.LocalStorage;
using Blazored.LocalStorage.StorageOptions;
using GloomhavenCompanion;
using GloomhavenCompanion.Services;
using GloomhavenCompanion.Views;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
		.AddInteractiveServerComponents();
builder.Services.AddMudServices();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<CookieService>();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<IAppStateStorage, LocalStorageAppStateStorage>(); // Pour utiliser localStorage

builder.Services.AddScoped<AppStateService>();
builder.Services.AddScoped<AppStateInitializer>(); // Ajouter l'initialisateur
builder.Services.AddScoped<AppState>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
		.AddInteractiveServerRenderMode();

app.Run();
