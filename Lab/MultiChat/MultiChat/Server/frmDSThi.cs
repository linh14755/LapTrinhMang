using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class frmDSThi : Form
    {
        DataTable data;
        public frmDSThi()
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
