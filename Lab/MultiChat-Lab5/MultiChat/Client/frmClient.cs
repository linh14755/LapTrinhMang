﻿using System;
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
using Common;

namespace Client
{
    public partial class frmClient : Form
    {
        IPEndPoint IP;
        Socket client;
        Thread listenMain;
        List<SinhVien> lsv;

        int counter = 0;
        System.Timers.Timer countdown;
        public frmClient()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            countdown = new System.Timers.Timer();
            countdown.Elapsed += Countdown_Elapsed;
            countdown.Interval = 1000;

            cmdNopBaiThi.Enabled = false;
        }


        void Connect(string ipserver)
        {
            IP = new IPEndPoint(IPAddress.Parse(ipserver), 6000);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


            try
            {
                client.Connect(IP);
                string tenMay = System.Environment.MachineName;
                MessageBox.Show("Đã kết nối tới - " + GetHostName(ipserver), "Thông báo", MessageBoxButtons.OK);
                this.Text = GetHostName(ipserver) + " - đã kết nối tới";
                cmdKetNoi.Enabled = false;

                ServerResponse container = new ServerResponse();
                container.Type = ServerResponseType.SendString;
                container.Data = tenMay;
                Send(container);

            }
            catch
            {
                MessageBox.Show("Không thể kết nối server!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmdKetNoi.Enabled = true;
                cmdChapNhan.Enabled = true;
                this.Text = "Client";
                CloseConnect();
            }

            listenMain = new Thread(Receive);
            listenMain.IsBackground = true;
            listenMain.Start();
        }
        void CloseConnect()
        {
            if (client != null) client.Close();
        }
        void Send(object obj)
        {
            client.Send(Serialize(obj));
        }
        void Receive()
        {
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
                            string filePath = @"D:\" + fileName;
                            lblDeThi.Text = filePath;


                            if (!File.Exists(filePath))
                            {
                                using (var fileStream = File.Create(filePath))
                                {
                                    fileStream.Write(fileResponse.FileContent, 0, fileResponse.FileContent.Length);
                                }
                            }
                            break;

                        case ServerResponseType.SendList:
                            List<SinhVien> listStudent = container.Data as List<SinhVien>;
                            cbDSThi.DataSource = listStudent;
                            cbDSThi.DisplayMember = "FullNameAndId";
                            break;

                        case ServerResponseType.SendStudent:
                            break;

                        case ServerResponseType.SendString:
                            MessageBox.Show(container.Data.ToString());
                            break;

                        case ServerResponseType.BeginExam:
                            counter = (int)container.Data * 60;
                            lblThoiGian.Text = counter / 60 + " phút";
                            countdown.Enabled = true;
                            MessageBox.Show("Bắt đầu làm bài", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;

                        case ServerResponseType.FinishExam:
                            break;

                        case ServerResponseType.LockClient:
                            break;
                        case ServerResponseType.ExamSubjectsAndTime:
                            string[] s = container.Data.ToString().Split('^');
                            lblMonThi.Text = s[0];
                            lblThoiGian.Text = s[1] + " phút";
                            lblThoiGianConLai.Text = s[1] + " phút";
                            break;

                        case ServerResponseType.CloseConnect:
                            CloseConnect();
                            break;
                        default:
                            break;
                    }
                }
            }
            catch
            {
                cmdKetNoi.Enabled = true;
                cmdChapNhan.Enabled = true;
                this.Text = "Client";
                MessageBox.Show("Có lỗi xảy ra trong quá trình nhận phản hồi từ server. Đóng kết nối. ");
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
            //Send();
            //AddMessage(txbMessage.Text);

        }

        private void cmdKetNoi_Click(object sender, EventArgs e)
        {
            Connect(txtKetNoi.Text);

        }

        private void cbDSThi_Click(object sender, EventArgs e)
        {

        }

        private void lblDeThi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string path = Path.GetDirectoryName(lblDeThi.Text);
            System.Diagnostics.Process.Start("explorer.exe", path);
        }

        private void cmdChapNhan_Click(object sender, EventArgs e)
        {
            if (cbDSThi.SelectedItem != null)
            {
                SinhVien sv = cbDSThi.SelectedItem as SinhVien;

                ServerResponse container = new ServerResponse() { Type = ServerResponseType.SendStudent, Data = sv };
                try
                {
                    Send(container);
                    //cmdChapNhan.Enabled = false;
                    MessageBox.Show("Đã gửi thông tin sinh viên lên server.");


                }
                catch
                {
                    CloseConnect();
                    cmdKetNoi.Enabled = true;
                    cmdChapNhan.Enabled = true;
                    this.Text = "Client";
                    MessageBox.Show("Có lỗi trong quá trình gửi thông tin sinh viên lên server");
                }
            }
        }
        private void Countdown_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            counter -= 1;

            int second = counter % 60;
            int minute = counter / 60;

            lblThoiGianConLai.Text = minute + " phút " + second + " giây";

            //Mỗi 30 phút nhắc lại một lần
            if (counter >= 1800 && counter % 1800 == 0)
            {
                MessageBox.Show("Bạn còn " + minute + " phút để làm bài, hiện tại bạn có thể nộp bài.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (counter <= 1800) cmdNopBaiThi.Enabled = true;

            //Còn 5 phút cuối
            if (counter == 300)
            {
                MessageBox.Show("Bạn còn " + minute + " phút để làm bài, hãy nén file thành dạng .rar và nộp bài nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            if (counter == 0)
            {
                countdown.Stop();
                //Thu bài theo thư mục hiện tạo và gửi về server
                FileResponse file = new FileResponse(@"D:\1812790_NguyenKhanhLinh.rar");

                ServerResponse container = new ServerResponse();
                container.Type = ServerResponseType.SendFile;
                container.Data = file;
                Send(container);
                MessageBox.Show("Đã hết thời gian làm bài", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cbDSThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDSThi.SelectedItem != null)
            {
                var sv = cbDSThi.SelectedItem as SinhVien;
                lblHoTen.Text = sv.Ten;
                lblMaSo.Text = sv.Mssv.ToString();
            }
        }

        private void cmdNopBaiThi_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(@"Bài hiện tại được lấy từ D:\", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "All files (*.*)|*.*" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        FileResponse file = new FileResponse(ofd.FileName);
                        ServerResponse container = new ServerResponse();
                        container.Type = ServerResponseType.SendFile;
                        container.Data = file;
                        Send(container);
                        countdown.Stop();
                        MessageBox.Show("Bài đã được nộp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cmdNopBaiThi.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Thêm file thất bại.\n" + ex);
                    }
                }
            }
        }
    }
}
