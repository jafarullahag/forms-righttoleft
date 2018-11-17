using System;
using System.Threading.Tasks;
using Custom.RTL.Common;
using Custom.RTL.DependencyServices;
using Custom.RTL.ViewModel.Base;
using Custom.RTL.Views;
using Xamarin.Forms;
using static Custom.RTL.Common.GlobalEnum;

namespace Custom.RTL.ViewModel.Login
{
    public class LoginPageViewModel : BaseViewModel
    {
        public LoginPageViewModel()
        {
        }

        bool IsRememberMe { get; set; }

        string rememberMeImage = "Checkbox";
        public string RememberMeImage
        {
            get { return rememberMeImage; }
            set { rememberMeImage = value; OnPropertyChanged(); }
        }

        Command rememberMeCommand;
        public Command RememberMeCommand
        {
            get
            {
                return rememberMeCommand ?? (rememberMeCommand = new Command(ExecuteOnRemeberMe));
            }
        }

        Command changeLanguageCommand;
        public Command ChangeLanguageCommand
        {
            get
            {
                return changeLanguageCommand ?? (changeLanguageCommand = new Command(() => ExecuteOnLanguageChange()));
            }
        }

        Command userLoginCommand;
        public Command UserLoginCommand
        {
            get
            {
                return userLoginCommand ?? (userLoginCommand = new Command(() => ExecuteLogin()));
            }
        }

        void ExecuteOnRemeberMe()
        {
            IsRememberMe = !IsRememberMe;
            ApplyImageForButton();
        }
        void ApplyImageForButton()
        {
            RememberMeImage = IsRememberMe ? "CheckboxSelected" : "Checkbox";
        }

        private  void ExecuteOnLanguageChange()
        {
            bool isArabic = false;
            if (Language.CurrentLanguageAbbr == LanguageCode.Arabic)
                CommonHelper.ChangeLanguage(LanguageShortCode.en);
            else
            {
                CommonHelper.ChangeLanguage(LanguageShortCode.ar);
                isArabic = true;
            }
            DependencyService.Get<IFileHelper>().SaveUserLanguagePreference(isArabic);
        }

        private void ExecuteLogin()
        {
            Page.Navigation.PushAsync(new MainPage());
        }
    }
}
