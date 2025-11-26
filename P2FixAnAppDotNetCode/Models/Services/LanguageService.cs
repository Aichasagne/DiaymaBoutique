using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;

namespace P2FixAnAppDotNetCode.Models.Services
{
    /// <summary>
    /// Provides services method to manage the application language
    /// </summary>
    public class LanguageService : ILanguageService
    {
        /// <summary>
        /// Set the UI language
        /// </summary>
        public void ChangeUiLanguage(HttpContext context, string language)
        {
            string culture = SetCulture(language);
            UpdateCultureCookie(context, culture);
        }

        /// <summary>
        /// Set the culture (maps the string name from the UI to the culture code)
        /// </summary>
        public string SetCulture(string language)
        {
            string culture = "";
            
            // Mappe le nom de la langue à un code de culture (wo-SN pour la précision)
            switch (language)
            {
                case "French":
                    // Utilise fr-FR pour une meilleure cohérence avec la configuration Startup
                    culture = "fr-FR"; 
                    break;
                case "Spanish":
                    culture = "es";
                    break;
                case "Wolof":
                    // Utilise wo-SN pour correspondre au nom des fichiers .wo-SN.resx
                    culture = "wo-SN"; 
                    break;
                default:
                    culture = "en";
                    break;
            }
            return culture;
        }

        /// <summary>
        /// Update the culture cookie (implements UI/Formatting separation)
        /// </summary>
        public void UpdateCultureCookie(HttpContext context, string culture)
        {
            // La culture que nous avons obtenue de SetCulture (ex: "wo-SN")
            string uiCulture = culture; 
            
            // La culture qui sera utilisée pour formater les nombres et les dates (ex: "fr-FR")
            string cultureDeFormatage; 
            
            // EXIGENCE CLÉ : Si la langue d'affichage est le Wolof, le formatage DOIT rester Français
            if (culture == "wo-SN")
            {
                // Force la culture de formatage au français du Sénégal/France pour les nombres
                cultureDeFormatage = "fr-FR"; 
            }
            // Maintient la culture de formatage en fr-FR pour la sélection "French"
            else if (culture.StartsWith("fr")) 
            {
                cultureDeFormatage = "fr-FR";
            }
            else
            {
                // Pour les autres langues (English, Spanish), la culture de formatage suit l'UI
                cultureDeFormatage = culture;
            }

            // Crée le cookie en utilisant RequestCulture(Culture, UICulture)
            // (premier param = culture de formatage, second = culture UI)
            context.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(cultureDeFormatage, uiCulture)));        }
    }
}