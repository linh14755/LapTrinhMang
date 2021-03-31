using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

 namespace TCPServer_Async_Queue
{
    public partial class Form1 : Form
    {
        ServerProgram program;
        public Form1()
        {
            InitializeComponent();
            program = new ServerProgram();
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
            btnStart.Enabled = false;
            program.StartServer();
        }
    }
}
