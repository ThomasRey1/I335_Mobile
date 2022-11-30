using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace X_335_ThomasRey_Projet
{
    [Activity(Label = "AddTaskActivity")]
    public class AddTaskActivity : Activity
    {
        private string _dbPath = System.IO.Path.Combine(FileSystem.AppDataDirectory, "MaDB.db3");
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_task);
            // Create your application here
            // Set our view from the "main" layout resource
            
            
            //Spinner
            Spinner spinnerCategory = (Spinner)FindViewById(Resource.Id.spinnerCategory);
            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.planets_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerCategory.Adapter = adapter;

            //spinnerCategory.ItemSelected += Spinner_ItemSelected;

            //back to the menu button
            Button btnBack = (Button)FindViewById(Resource.Id.btnback);

            btnBack.Click += BackToMenu;

            //back to the menu button with new task
            Button btnAddTask = (Button)FindViewById(Resource.Id.btnAddTask);

            btnAddTask.Click += BackToMenu;

            // Instanciation du repository
            TaskRepository taskRepository = new TaskRepository(_dbPath);
            _ = taskRepository.AddNewTaskAsync("ma tâche", "ma description");
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
        /// Show the add task activity
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackToMenu(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }
        
        /// <summary>
        /// Show the main activity
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddTaskMenu(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }
    }
}