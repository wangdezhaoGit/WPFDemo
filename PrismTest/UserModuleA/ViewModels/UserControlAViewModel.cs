using Common.Events;
using Prism.Events;
using Prism.Mvvm;

namespace UserModuleA.ViewModels
{
    public class UserControlAViewModel : BindableBase
    {
        private string _text;

        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }


        private string m_receiveMsg;

        public string ReceiveMsg
        {
            get { return m_receiveMsg; }
            set { SetProperty(ref m_receiveMsg, value); }
        }

        private IEventAggregator m_eventAggregator;
        public UserControlAViewModel(IEventAggregator eventAggregator)
        {
            m_eventAggregator = eventAggregator;
            Text = "我是A模块视图";
            m_eventAggregator.GetEvent<SendMessageEvent>().Subscribe(OnSendMessageEvent);
        }

        private void OnSendMessageEvent(string obj)
        {
            ReceiveMsg = obj;
        }
    }
}
