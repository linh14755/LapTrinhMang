using ExcelDataReader;
using Newtonsoft.Json;
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

namespace Server
{
    public partial class frmServer : Form
    {
        IPEndPoint IP;
        Socket server;
        Thread listenMain;
        List<Socket> clientList;
        public frmServer()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            btnDisconnect.Enabled = false;
            Connect();

        }
        //Thêm Socket vào list
        void AddList(Socket s)
        {
            if (clientList.Count > 0)
            {
                foreach (var item in clientList)
                {
                    string ips = ((IPEndPoint)(s.RemoteEndPoint)).Address.ToString();
                    string ipl = ((IPEndPoint)(item.RemoteEndPoint)).Address.ToString();
                    if (ips != ipl) clientList.Add(s);
                }
            }
            else
            {
                clientList.Add(s);
            }

        }
        void Connect()
        {
            clientList = new List<Socket>();
            IP = new IPEndPoint(IPAddress.Any, 6000);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);



            listenMain = new Thread(() =>
            {
                try
                {
                    server.Bind(IP);
                    while (true)
                    {
                        server.Listen(100);
                        Socket client = server.Accept();
                        AddList(client);
                        btnDisconnect.Enabled = true;

                        Thread receive = new Thread(Receive);
                        receive.IsBackground = true;
                        receive.Start(client);
                    }
                }
                catch
                {
                    //Lỗi phía server, khi client đột ngột đóng thì khởi tạo lại server
                    IP = new IPEndPoint(IPAddress.Any, 6000);
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                }
            });
            listenMain.IsBackground = true;
            listenMain.Start();
        }
        void CloseConnect()
        {
            server.Close();
        }
        void Send(Socket client)
        {
            //if (mes != string.Empty)
            //    client.Send(Serialize(mes));
        }
        void Receive(object obj)
        {
            Socket client = obj as Socket;
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);

                    string message = (string)Deserialize(data);

                    AddMessage(message);
                }
            }
            catch
            {
                //
                clientList.Remove(client);
                client.Close();
            }

        }
        void AddMessage(string message)
        {
            //lsvMessage.Items.Add(new ListViewItem() { Text = message });
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

        private void frmServer_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseConnect();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Đóng tất cả kết nối đến Client !", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                foreach (Socket client in clientList)
                {
                    client.Send(Serialize("Close"));
                }
                CloseConnect();
                Connect();
            }
        }

        private void btnSendMessageToAll_Click(object sender, EventArgs e)
        {
            foreach (Socket client in clientList)
            {
                client.Send(Serialize("Bạn đã kết nối tới Server\n (Send Message to all)"));
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
        flag:
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {

                    try
                    {
                        using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
                        {
                            using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                            {
                                DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                                {
                                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                                });
                                DataTableCollection tableCollection = result.Tables;
                                DataTable data = tableCollection[0];
                                List<SinhVien> lsv = new List<SinhVien>();
                                foreach (DataRow row in data.Rows)
                                {
                                    SinhVien sv = new SinhVien(row);
                                    lsv.Add(sv);
                                }

                                string json = JsonConvert.SerializeObject(lsv);

                                foreach (Socket client in clientList)
                                {
                                    client.Send(Serialize(json));
                                }
                                MessageBox.Show("Đã gửi danh sách sinh viên dự thi tới Client\n" + ofd.FileName);
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("File không hợp lệ");
                        goto flag;
                    }
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            frmDSThi frm = new frmDSThi();
            flagfrmthi:
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.GetData() == null || frm.GetData().Rows.Count == 0) { MessageBox.Show("Danh sách trống"); goto flagfrmthi; };
                DataTable data = frm.GetData();
                List<SinhVien> lsv = new List<SinhVien>();
                foreach (DataRow row in data.Rows)
                {
                    lsv.Add(new SinhVien(row));
                }
                string json = JsonConvert.SerializeObject(lsv);

                foreach (Socket client in clientList)
                {
                    client.Send(Serialize(json));
                }
                MessageBox.Show("Đã gửi danh sách sinh viên dự thi tới Client");
            }
        }
    }
}
