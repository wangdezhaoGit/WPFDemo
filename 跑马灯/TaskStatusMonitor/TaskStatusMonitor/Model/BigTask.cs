using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskStatusMonitor.Model
{
    public class BigTask : BaseTask
    {
        private ObservableCollection<SubTask> _subTaskList;

        public ObservableCollection<SubTask> SubTaskList
        {
            get { return _subTaskList; }
            set
            {
                _subTaskList = value;
                NotifyPropertyChanged("SubTaskList");
            }
        }


        public override void StartTask()
        {
            foreach (SubTask subTask in SubTaskList)
            {
                subTask.StartTask();
            }
        }
    }
}
