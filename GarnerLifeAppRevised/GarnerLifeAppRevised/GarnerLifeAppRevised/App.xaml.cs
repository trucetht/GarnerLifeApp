using GarnerLifeAppRevised.Views;
using Plugin.PushNotification;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GarnerLifeAppRevised
{
    public partial class App : Application
    {
        readonly MainPage mPage;

        [Obsolete]
        public App()
        {
            InitializeComponent();
            mPage = new MainPage()
            {
                Message = "Hello Push Notifications!"
            };
            MainPage = new NavigationPage( new OAuthNativeFlowPage());
        }

        protected override void OnStart()
        {
            SetMessageText($"{mPage.Message} TOKEN REC: {CrossPushNotification.Current.Token}");

            // Handle when your app starts
            CrossPushNotification.Current.OnTokenRefresh += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine($"TOKEN REC: {p.Token}");
                SetMessageText($"TOKEN REC: {p.Token}");
            };

            CrossPushNotification.Current.OnNotificationReceived += (s, p) =>
            {
                try
                {
                    System.Diagnostics.Debug.WriteLine("Received");
                    if (p.Data.ContainsKey("body"))
                    {
                        SetMessageText($"{p.Data["body"]}");
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            };

            CrossPushNotification.Current.OnNotificationOpened += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine("Opened");
                foreach (var data in p.Data)
                {
                    System.Diagnostics.Debug.WriteLine($"{data.Key} : {data.Value}");
                }

                if (!string.IsNullOrEmpty(p.Identifier))
                {
                    SetMessageText(p.Identifier);
                }
                else if (p.Data.ContainsKey("color"))
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        mPage.Navigation.PushAsync(new ContentPage()
                        {
                            BackgroundColor = Color.FromHex($"{p.Data["color"]}")
                        });
                    });
                }
                else if (p.Data.ContainsKey("aps.alert.title"))
                {
                    SetMessageText($"{p.Data["aps.alert.title"]}");
                }
            };
            CrossPushNotification.Current.OnNotificationDeleted += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine("Dismissed");
            };
        }

        private void SetMessageText(string text)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                mPage.Message = text;
            });
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
