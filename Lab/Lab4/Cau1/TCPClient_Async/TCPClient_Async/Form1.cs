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

namespace TCPClient_Async
{
    public partial class Form1 : Form
    {
        byte[] buff = new byte[1024];
        int byteRecive = 0;
        IPEndPoint serverEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6666);
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        string str = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }
        public void Connect()
        {
            serverSocket.BeginConnect(serverEP, new AsyncCallback(ConnectCallback), serverSocket);
        }
        public void ConnectCallback(IAsyncResult ia)
        {
            serverSocket.BeginReceive(buff, 0, buff.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), serverSocket);
        }
        public void ReceiveCallback(IAsyncResult ia)
        {
            serverSocket = (Socket)ia.AsyncState;
            byteRecive = serverSocket.EndReceive(ia);
            str = Encoding.ASCII.GetString(buff, 0, byteRecive);
            SetTextCb(str);
        }


        private void btnConnect_Click(object sender, EventArgs e)
        {
            btnConnect.Enabled = false;
            Connect();
        }

        delegate void SetTextCallback(string text);

        private void SetTextCb(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.lbMain.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTextCb);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                SetText(text);
            }
        }
        public void SetText(string str)
        {
            lbMain.Items.Add(str);
        }
    }
}
