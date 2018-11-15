using System;
using System.Diagnostics;
using System.Globalization;
using Custom.RTL.DependencyServices;
using Custom.RTL.Resx.Lang;
using Xamarin.Forms;
using static Custom.RTL.Common.GlobalEnum;

namespace Custom.RTL.Common
{
    public static class CommonHelper
    {
        public static void ErrorLog(Exception exception)
        {
            Debug.WriteLine(exception);
        }

        public static void ChangeLanguage(LanguageShortCode languageShortCode)
        {
            var culture = CultureInfo.CreateSpecificCulture(languageShortCode.ToString());
            UpdateLangauge(culture);
        }

        public static void UpdateLangauge(CultureInfo culture)
        {
            DependencyService.Get<ILocale>().SetLocale(culture);
            Strings.Culture = culture; //For .net Resources to work
            Application.Current.Properties["Lang"] = culture.TwoLetterISOLanguageName;// ci.Name.Substring(0, ci.Name.IndexOf("-"));
            LangResourceLoader.Instance.SetCultureInfo(culture); //for our use 
        }
    }
}
