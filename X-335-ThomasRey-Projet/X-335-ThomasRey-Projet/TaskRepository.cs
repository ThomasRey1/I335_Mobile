using Android.App;
using Android.Content;
using Android.Database.Sqlite;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace X_335_ThomasRey_Projet
{
    public class TaskRepository
    {
        // propriété qui correspond à l’implémentation SQLite spécifique à la plateforme.
        private SQLiteAsyncConnection _connection;

        // méthode d’initialisation prenant en paramètre le chemin vers la base de
        // données et l’implémentation SQLite spécifique.
        public TaskRepository(string dbPath) { 
            _connection = new SQLiteAsyncConnection(dbPath);

            _connection.CreateTableAsync<Task>();
        }

        public void GetTask(int idTask)
        {

        }

        public void GetTasks(int id)
        {

        }

        public void GetDailyTasksToDo()
        {

        }

        public void GetDailyTasksDone()
        {

        }

        public void GetCategoryTasksToDo(int idCategory)
        {

        }

        public void GetCategoryTasksDone(int idCategory)
        {

        }

        public void AddTask()
        {

        }

        public void ModifyTask(int idTask)
        {

        }
    }
}