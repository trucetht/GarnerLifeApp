using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GarnerLifeAppRevised.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            var browser = new WebView();
            browser.Source = "https://app.garnerlife.com/?isApp=1";
            Content = browser;
        }
        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            //return false;

            return true;
        }
    }
}