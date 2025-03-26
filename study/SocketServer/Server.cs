using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("172.16.14.155"), 8211);
            Socket listenSocket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            listenSocket.Bind(endPoint);
            listenSocket.Listen(10);

            
            Socket clientSocket = listenSocket.Accept();
            byte[] recvBuff = new byte[1024];
            while (true)
            {
                int recvBytes = clientSocket.Receive(recvBuff);
                string recvData = Encoding.UTF8.GetString(recvBuff, 0, recvBytes);
                if(recvData == "exit")
                {
                    break;
                }
                Console.WriteLine($"Client : {recvData}");
            }
            listenSocket.Close();
        }
    }
}
