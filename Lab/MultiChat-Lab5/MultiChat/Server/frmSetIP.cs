using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;

namespace Server
{
    public partial class frmSetIP : Form
    {
        public frmSetIP()
        {
            InitializeComponent();
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            if (this.txtIP.Text.IndexOf('-') == -1)
                MessageBox.Show("Địa chỉ IP không hợp lệ");
            else
            {
                string[] arrayIP = this.txtIP.Text.Split('-');
                StaticInfo.FirstIP = arrayIP[0].Trim();
                StaticInfo.LastIP = arrayIP[1].Trim();
                StaticInfo.SubnetMask = this.txtSubnetMask.Text.Trim();
                this.Close();
            }
        }
    }
}
