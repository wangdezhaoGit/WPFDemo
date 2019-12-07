using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TaskStatusMonitor.Enums;

namespace TaskStatusMonitor.Model
{
  public  class SubTask:BaseTask
    {
        public override void StartTask()
        {
            Task.Run(() =>
            {
                int i = 1;
                while (i<6)
                {
                    TaskStatus = (TaskStatusEnums)i;
                    Task.Delay(TimeSpan.FromSeconds(2));
                    i++;
                }
            });
        }

        private Visibility _leftLineShow;

        public Visibility LeftLineShow
        {
            get { return _leftLineShow; }
            set
            {
                _leftLineShow = value;
                NotifyPropertyChanged("LeftLineShow");
            }
        }

        private Visibility _rightLineShow;

        public Visibility RightLineShow
        {
            get { return _rightLineShow; }
            set
            {
                _rightLineShow = value;
                NotifyPropertyChanged("RightLineShow");
            }
        }

    }
}
