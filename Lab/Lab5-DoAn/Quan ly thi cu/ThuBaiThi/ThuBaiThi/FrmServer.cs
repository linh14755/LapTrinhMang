using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using MayTinh;
using NetLib;
using System.Net;
using System.Net.Sockets;
using System.IO;
using NetLib;
using System.Diagnostics;
using ExcelDataReader;

namespace ThuBaiThi
{
    public partial class FrmServer : Form
    {

        ServerThread serverThread;
        Thread t, CommandProcessThread, threadDemLuiThoiGian;
        Thread copyDir;

        MangMayTinh mangMayTinh= new MangMayTinh();
        Thread threadXuatMayTinh;
        ArrayList DSDeThi = new ArrayList();

        DataTableCollection tableCollection;
        DataTable data;

        private void Form1_Load(object sender, EventArgs e)
        {
            
           serverThread = new ServerThread();
        }

        #region It Khi dung den

        public delegate void SetTextCallBack(string text);


        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void cmdConnect_Click(object sender, EventArgs e)
        {

        }
        public FrmServer()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox99_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmServer_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (t != null)
                t.Abort();
            
            serverThread.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void mnuSetIP_Click(object sender, EventArgs e)
        {
            
        }

        void NhapDanhSachIP()
        {
            FrmSetIP frmSetIP = new FrmSetIP();
            frmSetIP.ShowDialog();
            // mangMayTinh = serverThread.AddMayTinh("192.168.255.1", "192.168.255.60", "255.255.255.0");

            // this.MainGroupBox.Controls.Add(mangMayTinh);

            mangMayTinh = serverThread.AddMayTinh(StaticInfo.FirstIP, StaticInfo.LastIP, StaticInfo.SubnetMask);
            this.MainGroupBox.Controls.Clear();
            this.MainGroupBox.Controls.Add(mangMayTinh);
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
                                tableCollection = result.Tables;
                                data = tableCollection[0];
                                List<SinhVien> lsv = new List<SinhVien>();
                                foreach (DataRow row in data.Rows)
                                {
                                    SinhVien sv = new SinhVien(row);
                                    lsv.Add(sv);
                                }

                                serverThread.SendMessage(lsv);
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

        private void button11_Click(object sender, EventArgs e)
        {
           
        }

       

        #endregion

        

        private void cmdChon_Click(object sender, EventArgs e)
        {
           
            

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Send a message to all
            serverThread.SendCommand();
            MessageBox.Show("'Hello Cient' đã được gửi đi");
        }

        private void DisableAllControl()
        { 
        
        }

        private void button8_Click(object sender, EventArgs e)
        {
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
           
        }

        private void cmdGoiDeThi_Click(object sender, EventArgs e)
        {
            
        }

        private void cmdBatDauLamBai_Click(object sender, EventArgs e)
        {

        }



        private void txtServerPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmdChonClientPath_Click(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cmdKichHoatAllClient_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
        }


       

       

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FrmDSThi frm = new FrmDSThi();
        flagfrmthi:
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.GetData() == null || frm.GetData().Rows.Count == 0) { MessageBox.Show("Danh sách trống"); goto flagfrmthi; };
                data = frm.GetData();
                serverThread.SendMessage(data);
                MessageBox.Show("Đã gửi danh sách sinh viên dự thi tới Client");
            }
        }

        private void cmdNhapVungIP_Click(object sender, EventArgs e)
        {
            NhapDanhSachIP();
        }

        
    }
}