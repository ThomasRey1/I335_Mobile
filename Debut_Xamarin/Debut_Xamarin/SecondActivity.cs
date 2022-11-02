using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
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

            TextView dataTextView = FindViewById<TextView>(Resource.Id.textView1);
            string data = Intent.GetStringExtra("Data");
            string data2 = Intent.GetStringExtra("Age");
            if (!string.IsNullOrEmpty(data))
            {
                dataTextView.Text = data;
            }
            if (!string.IsNullOrEmpty(data2))
            {
                dataTextView.Text = data;
            }

            Button myButton2 = new Button(this)
            {
                Text = data2,
                Visibility = ViewStates.Invisible,
                Right = 60,
                ScaleX = 20
            };

            myButton2.ScaleY = 15;

            LinearLayout layout = new LinearLayout(this)
            {
                ScaleX = 80,
                ScaleY = 40,
                Enabled = false
            };
            layout.Top = 50;

            myButton2.Click += OnButtonClick;
            mainLayout.AddView(myButton2);
        }

        public void OnButtonClick(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }
    }
}