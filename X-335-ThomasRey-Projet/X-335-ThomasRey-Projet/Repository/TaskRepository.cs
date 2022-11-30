﻿using Android.App;
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
using System.Threading.Tasks;
using Java.Sql;

namespace X_335_ThomasRey_Projet
{
    public class TaskRepository
    {
        // Message de status
        public string StatusMessage { get; set; }

        // Implémentation SQLite spécifique à la plateforme
        private SQLiteAsyncConnection _connection;

        public TaskRepository(string dbPath) {
            // Recupertation ou creation de la connexion à la DB
            _connection = new SQLiteAsyncConnection(dbPath);

            // Creation de la table Task
            _connection.CreateTableAsync<TaskDB>();
        }

        // Ajout d'une tâche
        public async Task AddNewTaskAsync (string name, string description, bool daily = false)
        {
            var result = 0;

            try
            {
                // ajout un utilisateur
                TaskDB toto = new TaskDB() { Name = name, Description = description };
                result = await _connection.InsertAsync(toto);
                //result = await _connection.InsertAsync(new TaskDB { Name = name, Description = description});
                StatusMessage = $"{result} tâche ajouté : {name}";
            }
            catch (Exception ex)
            {
                // message en cas d'erreur
                StatusMessage = $"AdNewTask erreur {name}.\nErreur : {ex.Message}";

            }
        }

        // Récuperation de tous les utilisateurs
        public async Task<List<TaskDB>> GetTasksAsync()
        {
            try
            {
                // retourne la liste de toutes les tâches
                return await _connection.Table<TaskDB>().ToListAsync();
            }
            catch (Exception ex)
            {
                // en cas d'erreur, message et retour d'une liste vide
                StatusMessage = $"GetsTasks Impossible.\nErreur : {ex.Message}";
                return new List<TaskDB>();
            }
        }
    }
}