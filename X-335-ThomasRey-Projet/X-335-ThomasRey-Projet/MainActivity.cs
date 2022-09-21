using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Collections.Generic;

namespace X_335_ThomasRey_Projet
{
    [Activity(Label = "@string/app_name", Theme = "@style/Theme.AppCompat.Light.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var toDoBtn = FindViewById<Button>(Resource.Id.btnToDoDisplay);
            toDoBtn.Click += OnButtonClickDisplay; 
            var doneBtn = FindViewById<Button>(Resource.Id.btnDoneDisplay);
            doneBtn.Click += OnButtonClickDisplay;

            Spinner mySpinner = FindViewById<Spinner>(Resource.Id.spinner1);

            mySpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.planets_array, Android.Resource.Layout.SimpleGalleryItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleGalleryItem);
            mySpinner.Adapter = adapter;
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            string toast = string.Format("The planet is {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void OnButtonClickDisplay(object sender, System.EventArgs e)
        {
            Button button = sender as Button;

            if(button.Rotation == 0)
            {
                button.Rotation -= 90;
            }
            else
            {
                button.Rotation += 90;
            }
        }
    }
}