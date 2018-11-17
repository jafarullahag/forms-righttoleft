using System.Globalization;
using System.Threading;
using Custom.RTL.DependencyServices;
using Custom.RTL.iOS.DependencyServices;
using Foundation;
using Xamarin.Forms;

[assembly: Dependency(typeof(Locale))]
namespace Custom.RTL.iOS.DependencyServices
{
    public class Locale : ILocale
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            var netLanguage = "en";
            if (NSLocale.PreferredLanguages.Length > 0)
                netLanguage = NSLocale.PreferredLanguages[0];// NSLocale.CurrentLocale.LanguageCode;// PreferredLanguages[0];
            System.Globalization.CultureInfo ci = null;
            try
            {
                ci = new System.Globalization.CultureInfo(netLanguage);
            }
            catch (CultureNotFoundException ex)
            {
                ci = new System.Globalization.CultureInfo("en");//default to en
            }

            return ci;
        }

        public void SetLocale(CultureInfo ci)
        {
            Thread.CurrentThread.CurrentUICulture = ci;
        }
    }
}
