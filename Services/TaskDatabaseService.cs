using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_TaskSchedule.Models;

namespace WPF_TaskSchedule.Services
{
    public class TaskDatabaseService
    {
        readonly SQLite.SQLiteAsyncConnection _database;

        public TaskDatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<TaskModel>().Wait();
        }

        public Task<List<TaskModel>> GetTaskAsync()
        {
            return _database.Table<TaskModel>().OrderByDescending(x => x.DueDate).ToListAsync();
        }

        public Task<int> SaveTaskAsync(TaskModel taskModel)
        {
            return _database.InsertAsync(taskModel);

        }
    }
}
