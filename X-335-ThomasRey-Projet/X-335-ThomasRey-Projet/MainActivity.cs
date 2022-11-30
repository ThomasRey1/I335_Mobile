using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Hardware;
using Android.Hardware.Lights;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace X_335_ThomasRey_Projet
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, ISensorEventListener
    {
        private string _dbPath = System.IO.Path.Combine(FileSystem.AppDataDirectory, "MaDB.db3");

        private EditText _textTmp;
        private ListView _listDone;
        private ListView _listToDo;
        private LinearLayout _nav;
        private List<TaskDB> _tasks;
        private SensorManager _sensorMgr;
        private Sensor _accelerometer;
        private float _xValue;
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // Enregistrement de l'accéléromètre dans OnCreate ou OnResume
            _sensorMgr = (SensorManager)GetSystemService(SensorService);
            _accelerometer = _sensorMgr.GetDefaultSensor(SensorType.Accelerometer);
            _sensorMgr.RegisterListener(this, _accelerometer, SensorDelay.Normal);

            _textTmp = (EditText)FindViewById(Resource.Id.editText1);

            //Menu
            LinearLayout layoutBlur = (LinearLayout)FindViewById(Resource.Id.layoutblur);
            Button menu = (Button)FindViewById(Resource.Id.btnMenu);
            _nav = (LinearLayout)FindViewById(Resource.Id.layoutNav);
            layoutBlur.Click += DisplayNav_Click;
            menu.Click += DisplayNav_Click;

            //List
            _listToDo = (ListView)FindViewById(Resource.Id.listToDo);
            Button clickToDo = (Button)FindViewById(Resource.Id.btnClickToDo);
            clickToDo.Click += DisplayTask_Click;
            _listDone = (ListView)FindViewById(Resource.Id.listDone);
            Button clickDone = (Button)FindViewById(Resource.Id.btnClickDone);
            clickDone.Click += DisplayTask_Click;

            TaskRepository taskRepository = new TaskRepository(_dbPath);
            await taskRepository.AddNewTaskAsync("ma tâche2", "ma description2");
            _tasks = await taskRepository.GetTasksAsync();
            _textTmp.Text = taskRepository.StatusMessage;
            //Adapter
            TaskAdapter adapter1 = new TaskAdapter(_tasks, this);

            TaskAdapter adapter2 = new TaskAdapter(_tasks, this);

            _listToDo.Adapter = adapter1;
            _listDone.Adapter = adapter2;
            _listToDo.Visibility = ViewStates.Gone;
            _listDone.Visibility = ViewStates.Gone;


            Button addTask = (Button)FindViewById(Resource.Id.btnNewTask);
            addTask.Click += NewTask_Click;

            Button myTask = (Button)FindViewById(Resource.Id.btnTask);
            myTask.Click += MyTask_Click;

            Button newCategory = (Button)FindViewById(Resource.Id.btnAddCategory);
            newCategory.Click += NewCategory_Click;
        }

        protected override void OnPause()
        {
            base.OnPause();
            // Libere l'accéléromètre
            _sensorMgr.UnregisterListener(this);
        }

        /// <summary>
        /// détécte si l'utilisateur secoue le téléphone horizontalement
        /// </summary>
        /// <param name="e"></param>
        public void OnSensorChanged(SensorEvent e)
        {
            // Il s'agit de l'accéléromètre
            if (e.Sensor.Equals(_accelerometer))
            {
                // 3 valeurs qui correspondent ici au 3 accélération en x, y et z
                IList<float> valures = e.Values;

                // Détecte un mouvement horizontal
                if (Math.Abs(valures[0] - _xValue) > 5)
                {
                    _textTmp.Text = "Effacer les éléments";
                }
                else
                {
                    _xValue = valures[0];
                    _textTmp.Text = "";
                }
            }
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
            _nav.Visibility = _nav.Visibility == ViewStates.Visible ? ViewStates.Gone : ViewStates.Visible;
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
                _listToDo.Visibility = _listToDo.Visibility == ViewStates.Visible ? ViewStates.Gone : ViewStates.Visible;
            }
            else
            {
                _listDone.Visibility = _listDone.Visibility == ViewStates.Visible ? ViewStates.Gone :  ViewStates.Visible;
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

        public void OnAccuracyChanged(Sensor sensor, [GeneratedEnum] SensorStatus accuracy)
        {

        }
    }
}