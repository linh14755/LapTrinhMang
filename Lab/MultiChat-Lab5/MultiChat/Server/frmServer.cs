﻿using Common;
using ExcelDataReader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using MayTinh;

namespace Server
{
    public partial class frmServer : Form
    {
        IPEndPoint IP;
        Socket server;
        Thread listenMain;
        Thread receive;
        List<Socket> clientList;
        List<String> listIP;
        List<MayTinh.MayTinh> mangmaytinh;
        string serverPath, clientPath;


        Brush CDisconnected = Brushes.Red;
        Brush CConnected = Brushes.Blue;

        int counter = 0;
        System.Timers.Timer countdown;
        public frmServer()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            btnDisconnect.Enabled = false;
            cmdBatDauLamBai.Enabled = false;
            mangmaytinh = new List<MayTinh.MayTinh>();
            Connect();

            countdown = new System.Timers.Timer();
            countdown.Elapsed += Countdown_Elapsed;
            countdown.Interval = 1000;

            serverPath = txtServerPath.Text;
            clientPath = txtClientPath.Text;
        }


        //Thêm Socket vào list
        void AddList(Socket s)
        {
            clientList.Add(s);
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

                        ReloadControl(client, CConnected);

                        receive = new Thread(Receive);
                        receive.IsBackground = true;
                        receive.Start(client);
                    }
                }
                catch
                {
                    IP = new IPEndPoint(IPAddress.Any, 6000);
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                }
            });

            listenMain.IsBackground = true;
            listenMain.Start();
        }
        void ReloadControl(Socket client, Brush color)
        {
            if (mangmaytinh.Count > 0)
            {
                var ipEP = ((IPEndPoint)(client.RemoteEndPoint)).Address.ToString();
                for (int i = 0; i < mangmaytinh.Count; i++)
                {
                    if (mangmaytinh[i].IP == ipEP)
                    {
                        mangmaytinh[i].TextPhiaDuoi = GetHostName(ipEP);
                        mangmaytinh[i].MauManHinh = color;
                        flpMain.Controls[i].Controls.Clear();
                        flpMain.Controls.Add(mangmaytinh[i]);
                        flpMain.Controls.SetChildIndex(mangmaytinh[i], i);
                    }
                }
            }
        }
        void CloseConnect()
        {
            if (server != null)
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
                    byte[] buffer = new byte[1024 * 5000 * 20];
                    client.Receive(buffer);

                    object data = Deserialize(buffer);
                    ServerResponse container = data as ServerResponse;

                    switch (container.Type)
                    {
                        case ServerResponseType.SendFile:
                            FileResponse fileResponse = container.Data as FileResponse;
                            string fileName = fileResponse.FileInfo.Name;
                            string filePath = serverPath + @"\" + fileName;


                            if (!File.Exists(filePath))
                            {
                                using (FileStream fileStream = File.Create(filePath))
                                {
                                    fileStream.Write(fileResponse.FileContent, 0, fileResponse.FileContent.Length);
                                }
                                AddMessage(client.RemoteEndPoint.ToString() + ": bài thi được đã nộp " + filePath);
                            }

                            break;

                        case ServerResponseType.SendList:

                            break;

                        case ServerResponseType.SendStudent:
                            SinhVien sv = container.Data as SinhVien;
                            AddMessage(client.RemoteEndPoint.ToString() + ": Thông tin sinh viên đang thao tác trên máy: " + sv.FullNameAndId);
                            if (mangmaytinh.Count > 0)
                            {
                                var ipEP = ((IPEndPoint)(client.RemoteEndPoint)).Address.ToString();
                                for (int i = 0; i < mangmaytinh.Count; i++)
                                {
                                    if (mangmaytinh[i].IP == ipEP)
                                    {
                                        mangmaytinh[i].TextPhiaDuoi = GetHostName(ipEP);
                                        mangmaytinh[i].TextTren = sv.Ten;
                                        flpMain.Controls[i].Controls.Clear();
                                        flpMain.Controls.Add(mangmaytinh[i]);
                                        flpMain.Controls.SetChildIndex(mangmaytinh[i], i);
                                    }
                                }
                            }

                            break;

                        case ServerResponseType.SendString:
                            AddMessage(client.RemoteEndPoint.ToString() + ": " + container.Data.ToString() + " đã kết nối tới !");
                            ReloadControl(client, CConnected);
                            break;

                        case ServerResponseType.BeginExam:
                            break;

                        case ServerResponseType.FinishExam:
                            break;

                        case ServerResponseType.LockClient:
                            break;

                        default:
                            break;
                    }
                }
            }
            catch
            {
                AddMessage(client.RemoteEndPoint + ": đóng kết nối. ");
                ReloadControl(client, CDisconnected);

                client.Close();
                clientList.Remove(client);
            }

        }
        void AddMessage(string message)
        {
            lsvMain.Items.Add(new ListViewItem() { Text = message });
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
                foreach (var client in clientList)
                {
                    ReloadControl(client, CDisconnected);
                }

                ServerResponse container = new ServerResponse();
                container.Type = ServerResponseType.LockClient;

                SendAll(container, "đóng kết nối");
            }
        }

        private void btnSendMessageToAll_Click(object sender, EventArgs e)
        {
            ServerResponse container = new ServerResponse();
            container.Type = ServerResponseType.SendString;
            container.Data = "Hello Client";


            SendAll(container, "message");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            List<SinhVien> lsv = new List<SinhVien>();

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


                                foreach (DataRow row in data.Rows)
                                {
                                    SinhVien sv = new SinhVien(row);
                                    lsv.Add(sv);
                                }
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi File.");
                    }
                }
            }

            ServerResponse container = new ServerResponse();
            container.Type = ServerResponseType.SendList;
            container.Data = lsv;

            SendAll(container, "danh sách sinh viên");
        }

        void SendAll(object container, string sendinfo = null)
        {
            byte[] buffer = Serialize(container);

            foreach (Socket client in clientList)
            {
                try
                {
                    client.Send(buffer);
                    AddMessage(client.RemoteEndPoint.ToString() + ": " + "Đã gửi " + sendinfo + " thành công");
                }
                catch (Exception)
                {
                    AddMessage(client.RemoteEndPoint.ToString() + ": " + "Đã xảy ra sự cố trong quá trình gửi " + sendinfo + ". Đã đóng kết nối");

                    clientList.Remove(client);
                    client.Close();
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            frmDSThi frm = new frmDSThi();
            try
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {

                    if (frm.GetData() == null || frm.GetData().Rows.Count == 0) { MessageBox.Show("Danh sách trống."); return; };
                    DataTable data = frm.GetData();
                    List<SinhVien> lsv = new List<SinhVien>();
                    foreach (DataRow row in data.Rows)
                    {
                        lsv.Add(new SinhVien(row));
                    }
                    ServerResponse container = new ServerResponse();
                    container.Type = ServerResponseType.SendList;
                    container.Data = lsv;

                    SendAll(container, "danh sách sinh viên");
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "All files (*.*)|*.*" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        lstDeThi.Items.Add(ofd.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Thêm file thất bại.\n" + ex);
                    }
                }
            }
        }

        private void lstDeThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstDeThi.SelectedItem != null)
                lbFilePath.Text = lstDeThi.SelectedItem.ToString();
        }

        private void cmdChapNhan_Click(object sender, EventArgs e)
        {
            if (lstDeThi.SelectedItem != null && txtMonThi != null && txtThoiGianLamBai != null && clientList.Count > 0)
            {
                //Send đề
                //Send Thời gian làm bài và môn thi
                if (lstDeThi.SelectedItem != null)
                {
                    try
                    {
                        ServerResponse container = new ServerResponse();   

                        container.Type = ServerResponseType.ExamSubjectsAndTime;
                        container.Data = txtMonThi.Text + "^" + txtThoiGianLamBai.Text + "^" + clientPath;
                        SendAll(container, "môn thi và thời gian làm bài");


                        FileResponse file = new FileResponse(lstDeThi.SelectedItem.ToString());
                        container.Type = ServerResponseType.SendFile;
                        container.Data = file;
                        SendAll(container, "đề thi");

                        cmdBatDauLamBai.Enabled = true;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi trong quá trình gửi file.\n" + ex);
                    }
                }
            }
            else MessageBox.Show("Lỗi trong quá trình gửi file.");

        }

        private void cmdBatDauLamBai_Click(object sender, EventArgs e)
        {
            if (txtThoiGianLamBai.Text != string.Empty && clientList.Count > 0)
            {
                int minute = Convert.ToInt32(txtThoiGianLamBai.Text);
                countdown.Enabled = true;

                counter = minute * 60;

                ServerResponse container = new ServerResponse();
                container.Type = ServerResponseType.BeginExam;
                container.Data = minute;

                SendAll(container, "thời gian làm bài");
            }
        }

        private void Countdown_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            counter -= 1;
            int minute = counter / 60;
            int second = counter % 60;

            lbCountdown.Text = minute + ":" + second;

            if (counter == 0)
            {
                countdown.Stop();
                AddMessage("Đã hết thời gian làm bài");
                cmdChapNhan.Enabled = true;
                cmdBatDauLamBai.Enabled = true;
            }
        }

        private void cmdNhapVungIP_Click(object sender, EventArgs e)
        {
            frmSetIP frmSetIP = new frmSetIP();
            frmSetIP.ShowDialog();

            listIP = InitIpRange(StaticInfo.FirstIP, StaticInfo.LastIP, StaticInfo.SubnetMask);
            mangmaytinh = new List<MayTinh.MayTinh>();
            foreach (string ip in listIP)
            {
                MayTinh.MayTinh mt = new MayTinh.MayTinh();
                mt.IP = ip;
                mt.TextPhiaDuoi = ip;
                foreach (var client in clientList)
                {
                    var ipEP = ((IPEndPoint)(client.RemoteEndPoint)).Address.ToString();
                    if (ipEP == ip) mt.MauManHinh = CConnected;
                }
                mangmaytinh.Add(mt);
            }
            AddPCToControls(mangmaytinh);
        }

        void AddPCToControls(List<MayTinh.MayTinh> mangmaytinh)
        {
            flpMain.Controls.Clear();
            foreach (var mt in mangmaytinh)
            {
                flpMain.Controls.Add(mt);
            }
        }

        public List<String> InitIpRange(string FirstIP, string LastIP, string SubnetMask)
        {
            List<String> listIP = new List<String>();
            try
            {
                string s1 = "", s2 = "";
                int y = 0, x = 0, z = 0, t = 0;
                if (FirstIP != "")
                {
                    s1 = FirstIP.Substring(0, FirstIP.LastIndexOf("."));
                    x = int.Parse(FirstIP.Substring(FirstIP.LastIndexOf(".") + 1));
                }
                if (LastIP != "")
                {
                    s2 = LastIP.Substring(0, LastIP.LastIndexOf("."));
                    y = int.Parse(LastIP.Substring(LastIP.LastIndexOf(".") + 1));
                }
                t = y - x;
                if (SubnetMask != "")
                    z = 256 - int.Parse(SubnetMask.Substring(SubnetMask.LastIndexOf(".") + 1));
                if (x < 255 && y < 255 && s1.CompareTo(s2) == 0)
                    listIP = XuatIP(x, y, z, s1);
                else
                    MessageBox.Show("Nhập sai");
            }
            catch
            {
                MessageBox.Show("Nhập IP sai");
            }
            return listIP;
        }

        public List<String> XuatIP(int batdau, int cuoi, int chieudai, string vungiptruoc = "192.168.255.")
        {
            List<String> tam = new List<String>();
            for (int i = batdau; i < chieudai && i <= cuoi; i++)
            {
                string ip = vungiptruoc + "." + i.ToString();

                tam.Add(ip);
            }
            return tam;
        }

        private void cmdChon_Click(object sender, EventArgs e)
        {
            try
            {
                serverPath = txtServerPath.Text;
                if (!Directory.Exists(serverPath))
                {
                    Directory.CreateDirectory(serverPath);
                }
                MessageBox.Show("Bài thi sẽ được lưu ở " + serverPath, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (mangmaytinh.Count > 0)
            {
                List<MayTinh.MayTinh> lmaytinh = new List<MayTinh.MayTinh>();
                foreach (var mt in mangmaytinh)
                {
                    if (mt.TextTren != "Name") lmaytinh.Add(mt);
                }

                mangmaytinh = lmaytinh;
                AddPCToControls(mangmaytinh);
            }
        }
    }
}

