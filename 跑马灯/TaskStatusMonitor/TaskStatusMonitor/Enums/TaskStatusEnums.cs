using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskStatusMonitor.Enums
{
    public enum TaskStatusEnums
    {
        /// <summary>
        /// 未执行
        /// </summary>
        Ready = 0,

        /// <summary>
        /// 执行中
        /// </summary>
        Excuting = 1,

        /// <summary>
        /// 完成
        /// </summary>
        Done =2,

        /// <summary>
        /// 异常
        /// </summary>
        Error = 3

    }
}
