using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
	

namespace MayTinh
{
    public partial class MangMayTinh : UserControl
    {
        private int chieRong;

        public int ChieuRong
        {
            get { return chieRong; }
            set { chieRong = value; }
        }

        private int chieuCao;

        public int ChieuCao
        {
            get { return chieuCao; }
            set { chieuCao = value; }
        }

        private int chieuRongMayTinh = new MayTinh().ChieuRongMayTinh;

        public int ChieuRongMayTinh
        {
            get { return chieuRongMayTinh; }
            set { chieuRongMayTinh = value; }
        }

        private int chieuCaoMayTinh = new MayTinh().ChieuCaoMayTinh;

        public int ChieuCaoMayTinh
        {
            get { return chieuCaoMayTinh; }
            set { chieuCaoMayTinh = value; }
        }

        private ArrayList danhSachMayTinh;

        public ArrayList DanhSachMayTinh
        {
            get { return danhSachMayTinh; }
            set { danhSachMayTinh = value; }
        }


        public MayTinh this[int Index]
        {
            get
            {
                return (MayTinh)this.DanhSachMayTinh[Index];
            }
            set
            {
                this.DanhSachMayTinh[Index] = value;
            }
        }


        public MangMayTinh()
        {
            InitializeComponent();
        }

        public MangMayTinh(ArrayList DanhSachMayTinh):this()
        {
            this.DanhSachMayTinh = DanhSachMayTinh;
            int x = 0;

            int y = 0;
            if (SoLuongMay() > 0)
            {
                for (int i = 0; i < SoLuongMay(); i++)
                {
                    this[i].Location = new Point(x, y);
                    this.Controls.Add(this[i]);

                    if (x < this.Height - this.ChieuRongMayTinh)
                    {

                        x += this.ChieuRongMayTinh + 10;
                    }
                    else
                    {
                        x = 0;
                        y += ChieuCaoMayTinh + 10;

                    }

                   
                }
            }

           
        }

        public ArrayList RangeIP()
        {
            ArrayList listIP = new ArrayList();
            //string[] parts = listIP[0].ToString().Split('.');
            //string firstIPPart = parts[0] + "." + parts[1] + "." + parts[2] + ".";
            //for (int i = 0; i < listIP.Count; i++)
            //{
            //    listIP.Add(firstIPPart + ((int)(int.Parse(parts[3]) + i)).ToString());
            //}
            return listIP;
        }

        public MayTinh GetMayTinh(string IP)
        {
            foreach (MayTinh mt in this.DanhSachMayTinh)
            {
                if (mt.IP == IP)
                    return mt;
            }
            return null;
            
        }

        public bool SetStatusClientConnected(string IP)
        { 
            MayTinh mt = GetMayTinh(IP);
            if (mt != null)
            {
                mt.MauManHinh = Brushes.Red;
                
                return true;
            }
            return false;

        }

        public bool SetPort(string IP, int Port)
        {
            MayTinh mt = GetMayTinh(IP);
            if (mt != null)
            {
                mt.Port = Port;
                
                return true;
            }
            return false;
        }

        private void MangMayTinh_Load(object sender, EventArgs e)
        {
            

        }

        private int SoLuongMay()
        {
            return (this.DanhSachMayTinh !=null) ? this.DanhSachMayTinh.Count : 0;
        }
    }
}
