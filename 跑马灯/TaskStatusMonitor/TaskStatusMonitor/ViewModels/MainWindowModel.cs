using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TaskStatusMonitor.Common;
using TaskStatusMonitor.Enums;
using TaskStatusMonitor.Model;

namespace TaskStatusMonitor.ViewModels
{
    public class MainWindowModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public MainWindowModel()
        {
            CurBigTaskList = new ObservableCollection<BigTask>();
            TaskCounts = "10";
            SubTaskMaxCounts = "12";
        }

        private ObservableCollection<BigTask> _curBigTaskList;

        public ObservableCollection<BigTask> CurBigTaskList
        {
            get { return _curBigTaskList; }
            set
            {
                _curBigTaskList = value;
                NotifyPropertyChanged("CurBigTaskList");
            }
        }

        private string _taskCounts;

        public string TaskCounts
        {
            get { return _taskCounts; }
            set
            {
                _taskCounts = value;
                NotifyPropertyChanged("TaskCounts");
            }
        }

        private string _taskSum;

        public string TaskSum
        {
            get { return _taskSum; }
            set
            {
                _taskSum = value;
                NotifyPropertyChanged("TaskSum");
            }
        }

        private string _errorTaskSum;

        public string ErrorTaskSum
        {
            get { return _errorTaskSum; }
            set
            {
                _errorTaskSum = value;
                NotifyPropertyChanged("ErrorTaskSum");
            }
        }


        private string _subTaskMaxCounts;

        public string SubTaskMaxCounts
        {
            get { return _subTaskMaxCounts; }
            set
            {
                _subTaskMaxCounts = value;
                NotifyPropertyChanged("SubTaskMaxCounts");
            }
        }

        #region 命令

        private int ErrorTaskSumInt = 0;

       
        static int GetRandomSeed()
        {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }


        void CanAddTaskCommandExecute()
        {
            Task.Run(() =>
            {
                try
                {
                    //Parallel.For(0, Int32.Parse(TaskCounts), (i) =>
                    //{
                    //    BigTask bt = new BigTask();
                    //bt.SubTaskList = new ObservableCollection<SubTask>();
                    //int subCount = new Random().Next(1, Int32.Parse(SubTaskMaxCounts));
                    //for (int j = 0; j < subCount; j++)
                    //{
                    //    SubTask st = new SubTask();
                    //    Random rd = new Random(GetRandomSeed());
                    //    int stsInt = rd.Next(0, 4);
                    //    st.TaskStatus = (TaskStatusEnums)stsInt;
                    //    if (stsInt == 3)
                    //    {
                    //        ErrorTaskSumInt = ErrorTaskSumInt + 1;
                    //    }
                    //    if (subCount == 1)
                    //    {
                    //        st.LeftLineShow = Visibility.Collapsed;
                    //        st.RightLineShow = Visibility.Collapsed;
                    //    }
                    //    else
                    //    {
                    //        if (j == 0)
                    //        {
                    //            st.LeftLineShow = Visibility.Collapsed;
                    //            st.RightLineShow = Visibility.Visible;
                    //        }
                    //        else if (j == subCount - 1)
                    //        {
                    //            st.LeftLineShow = Visibility.Visible;
                    //            st.RightLineShow = Visibility.Collapsed;
                    //        }
                    //        else
                    //        {
                    //            st.LeftLineShow = Visibility.Visible;
                    //            st.RightLineShow = Visibility.Visible;
                    //        }

                    //    }

                    //    bt.SubTaskList.Add(st);
                    //}

                    //    Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Background,
                    //        new Action(delegate ()
                    //        {
                    //            int sum = CurBigTaskList.Count;
                    //            CurBigTaskList.Add(bt);
                    //            TaskSum = sum.ToString();
                    //            ErrorTaskSum = ErrorTaskSumInt.ToString();
                    //        }));
                    //});


                    for (int i = 0; i < Int32.Parse(TaskCounts); i++)
                    {
                        BigTask bt = new BigTask();
                        bt.SubTaskList = new ObservableCollection<SubTask>();
                        int subCount = new Random().Next(1, Int32.Parse(SubTaskMaxCounts));
                        int subError = 0;
                        for (int j = 0; j < subCount; j++)
                        {
                            SubTask st = new SubTask();
                            Random rd = new Random(GetRandomSeed());
                            int stsInt = rd.Next(0, 4);

                            if (subError >= 1)
                            {
                                stsInt = 2;
                            }
                            st.TaskStatus = (TaskStatusEnums)stsInt;
                            if (stsInt == 3)
                            {
                                ErrorTaskSumInt = ErrorTaskSumInt + 1;
                                subError = subError + 1;
                            }
                            if (subCount == 1)
                            {
                                st.LeftLineShow = Visibility.Collapsed;
                                st.RightLineShow = Visibility.Collapsed;
                            }
                            else
                            {
                                if (j == 0)
                                {
                                    st.LeftLineShow = Visibility.Collapsed;
                                    st.RightLineShow = Visibility.Visible;
                                }
                                else if (j == subCount - 1)
                                {
                                    st.LeftLineShow = Visibility.Visible;
                                    st.RightLineShow = Visibility.Collapsed;
                                }
                                else
                                {
                                    st.LeftLineShow = Visibility.Visible;
                                    st.RightLineShow = Visibility.Visible;
                                }

                            }

                            bt.SubTaskList.Add(st);
                        }

                        Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Background,
                            new Action(delegate ()
                            {
                                CurBigTaskList.Add(bt);
                                int sum = CurBigTaskList.Count;
                                TaskSum = sum.ToString();
                                ErrorTaskSum = ErrorTaskSumInt.ToString();
                            }));
                    }
                }
                catch (Exception ex)
                {
                    //throw;
                }
            });
        }

        bool CanUpdateNameExecute()
        {
            return true;
        }

        public ICommand AddTaskCommand
        {
            get { return new RelayCommand(CanAddTaskCommandExecute, CanUpdateNameExecute); }
        }

        #endregion
    }
}
