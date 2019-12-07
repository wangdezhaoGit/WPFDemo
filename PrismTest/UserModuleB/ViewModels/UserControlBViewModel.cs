using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Common.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

namespace UserModuleB.ViewModels
{
    public class UserControlBViewModel : BindableBase
    {
        private string m_textB;
        private string m_textTime;

        private bool m_isEnabled;
        public bool IsEnabled
        {
            get { return m_isEnabled; }
            set
            {
                SetProperty(ref m_isEnabled, value);
                BtnClickCommand.RaiseCanExecuteChanged();
            }
        }
        public string TextB
        {
            get { return m_textB; }
            set { SetProperty(ref m_textB, value); }
        }
        public string TextTime
        {
            get { return m_textTime; }
            set { SetProperty(ref m_textTime, value); }
        }

        private IEventAggregator m_eventAggregator;
        public UserControlBViewModel(IEventAggregator eventAggregator)
        {
            TextB = "我是B模块视图";
            BtnClickCommand = new DelegateCommand(Execute, CanExecute).ObservesProperty(() => IsEnabled);
            BtnClickSendMsgCommand = new DelegateCommand(ExecuteSendMsg, CanExecute).ObservesProperty(() => IsEnabled);
            IsEnabled = true;
            m_eventAggregator = eventAggregator;
        }

        private void ExecuteSendMsg()
        {
            m_eventAggregator.GetEvent<SendMessageEvent>().Publish("你好呀，我是来自B视图的问候!" + DateTime.Now.ToString());
        }

        private void Execute()
        {
            TextTime = DateTime.Now.ToString();
            //IsEnabled = false;
        }

        private bool CanExecute()
        {
            return IsEnabled;
        }
        public DelegateCommand BtnClickCommand { get; private set; }
        public DelegateCommand BtnClickSendMsgCommand { get; private set; }


    }
}
