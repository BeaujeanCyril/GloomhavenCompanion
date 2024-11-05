
using Microsoft.AspNetCore.Http;
using System;


namespace GloomhavenCompanion.Services
{

	public class CookieService
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public CookieService(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		// Méthode pour écrire un cookie
		public void SetCookie(string key, string value, int? expireTime = null)
		{
			var cookieOptions = new CookieOptions
			{
				IsEssential = true, // Nécessaire pour GDPR
				Expires = expireTime.HasValue ? DateTime.Now.AddMinutes(expireTime.Value) : DateTime.Now.AddDays(7)
			};
			_httpContextAccessor.HttpContext?.Response.Cookies.Append(key, value, cookieOptions);
		}

		// Méthode pour lire un cookie
		public string GetCookie(string key)
		{
			if (_httpContextAccessor.HttpContext?.Request.Cookies.TryGetValue(key, out var value) == true)
			{
				return value;
			}
			return null; // ou une valeur par défaut si nécessaire
		}


		// Méthode pour supprimer un cookie
		public void RemoveCookie(string key)
		{
			_httpContextAccessor.HttpContext?.Response.Cookies.Delete(key);
		}
	}
}
