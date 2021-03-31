using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace UDPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint svEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6650);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            serverSocket.Bind(svEP);




            byte[] data = new byte[1024];
            EndPoint clientEP = new IPEndPoint(IPAddress.Any, 0);
            int byteRecive;

            while (true)
            {
                byteRecive = serverSocket.ReceiveFrom(data, 0, data.Length, SocketFlags.None, ref clientEP);
                string strRecive = Encoding.ASCII.GetString(data);
                //byteRecive = 0; //xóa dòng này để gửi dữ liệu về server - lỗi ở client không nhận được phản hồi từ server
                if (byteRecive > 0)
                {
                    serverSocket.SendTo(Encoding.ASCII.GetBytes(strRecive), 0, byteRecive, SocketFlags.None, clientEP);
                    Console.WriteLine("Da ket noi toi: " + clientEP.ToString());
                    Console.WriteLine("Du lieu nhan duoc: " + strRecive);
                }
            }
        }
        

    }
}
