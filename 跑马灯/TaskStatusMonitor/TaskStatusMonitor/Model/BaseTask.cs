using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskStatusMonitor.Enums;

namespace TaskStatusMonitor.Model
{
   public class BaseTask : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private TaskStatusEnums _taskStatus;
        /// <summary>
        /// 任务状态
        /// </summary>
       public TaskStatusEnums TaskStatus
       {
           get { return _taskStatus; }
            set
            {
                _taskStatus = value;
                NotifyPropertyChanged("TaskStatus");
            }
       }


       public virtual void StartTask()
       {

       }



   }
}
