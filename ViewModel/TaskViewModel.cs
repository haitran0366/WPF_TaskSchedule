using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_TaskSchedule.Models;
using WPF_TaskSchedule.Services;

namespace WPF_TaskSchedule.ViewModel
{
    public class TaskViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private string taskName;
        public string TaskName
        {
            get { return taskName; }
            set
            {
                taskName = value;
                NotifyPropertyChanged("TaskName");
            }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                NotifyPropertyChanged("Description");
            }
        }
        private DateTime dueDate = DateTime.Now;
        public DateTime DueDate
        {
            get { return dueDate; }
            set
            {
                dueDate = value;
                NotifyPropertyChanged("DueDate");
            }
        }

        private List<TaskModel> taskList;
        public List<TaskModel> TaskList
        {
            get { return taskList; }
            set
            {
                taskList = value;
                NotifyPropertyChanged("TaskList");

            }
        }
        public ICommand cmdAddTask { get; private set; }
        public bool CanExectute
        {
            get { return !string.IsNullOrEmpty(TaskName); }
        }
        public TaskViewModel()
        {
            cmdAddTask = new RelayCommand(AddTask, () => CanExectute);
            getTask();
        }

        private async void AddTask()
        {
            var r = await App.TaskDatabase.SaveTaskAsync(new TaskModel
            {
                TaskName = TaskName,
                Description = Description,
                DueDate = DueDate
            });
            getTask();

        }
        public async void getTask()
        {
            TaskList = await App.TaskDatabase.GetTaskAsync();
        }
    }
}
