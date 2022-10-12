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

namespace X_335_ThomasRey_Projet
{
    [Activity(Label = "MyTaskActivity")]
    public class MyTaskActivity : Activity
    {

        LinearLayout nav;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_myTask);

            //Menu
            LinearLayout layoutBlur = (LinearLayout)FindViewById(Resource.Id.layoutblur);
            Button menu = (Button)FindViewById(Resource.Id.btnMenu);
            nav = (LinearLayout)FindViewById(Resource.Id.layoutNav);
            layoutBlur.Click += DisplayNav_Click;
            menu.Click += DisplayNav_Click;

            Button addTask = (Button)FindViewById(Resource.Id.btnNewTask);
            addTask.Click += NewTask_Click;

            Button main = (Button)FindViewById(Resource.Id.btnDaily);
            main.Click += MyDay_Click;

            Button newCategory = (Button)FindViewById(Resource.Id.btnAddCategory);
            newCategory.Click += NewCategory_Click;
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
        /// Show the add task activity
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewTask_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(AddTaskActivity));
        }

        /// <summary>
        /// Show the main activity
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyDay_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
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