#region 文件描述
//---------------------------------------------------------------------------------------------
// 文 件 名: APNSettingsHelper.cs
// 作    者：XuQing
// 邮    箱：Code@XuQing.me
// 创建时间：2015/4/25 19:32:52
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
using LiteSocket;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AndroidAPNSettings
{
    public class CommandHelper
    {
        public static readonly CommandHelper instance = new CommandHelper();
        /// <summary>
        /// SocketClient
        /// </summary>
        public SocketClient SC;

        public bool AdbForward(string port)
        {
            KillAdb();
            Process.Start("adbforward.bat");
            return true;
        }

        public void KillAdb()
        {

            KillProcess("ADB");
            KillProcess("adb");
            KillProcess("tadb");
            KillProcess("wandoujia_helper");
            KillProcess("wandoujia2");
            KillProcess("wandoujia_adb");
            //KillProcess("360MobileMgr");

        }
        private void KillProcess(string ProName)
        {
            Process[] pbox = Process.GetProcesses();
            foreach (Process p in pbox)
            {
                if (p.ProcessName == ProName)
                {
                    p.Kill();
                }
            }
        }
        public bool Connect(string ip, int port)
        {
            SC = new SocketClient(ip, port);
            return SC.Connect();
        }

        public void Close()
        {
            if (SC != null)
            {
                SC.Close();
            }
        }


        public bool OpenApnPage()
        {
            var result = SC.SendData("OpenApnPage");
            if (result["Result"] == "OK")
            {
                return true;
            }
            else
            {
                return false;
            }


          
        }

        public bool AddApn(string Name, string APN)
        {
            Dictionary<string, string> doSth = new Dictionary<string, string>();
            int i = 0;
            doSth.Add((i++).ToString(), "input tap 463 1810");//点击新建
            doSth.Add((i++).ToString(), "input tap 650 290"); //点击名称
            doSth.Add((i++).ToString(), "input text " + Name); //输入名称
            doSth.Add((i++).ToString(), "input tap 846 1040");  //点击确定
            doSth.Add((i++).ToString(), "input tap 650 470");  //点击APN
            doSth.Add((i++).ToString(), "input text " + APN); //输入APN
            doSth.Add((i++).ToString(), "input tap 846 1040");  //点击确定
            doSth.Add((i++).ToString(), "input keyevent 4"); //退出 (弹出保存确认框)
            doSth.Add((i++).ToString(), "input tap 730 1780");  // 确认保存
            var result = SC.SendData("AddApn", doSth);
            if (result["Result"] == "OK")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ChangeNetMode(string NetMode)
        {
            Dictionary<string, string> doSth = new Dictionary<string, string>();
            int i = 0;
            doSth.Add((i++).ToString(), "input swipe 640 550 640 1440");  //滑到最顶端
            doSth.Add((i++).ToString(), "input tap 640 430");
            doSth.Add((i++).ToString(), "input tap 640 1040");
            switch (NetMode)
            {
                case "4G":
                    doSth.Add((i++).ToString(), "input tap 640 260");//选择4G
                    break;
                case "3G":
                    doSth.Add((i++).ToString(), "input tap 640 430");//选择3G
                    break;
                case "2G":
                    doSth.Add((i++).ToString(), "input tap 640 600");//点击2G
                    break;
                default:
                    break;
            }
            doSth.Add((i++).ToString(), "input keyevent 4");
            doSth.Add((i++).ToString(), "input keyevent 4");
            var result = SC.SendData("SetNetMode", doSth);
            if (result["Result"] == "OK")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DoTelnet(string IP, string Port)
        {
            Dictionary<string, string> doSth = new Dictionary<string, string>();
            doSth.Add("IP", IP);
            doSth.Add("Port", Port);
            var result = SC.SendData("DoTelnet", doSth);
            if (result["Result"] == "OK")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string DoPing(string url)
        {
            Dictionary<string, string> doSth = new Dictionary<string, string>();
            doSth.Add("URL", url);
            var result = SC.SendData("DoPing", doSth);
            if (result["Result"] == "OK")
            {
                return result["PingResult"];
            }
            else
            {
                return "Error !";
            }
        }
    }
}
