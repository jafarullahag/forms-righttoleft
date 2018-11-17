using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custom.RTL.ViewModel;
using Xamarin.Forms;

namespace Custom.RTL
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel _viewModel;
        public MainPage()
        {
            InitializeComponent();
            _viewModel = new MainPageViewModel()
            {
                VisualElement = this
            };
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
