using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace TCPServer_Async
{
    public partial class Form1 : Form
    {
        IPEndPoint serverEP;
        Socket serverSocket;
        Socket clientsocket;
        byte[] data = new byte[1024];
        string str;
        public Form1()
        {
            InitializeComponent();
        }
        public void StartServer()
        {
            serverEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6666);
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            serverSocket.Bind(serverEP);
            serverSocket.Listen(10);

            serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), serverSocket);
        }
        public void AcceptCallback(IAsyncResult ia)
        {
            serverSocket = (Socket)ia.AsyncState; //lấy lại socket của server
            clientsocket = serverSocket.EndAccept(ia); //lấy socket của client truy cập tới
            str = "Hello client";

            data = Encoding.ASCII.GetBytes(str);

            clientsocket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), clientsocket);
        }
        public void SendCallback(IAsyncResult ia)
        {
            clientsocket.EndSend(ia);
            clientsocket.BeginReceive(data, 0, data.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), clientsocket);
        }
        public void ReceiveCallback(IAsyncResult ia)
        {
            serverSocket = (Socket)ia.AsyncState; //lấy lại socket của server
            clientsocket = serverSocket.EndAccept(ia); //lấy socket của client truy cập tới

            int count = clientsocket.EndReceive(ia);

            str = Encoding.ASCII.GetString(data);
            SetText(str);

            clientsocket.BeginSend(data, 0, count,SocketFlags.None,new AsyncCallback(SendCallback),clientsocket);
            
        }
        public void SetText(string str)
        {
            lbMain.Items.Add(str);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            StartServer();
        }
    }
}
