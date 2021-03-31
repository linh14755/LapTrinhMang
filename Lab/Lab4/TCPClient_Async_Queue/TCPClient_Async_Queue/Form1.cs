using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCPClient_Async_Queue
{
    public partial class Form1 : Form
    {
        ClientProgram program;
        public Form1()
        {
            InitializeComponent();
            program = new ClientProgram();
            program.OnOutputData += Program_OnOutputData;
        }

        private void Program_OnOutputData(object sender, OutputEventArgs args)
        {
            SetText(args.Text);
        }

        public void SetText(string str)
        {
            lbMain.Items.Add(str);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            program.StartServer();
        }
    }
}
