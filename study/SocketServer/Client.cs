using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("172.16.14.155"), 8211);

            Socket socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            socket.Connect(endPoint);
            Console.WriteLine("Connect...");

            while (true) { 
                String str = Console.ReadLine();
                byte[] sendBuff = Encoding.UTF8.GetBytes(str);
                socket.Send(sendBuff);
                if(str == "exit")
                {
                    break;

                }
            }
            socket.Close();
        }
    }
}