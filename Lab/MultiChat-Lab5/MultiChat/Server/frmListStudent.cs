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
    public partial class frmListStudent : Form
    {
        public frmListStudent()
        {
            InitializeComponent();
        }
        public void SetList(List<string> listClientAndIdStudent)
        {
            lvMain.Items.Clear();
            if(listClientAndIdStudent != null)
            {
                foreach (var item in listClientAndIdStudent)
                {
                    lvMain.Items.Add(item);
                }
            }
        }
    }
}
