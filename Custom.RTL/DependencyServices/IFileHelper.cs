using System;
namespace Custom.RTL.DependencyServices
{
    public interface IFileHelper
    {
        bool? IsPreferredLanguageArabic();

        void SaveUserLanguagePreference(bool status);
    }
}
