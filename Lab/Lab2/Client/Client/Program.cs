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
            IPEndPoint severEnPoint = new IPEndPoint(IPAddress.Loopback, 6650);

            Socket severSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Console.WriteLine("Dang ket noi toi sever...");
            try
            {
                severSocket.Connect(severEnPoint);
            }
            catch
            {
                Console.WriteLine("Khong the ket noi toi sever");
                Console.ReadKey();
            }

            if (severSocket.Connected)
            {
                Console.WriteLine("Ket noi thanh cong voi server ...");
                byte[] buff = new byte[100];
                var byteRecive = severSocket.Receive(buff, 0, buff.Length, SocketFlags.None);
                var str = Encoding.ASCII.GetString(buff);
                Console.WriteLine("Du lieu tu sever: "+str);
                Console.ReadKey();
            }
        }
    }
}
