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
    public partial class NewUserPage : ContentPage
    {
        public NewUserPage()
        {
            InitializeComponent();
        }

        
        // create new users in the database
        private void SignUpButton_Clicked(object sender, EventArgs e)
        {

        }

        // Button used to goto sign in page
        [Obsolete]
        private async void SignInButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OAuthNativeFlowPage());
        }
    }
}