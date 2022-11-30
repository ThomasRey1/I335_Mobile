using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace X_335_ThomasRey_Projet
{
    public class TaskAdapter : BaseAdapter<TaskDB>
    {
        // Variable
        List<TaskDB> tasks;
        Activity activity;

        /// <summary>
        /// Contructor: charge l'activité et la liste des tâche
        /// </summary>
        /// <param name="tasks"></param>
        /// <param name="activity"></param>
        public TaskAdapter(List<TaskDB> tasks, Activity activity) : base()
        {
            this.tasks = tasks;
            this.activity = activity;

        }

        /// <summary>
        /// retourne l'id d'une tâche
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public override long GetItemId(int position)
        {
            return position;
        }

        /// <summary>
        /// retourne une tâche
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public override TaskDB this[int position]{
            get { return tasks[position]; }
        }

        /// <summary>
        /// retourne le nombre de tâche
        /// </summary>
        public override int Count
        {
            get { return tasks.Count; }
        }

        /// <summary>
        /// retourne une tâche
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public override Java.Lang.Object GetItem(int position)
        {
            // Pour l'instant retourn rien
            return "";
        }

        /// <summary>
        /// Modele de rendu des données
        /// </summary>
        /// <param name="position"></param>
        /// <param name="convertView"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var currentTask = tasks[position];

            View view = activity.LayoutInflater.Inflate(Resource.Layout.activity_modelTask, null);

            view.FindViewById<TextView>(Resource.Id.textViewModel1).Text = currentTask.Name;
            view.FindViewById<Button>(Resource.Id.buttonModel1).Text = currentTask.Description;

            return view;
        }
    }

}