using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Collections.Generic;

namespace Debut_Xamarin
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            LinearLayout mainLayout = FindViewById<LinearLayout>(Resource.Id.mainLayout);

            Button btn1Act1 = FindViewById<Button>(Resource.Id.btn1Act1);
            btn1Act1.Click += OnButtonClick;

            Button myButton = new Button(this)
            {
                Text = "mon boutton"

            };

            myButton.Click += OnButtonClick2;
            mainLayout.AddView(myButton);

        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            TextView myText = FindViewById<TextView>(Resource.Id.myText);
            if (myText.Visibility == ViewStates.Visible)
            {
                myText.Visibility = ViewStates.Invisible;
            }
            else
            {
                myText.Visibility = ViewStates.Visible;
            }
        }
        private void OnButtonClick2(object sender, System.EventArgs e)
        {
            var secondaryActivity = new Intent(this, typeof(SecondActivity));
            secondaryActivity.PutExtra("Data", "Some data from MainActivity");
            secondaryActivity.PutExtra("Age", 30);
            secondaryActivity.PutStringArrayListExtra("Names",
            new List<string> { "Jerôme", "Michel", "Paul" });
            StartActivity(secondaryActivity);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}