﻿using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Hardware.Lights;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Java.Lang;
using Java.Util;
using System;
using System.Collections.Generic;

namespace X_335_ThomasRey_Projet
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        ListView listDone;
        ListView listToDo;
        LinearLayout nav;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //Menu
            LinearLayout layoutBlur = (LinearLayout)FindViewById(Resource.Id.layoutblur);
            Button menu = (Button)FindViewById(Resource.Id.btnMenu);
            nav = (LinearLayout)FindViewById(Resource.Id.layoutNav);
            layoutBlur.Click += DisplayNav_Click;
            menu.Click += DisplayNav_Click;

            //List
            listToDo = (ListView)FindViewById(Resource.Id.listToDo);
            Button clickToDo = (Button)FindViewById(Resource.Id.btnClickToDo);
            clickToDo.Click += DisplayTask_Click;
            listDone = (ListView)FindViewById(Resource.Id.listDone);
            Button clickDone = (Button)FindViewById(Resource.Id.btnClickDone);
            clickDone.Click += DisplayTask_Click;

            //Adapter
            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.planets_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            listToDo.Adapter = adapter;
            listDone.Adapter = adapter;
            listToDo.Visibility = ViewStates.Gone;
            listDone.Visibility = ViewStates.Gone;


            Button addTask = (Button)FindViewById(Resource.Id.btnNewTask);
            addTask.Click += NewTask_Click;

            Button myTask = (Button)FindViewById(Resource.Id.btnTask);
            myTask.Click += MyTask_Click;

            Button newCategory = (Button)FindViewById(Resource.Id.btnAddCategory);
            newCategory.Click += NewCategory_Click;
        }

        /// <summary>
        /// show content of the spinner
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            string toast = string.Format("The planet is {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestCode"></param>
        /// <param name="permissions"></param>
        /// <param name="grantResults"></param>
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        /// <summary>
        /// Display the navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayNav_Click(object sender, EventArgs e)
        {
            nav.Visibility = nav.Visibility == ViewStates.Visible ? ViewStates.Gone : ViewStates.Visible;
        }

        /// <summary>
        /// Display the daily task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayTask_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button.Rotation == 0)
            {
                button.Rotation -= 90;
            }
            else
            {
                button.Rotation += 90;
            }
            if (button == (Button)FindViewById(Resource.Id.btnClickToDo))
            {
                listToDo.Visibility = listToDo.Visibility == ViewStates.Visible ? ViewStates.Gone : ViewStates.Visible;
            }
            else
            {
                listDone.Visibility = listDone.Visibility == ViewStates.Visible ? ViewStates.Gone :  ViewStates.Visible;
            }
        }

        // <summary>
        /// Show the add task activity
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewTask_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(AddTaskActivity));
        }

        /// <summary>
        /// Show the my task activity
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyTask_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MyTaskActivity));
        }

        /// <summary>
        /// Show the new task activity
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewCategory_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(CategoryActivity));
        }
    }
}