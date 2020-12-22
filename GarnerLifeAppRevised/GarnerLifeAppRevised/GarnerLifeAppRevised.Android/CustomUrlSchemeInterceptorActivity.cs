using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GarnerLifeAppRevised.AuthHelpers;

namespace GarnerLifeAppRevised.Droid
{
	[Activity(Label = "CustomUrlSchemeInterceptorActivity", NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
	[IntentFilter(
		new[] { Intent.ActionView },
		Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
		DataSchemes = new[] { "com.googleusercontent.apps.600467985308-ea7a16to0deb73tr6nr3313etg84jnv9" },
		DataPath = "/oauth2redirect")]
	public class CustomUrlSchemeInterceptorActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Convert Android.Net.Url to Uri
			var uri = new Uri(Intent.Data.ToString());

			// Load redirectUrl page
			AuthenticationState.Authenticator.OnPageLoading(uri);
			var intent = new Intent(this, typeof(MainActivity));
			intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.SingleTop);
			StartActivity(intent);

			this.Finish();

			return;
		}
	}
}