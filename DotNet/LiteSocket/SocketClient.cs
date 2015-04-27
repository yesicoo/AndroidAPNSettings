using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace LiteSocket
{


    public class SocketClient
    {
        public bool IsConnected = false;
        private static byte[] result = new byte[2048];
        string IP;
        int Port;
        Thread t_Server;
        Socket clientSocket;
        
        Dictionary<string, Action<string, Dictionary<string, string>>> Comms = new Dictionary<string, Action<string, Dictionary<string, string>>>();


        public SocketClient(string ip, int port)
        {
            IP = ip;
            Port = port;
        }
        public void Close()
        {
            clientSocket.Close();
            t_Server.Abort();
        }

        public bool Connect()
        {
            try
            {
                IPAddress ip = IPAddress.Parse(IP);
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.Connect(new IPEndPoint(ip, Port)); //配置服务器IP与端口  
                t_Server = new Thread(() =>
                  {
                      while (clientSocket.Connected)
                      {
                          try
                          {
                              int receiveLength = clientSocket.Receive(result);
                              if (receiveLength > 0)
                              {
                                  //接收数据处理
                                  string msgStr = Encoding.UTF8.GetString(result, 2, receiveLength - 2);
                                  Console.WriteLine(msgStr);
                                  Message msg = JsonConvert.DeserializeObject<Message>(msgStr);
                                  Action<string, Dictionary<string, string>> action = null;
                                  if (!Comms.TryGetValue(msg.MsgComm, out action))
                                  {
                                      Console.WriteLine("MsgComm :" + msg.MsgComm + " 不存在");
                                  }
                                  else
                                  {
                                      action(msg.MsgCBComm, msg.MsgDatas); //回调
                                  }
                              }
                          }
                          catch (Exception ex)
                          {
                              
                          }
                      }
                  });
                t_Server.IsBackground = false;
                t_Server.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            IsConnected = clientSocket.Connected;
            return IsConnected;
        }

        /// <summary>
        /// 注册回调方法
        /// </summary>
        /// <param name="Comm">消息命令</param>
        /// <param name="CallBack">回调方法</param>
        public void RegistComm(string Comm, Action<string/*返回消息命令*/, Dictionary<string, string>> CallBack)
        {
            if (!Comms.ContainsKey(Comm))
            {
                Comms.Add(Comm, CallBack);
            }
            else
            {
                Comms[Comm] = CallBack;
            }
        }

        public void UnRegistComm(string Comm)
        {
            if (Comms.ContainsKey(Comm))
            {
                Comms.Remove(Comm);
            }
        }
        /// <summary>
        /// 发送数据给服务端，需要返回，回调响应
        /// </summary>
        /// <param name="comm">命令消息</param>
        /// <param name="callBackComm">返回消息</param>
        /// <param name="msgDatas">消息内容</param>
        public void PostData(string comm, string callBackComm, Dictionary<string, string> msgDatas)
        {
            Message m = new Message();
            m.MsgComm = comm;
            m.MsgCBComm = callBackComm;
            m.MsgDatas = msgDatas;
            string json = JsonConvert.SerializeObject(m);

            Console.WriteLine(json);
            if (clientSocket.Connected)
            {
                clientSocket.Send(Encoding.UTF8.GetBytes(json + "\n"));
            }
            else
            {
                Console.WriteLine("Connected Is Broken");
            }
        }
        /// <summary>
        /// 发送命令给服务端，不需要返回数据
        /// </summary>
        /// <param name="comm"></param>
        /// <param name="msgDatas"></param>
        public void PostData(string comm, Dictionary<string, string> msgDatas)
        {
            PostData(comm, "", msgDatas);
        }

        /// <summary>
        /// 发送命令给服务端，并等待返回的消息。
        /// </summary>
        /// <param name="comm"></param>
        /// <param name="waitSeconds">命令执行超时时间 默认60s</param>
        /// <returns></returns>
        public Dictionary<string, string> SendData(string comm, int waitSeconds = 60)
        {
            return SendData(comm, new Dictionary<string, string>(), waitSeconds);
        }
        /// <summary>
        /// 发送命令和数据给服务端，并等待返回的消息。
        /// </summary>
        /// <param name="comm"></param>
        /// <param name="msgDatas"></param>
        /// <param name="waitSeconds">命令执行超时时间 默认60s</param>
        /// <returns></returns>
        public Dictionary<string, string> SendData(string comm, Dictionary<string, string> msgDatas, int waitSeconds = 60)
        {
            DateTime waitTime = DateTime.Now.AddSeconds(waitSeconds);
            Dictionary<string, string> returnMsgDatas = null;
            string RdComm = RandomStr(8); //随机生成返回消息命令
            RegistComm(RdComm, (cbkey, data) =>
            {
                returnMsgDatas = data;
            });
            Message m = new Message();
            m.MsgComm = comm;
            m.MsgCBComm = RdComm;
            m.MsgDatas = msgDatas;
            string json = JsonConvert.SerializeObject(m);
            if (clientSocket.Connected)
            {
                clientSocket.Send(Encoding.UTF8.GetBytes(json + "\n"));
            }
            else
            {
                Console.WriteLine("Connect Is Broken");

            }
            //等待返回数据
            double wait = 0.00;
            while (returnMsgDatas == null && wait<=0)
            {
                Thread.Sleep(500);
                wait = (DateTime.Now - waitTime).TotalSeconds;
            }
            UnRegistComm(RdComm); //注销命令
            return returnMsgDatas;
        }


        public static string CHAR = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        /// <summary>
        /// 真·随机字符串
        /// </summary>
        /// <param name="lenght">长度</param>
        /// <returns></returns>
        public string RandomStr(int lenght)
        {

            StringBuilder sb = new StringBuilder();
            Random r = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < lenght; i++)
            {
                sb.Append(CHAR[r.Next(25)]);
            }
            return sb.ToString();
        }
    }
}
