using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;

namespace Common.Events
{
    //PubSubEvent<T>类负责连接发布者和订阅者，他负责维护订阅者列表并处理事件派发给订阅者。
    public class SendMessageEvent : PubSubEvent<string>
    {
    }
}
