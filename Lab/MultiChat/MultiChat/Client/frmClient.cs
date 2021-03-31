using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Client
{
    public partial class frmClient : Form
    {
        IPEndPoint IP;
        Socket client;
        Thread listenMain;
        List<SinhVien> lsv;
        public frmClient()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        void Connect(string ipserver)
        {
            IP = new IPEndPoint(IPAddress.Parse(ipserver), 6000);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                client.Connect(IP);
                MessageBox.Show("Đã kết nối tới - " + GetHostName(ipserver), "Thông báo", MessageBoxButtons.OK);
            }
            catch
            {
                MessageBox.Show("Không thể kết nối server!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            listenMain = new Thread(Receive);
            listenMain.IsBackground = true;
            listenMain.Start();
        }
        void CloseConnect()
        {
            client.Close();
        }
        void Send()
        {
            //if (txbMessage.Text != string.Empty)
            //    client.Send(Serialize(txbMessage.Text));
        }
        void Receive()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);

                    string message = (string)Deserialize(data);
                    if (message == "Close") 
                    { 
                        client.Close(); 
                        message = "Bạn đã bị ngắt kết nối !";
                        cmdKetNoi.Enabled = true;
                    }
                    try
                    {
                        lsv = new List<SinhVien>();
                        lsv = JsonConvert.DeserializeObject<List<SinhVien>>(message);
                    }
                    catch
                    {
                        AddMessage(message);
                    }
                }
            }
            catch
            {
                CloseConnect();
            }

        }
        void AddMessage(string message)
        {
            MessageBox.Show(message, "Thông báo từ Server", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        byte[] Serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formater = new BinaryFormatter();

            formater.Serialize(stream, obj);
            return stream.ToArray();
        }

        object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formater = new BinaryFormatter();


            return formater.Deserialize(stream);
        }
        public string GetHostName(string ipAddress)
        {
            try
            {
                IPHostEntry entry = Dns.GetHostEntry(ipAddress);
                if (entry != null)
                {
                    return entry.HostName;
                }
            }
            catch (SocketException ex)
            {
                //unknown host or
                //not every IP has a name
                //log exception (manage it)
            }

            return null;
        }

        private void frmClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseConnect();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Send();
            //AddMessage(txbMessage.Text);

        }

        private void cmdKetNoi_Click(object sender, EventArgs e)
        {
            Connect(txtKetNoi.Text);
            cmdKetNoi.Enabled = false;
        }

        private void cbDSThi_Click(object sender, EventArgs e)
        {
            cbDSThi.Items.Clear();
            foreach (SinhVien sv in lsv)
            {
                cbDSThi.Items.Add(sv.Mssv + " - " + sv.Ten + " - " + sv.Lop);
            }
        }
    }
}
