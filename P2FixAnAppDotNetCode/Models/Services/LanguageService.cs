using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;

namespace P2FixAnAppDotNetCode.Models.Services
{
    
    public class LanguageService : ILanguageService
    {
        
        public void ChangeUiLanguage(HttpContext context, string language)
        {
            string culture = SetCulture(language);
            UpdateCultureCookie(context, culture);
        }

        public string SetCulture(string language)
        {
            string culture = "";
            
            switch (language)
            {
                case "French":
                    culture = "fr-FR"; 
                    break;
                case "Spanish":
                    culture = "es";
                    break;
                case "Wolof":
                    culture = "wo-SN"; 
                    break;
                default:
                    culture = "en";
                    break;
            }
            return culture;
        }

        public void UpdateCultureCookie(HttpContext context, string culture)
        {
            string uiCulture = culture; 
            
            string cultureDeFormatage; 
            
            if (culture == "wo-SN")
            {
                cultureDeFormatage = "fr-FR"; 
            }
            else if (culture.StartsWith("fr")) 
            {
                cultureDeFormatage = "fr-FR";
            }
            else
            {
                cultureDeFormatage = culture;
            }

            context.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(cultureDeFormatage, uiCulture)));        }
    }
}