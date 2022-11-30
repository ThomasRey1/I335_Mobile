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
using SQLite;
using Java.Sql;
using SQLiteNetExtensions.Attributes;
using System.Reflection.Emit;

namespace X_335_ThomasRey_Projet
{
    //[Table("t_category")]
    public class Category
    {
        [PrimaryKey, AutoIncrement, NotNull, MaxLength(11)]
        public int Id { get; set; }
        public string Name { get; set; }
        [OneToMany]
        public List<TaskDB> Tasks { get; set; }
        public override string ToString()
        {
            return $"{{Id={Id}, Name={Name}, Tasks={Tasks}}}";
        }
    }

    [Table("t_task")]
    public class TaskDB
    {
        //[PrimaryKey, AutoIncrement, NotNull, MaxLength(11), Unique]
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool Daily { get; set; }
        public bool Done { get; set; }
        //[ForeignKey(typeof(Category))]
        //public int CategoryId { get; set; }
        //[ManyToOne]
        //public Category Category { get; set; }

        //public override string ToString()
        //{
        //    return $"{{Id={Id}, Name={Name}, Description={Description}, DueDate={DueDate}, Daily={Daily}, Done={Done}, CategoryId={CategoryId}, Category={Category}}}";
        //}
    }
}