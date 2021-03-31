using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace UDPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            EndPoint serverEP = new IPEndPoint(IPAddress.Loopback, 6650);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 3000);

            Console.WriteLine("Nhap cau chao len server, nhap 'exit' de thoat");

            int byteRecive;
            byte[] data = new byte[1024];
            while (true)
            {
                string str = Console.ReadLine();
                if (str.Equals("exit")) break;
                
                data = Encoding.ASCII.GetBytes(str);

                //server.SendTo(data, 0, data.Length, SocketFlags.None, serverEP);
                //data = new byte[1024];
                //byteRecive = server.ReceiveFrom(data, 0, data.Length, SocketFlags.None, ref serverEP);
                byteRecive = SndRcvData(server, data, serverEP);
                if (byteRecive > 0)
                {
                    Console.WriteLine("nhan tu server: " + Encoding.ASCII.GetString(data, 0, byteRecive));
                }
                else Console.WriteLine("Khong lien lac duoc server");

                
            }
             int SndRcvData(Socket s, byte[] message, EndPoint rmtdecive)
            {
                int recv;
                int retry = 0;
                

                while (true)
                {
                    Console.WriteLine("Truyen lai lan thu: {0}", retry);
                    try
                    {
                        s.SendTo(message, message.Length, SocketFlags.None, rmtdecive);
                        
                        recv = s.ReceiveFrom(message, ref rmtdecive);
                    }
                    catch
                    {
                        recv = 0;
                    }
                    if (recv > 0)
                    {
                        return recv;
                    }
                    else
                    {
                        retry++;
                        if (retry > 4)
                        {
                            return 0;
                        }
                    }
                }
            }
        }
        
    }
}
