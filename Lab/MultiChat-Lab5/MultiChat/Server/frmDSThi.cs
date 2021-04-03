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
            try
            {
                cbbLop.Items.Clear();
                var data = DataProVider.instance.ExcuteQuery("select * from dslop");
                cbbLop.DataSource = data;
                cbbLop.DisplayMember = "Lop";
                cbbLop.ValueMember = "Lop";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }
        public DataTable GetData()
        {
            return data;
        }

        private void cbbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = string.Format("select * from SinhVien where Lop = '{0}'", cbbLop.SelectedValue.ToString());
            data = DataProVider.instance.ExcuteQuery(query);
            dgvDSSV.DataSource = data;
        }
    }
}
