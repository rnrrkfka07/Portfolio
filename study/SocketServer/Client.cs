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
            //끝점 생성 (서버 IP 및 포트)
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("172.16.14.155"), 8211);
            //소켓 생성
            Socket socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            //소켓을 끝점에 연결
            socket.Connect(endPoint);
            Console.WriteLine("Connect...");

            while (true) { 
                String str = Console.ReadLine();
                byte[] sendBuff = Encoding.UTF8.GetBytes(str);
                socket.Send(sendBuff); //입력받은 문자열을 서버에 전송
                if(str == "exit")
                {
                    break;

                }
            }
            socket.Close();
        }
    }
}
