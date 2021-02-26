using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Sever
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint severEndPoint = new IPEndPoint(IPAddress.Any, 6650);

            Socket severSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            severSocket.Bind(severEndPoint);

            //Số lượng client được truy cập vào sever
            severSocket.Listen(10);

            Console.WriteLine("Đang cho client ket noi...");
            Socket clientSocket = severSocket.Accept();

            //Khi client kết nối tới sever sẽ xuất thông tin của client kết nối tới
            EndPoint clientEndPoint = clientSocket.RemoteEndPoint;
            Console.WriteLine("Thong tin client va port: " + clientEndPoint.ToString());


            //gửi dữ liệu xuống client
            byte[] buff;
            string str = "Hello client";
            buff = Encoding.ASCII.GetBytes(str);
            clientSocket.Send(buff,0,buff.Length,SocketFlags.None);

            Console.ReadKey();
        }
    }
}
