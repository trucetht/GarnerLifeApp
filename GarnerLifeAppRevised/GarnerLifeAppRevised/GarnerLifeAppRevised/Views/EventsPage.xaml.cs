using GarnerLifeAppRevised.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GarnerLifeAppRevised.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventsPage : ContentPage
    {
        void Handle_Navigated(object sender, Xamarin.Forms.WebNavigatedEventArgs e)
        {
            LoadingLabel.IsVisible = false;
        }

        void Handle_Navigating(object sender, Xamarin.Forms.WebNavigatingEventArgs e)
        {
            LoadingLabel.IsVisible = true;
        }
        void Back_Clicked(object sender, System.EventArgs e)
        {
            if (Browser.CanGoBack)
                Browser.GoBack();
        }

        public EventsPage()
        {
            InitializeComponent();
            var browser = new WebView();
            browser.Source = "http://app.garnerlife.com/events?isApp=1";
            Content = browser;
            
            //ListEvents();
        }
        

        public void ListEvents()
        {
            EventsDAL dal = new EventsDAL();

            //lvEvent.ItemsSource = dal.GetAllEvents();
        }

       
        
    }
}