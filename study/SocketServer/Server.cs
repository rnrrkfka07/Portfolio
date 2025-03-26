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
            //끝점 생성 (서버 IP 및 포트)
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("172.16.14.155"), 8211);
            //접속을 처리하는 소켓(데이터 통신 X)
            Socket listenSocket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            //접속을 처리하는 소켓에 IP 및 포트 할당
            listenSocket.Bind(endPoint);
            listenSocket.Listen(10); //최대 대기 수

            //접속한 클라이언트와 통신할 새 소켓 생성
            Socket clientSocket = listenSocket.Accept();
            byte[] recvBuff = new byte[1024];
            while (true)
            {
                int recvBytes = clientSocket.Receive(recvBuff); //데이터 송신(데이터 길이)
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
