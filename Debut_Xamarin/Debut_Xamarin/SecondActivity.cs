using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Debut_Xamarin
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class SecondActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.second_activity);

            LinearLayout mainLayout = FindViewById<LinearLayout>(Resource.Id.mainLayout);

            var dataTextView = FindViewById<TextView>(Resource.Id.textView1);
            string data = Intent.GetStringExtra("Data");
            if (!string.IsNullOrEmpty(data))
            {
                dataTextView.Text = data;
            }

            Button myButton2 = new Button(this)
            {
                Text = "mon boutton"

            };

            myButton2.Click += OnButtonClick;
            mainLayout.AddView(myButton2);
        }

        public void OnButtonClick(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }
    }
}