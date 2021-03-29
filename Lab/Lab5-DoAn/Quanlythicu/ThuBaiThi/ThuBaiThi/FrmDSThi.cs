using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ThuBaiThi
{
    public partial class FrmDSThi : Form
    {
        DataTable data;
        public FrmDSThi()
        {
            InitializeComponent();
            LoadSCDL();
        }

        private void LoadSCDL()
        {
            cbbLop.Items.Clear();
            var data = DataProVider.instance.ExcuteQuery("select * from dslop");
            foreach (DataRow row in data.Rows)
            {
                cbbLop.Items.Add(row["lop"].ToString());
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadSCDL();
        }
        public DataTable GetData()
        {
            return data;
        }

        private void cbbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = string.Format("select * from SinhVien where Lop = '{0}'", cbbLop.SelectedItem.ToString());
            data = DataProVider.instance.ExcuteQuery(query);
            dgvDSSV.DataSource = data;
        }
    }
}
