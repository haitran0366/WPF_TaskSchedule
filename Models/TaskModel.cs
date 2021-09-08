using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_TaskSchedule.Models
{
    public class TaskModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
    }
}
