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
    public partial class frmLockProgramList : Form
    {
        List<string> lprocess;
        public frmLockProgramList()
        {
            InitializeComponent();
            lprocess = new List<string>();
        }
        public void AddListView(string processname)
        {
            lstMain.Items.Add(processname);
            lprocess.Add(processname);
        }
        public List<string> GetListProgram()
        {
            return lprocess;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string fileName;
                dlg.Filter = "Exe Files (.exe)|*.exe|All Files (*.*)|*.*";

                fileName = dlg.FileName;
                AddListView(fileName);
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstMain.SelectedItem.ToString() !=null)
            {
                lprocess.Remove(lstMain.SelectedItem.ToString());
                lstMain.Items.Remove(lstMain.SelectedItem);
            }
        }
    }
}
