#region 文件描述
//---------------------------------------------------------------------------------------------
// 文 件 名: Message.cs
// 作    者：XuQing
// 邮    箱：Code@XuQing.me
// 创建时间：2015/4/23 14:18:05
// 描    述：
// 版    本：Version 1.0
//---------------------------------------------------------------------------------------------
// 历史更新纪录
//---------------------------------------------------------------------------------------------
// 版    本：           修改时间：           修改人：           
// 修改内容：
//---------------------------------------------------------------------------------------------
// 本文件内代码如果没有特殊说明均遵守MIT开源协议 http://opensource.org/licenses/mit-license.php
//---------------------------------------------------------------------------------------------
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiteSocket
{
   public class Message
    {
       public string MsgComm { set; get; }
       public string MsgCBComm { set; get; }
       private Dictionary<string, string> _MsgDatas = new Dictionary<string, string>();
       public Dictionary<string, string> MsgDatas
       {
           get { return _MsgDatas; }
           set { _MsgDatas = value; }
       }

    }
}
