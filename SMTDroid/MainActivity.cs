﻿using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace SMTDroid
{
	[Activity (Label = "SMT", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{

			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Set error message to not visible by default
			TextView errorMsg = FindViewById<TextView>(Resource.Id.txtErrorMessage);
			errorMsg.Visibility = ViewStates.Invisible;
		
			// Get username and password
			TextView username = FindViewById<TextView> (Resource.Id.txtUsername);
			TextView password = FindViewById<TextView> (Resource.Id.txtPassword);

			// Handle login
			Button btLogin = FindViewById<Button> (Resource.Id.btLogin);
			btLogin.Click += delegate {
				appConfig config = new appConfig();
				var _service = new SMTWebsevice.SMT(config.SMTWebserviceURL);
				// Validate if strings not empty to submit
				int userId = (username.Text != string.Empty && password.Text != string.Empty) ? _service.login(username.Text, password.Text) : -1;
				if (userId != -1) {
					// Hide error message
					errorMsg.Visibility = ViewStates.Invisible;
					// Move to next page
					var intent = new Intent(this, typeof(Menu));
					intent.PutExtra("user_id", Convert.ToString(userId)); // From this point on is string
					StartActivity(intent);
				}
				else
				{
					// Display error message
					errorMsg.Visibility = ViewStates.Visible;
				}
			};

		}
	}
}


