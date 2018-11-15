using System;
using Custom.RTL.Common;
using Custom.RTL.DependencyServices;
using Custom.RTL.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Custom.RTL.Common.GlobalEnum;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Custom.RTL
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            SetLanguage();
            MainPage = new LoginPage();
        }

        private static void SetLanguage()
        {
            bool? isArabic = DependencyService.Get<IFileHelper>().IsPreferredLanguageArabic();

            if (isArabic.HasValue)
            {
                if (isArabic.Value)
                {
                    CommonHelper.ChangeLanguage(LanguageShortCode.ar);

                }
                else
                {
                    CommonHelper.ChangeLanguage(LanguageShortCode.en);
                }
            }
            else
            {
                //Set application culture by default based on device culture
                var phoneCulture = DependencyService.Get<ILocale>().GetCurrentCultureInfo();
                CommonHelper.UpdateLangauge(phoneCulture);
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
