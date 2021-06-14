using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;

namespace Server
{
    public partial class frmListStudent : Form
    {
        string serverPath;
        List<string> listClientAndIdStudent;
        public frmListStudent()
        {
            InitializeComponent();
            serverPath = "";
            listClientAndIdStudent = new List<string>();

        }
        public void SetFilepath(string path)
        {
            this.serverPath = path;
        }
        public void SetList(List<string> listClientAndIdStudent)
        {
            lvMain.Items.Clear();
            if (listClientAndIdStudent != null)
            {
                foreach (var item in listClientAndIdStudent)
                {
                    lvMain.Items.Add(item);
                    //var s = item.Split('-');
                    //SinhVien sv = new SinhVien() { Mssv = int.Parse(s[0]), Ten = s[1].ToString(), Lop = s[2].ToString() };

                }
            }
        }

        private void btnPrintf_Click(object sender, EventArgs e)
        {
            string path = serverPath + @"\DanhSachDuThi.txt";

            if (!Directory.Exists(serverPath))
            {
                Directory.CreateDirectory(serverPath);
            }
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    foreach (var item in listClientAndIdStudent)
                    {
                        sw.WriteLine(item);
                    }
                    MessageBox.Show("Ghi danh sách điểm danh ra: " + path);
                }
            }
        }
    }
}
