using System;
using System.Globalization;

namespace Custom.RTL.DependencyServices
{
    public interface ILocale
    {
        CultureInfo GetCurrentCultureInfo();

        void SetLocale(CultureInfo ci);
    }
}
