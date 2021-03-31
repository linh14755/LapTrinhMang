using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDPClient
{
    public partial class Form1 : Form
    {
        UdpClient serverSocket;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread connectToServerThread = new Thread(new ThreadStart(ConnectToServer));
            connectToServerThread.Start();

            btnConnect.Enabled = false;
            btnSend.Enabled = true;
        }

        void ConnectToServer()
        {
            serverSocket = new UdpClient("127.0.0.1", 3000);
            IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Loopback, 3000);

            string str = "Xin chao server";
            byte[] data = Encoding.ASCII.GetBytes(str);

            serverSocket.Send(data, data.Length);

            data = serverSocket.Receive(ref serverEndpoint);

            str = Encoding.ASCII.GetString(data, 0, data.Length);

            lbMain.Items.Add("Phan hoi tu server: " + str);

            Thread listenToServer = new Thread(new ThreadStart(ListenToServer));
            listenToServer.Start();
        }
        void ListenToServer()
        {
            IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                byte[] data = serverSocket.Receive(ref serverEndpoint);
                string str = Encoding.ASCII.GetString(data, 0, data.Length);
                lbMain.Items.Add("Phan hoi tu server: " + str);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string message = txtInput.Text;
            byte[] data = Encoding.ASCII.GetBytes(message);
            serverSocket.Send(data, data.Length);

            txtInput.Text = "";
        }
    }
}
