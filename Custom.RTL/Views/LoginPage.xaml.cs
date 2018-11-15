using System;
using System.Collections.Generic;
using Custom.RTL.ViewModel.Login;
using Xamarin.Forms;

namespace Custom.RTL.Views
{
    public partial class LoginPage : ContentPage
    {
        private readonly LoginPageViewModel _viewModel;
        public LoginPage()
        {
            InitializeComponent();
            _viewModel = new LoginPageViewModel()
            {
                VisualElement = this
            };
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
