using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPF_TaskSchedule.Services;

namespace WPF_TaskSchedule
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static TaskDatabaseService taskDatabase;

        public static TaskDatabaseService TaskDatabase
        {
            get
            {
                if (taskDatabase == null)
                {
                    taskDatabase = new TaskDatabaseService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "WPFAppDb.db3"));
                }
                return taskDatabase;
            }
        }
    }
}
