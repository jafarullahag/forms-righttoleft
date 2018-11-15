using System;
using System.Globalization;
using System.Threading;
using Custom.RTL.DependencyServices;
using Custom.RTL.Droid.DependencyServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(Locale))]
namespace Custom.RTL.Droid.DependencyServices
{
    public class Locale : ILocale
    {
        public void SetLocale(CultureInfo ci)
        {
            //Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

        public CultureInfo GetCurrentCultureInfo()
        {
            var netLanguage = "en";
            var androidLocale = Java.Util.Locale.Default;
            netLanguage = androidLocale.ToString().Replace("_", "-");

            // this gets called a lot - try/catch can be expensive so consider caching or something
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
    }
}
