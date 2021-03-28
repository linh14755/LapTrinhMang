using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using ThuBaiThi;


namespace MayTinh
{
    public partial class MayTinh : UserControl
    {
        const double TiLeManHinhVaChan = 0.7;
        private Brush mauManHinh = Brushes.Blue;
        public static Queue CommandQueue = new Queue();


        public Brush MauManHinh
        {
            get
            {
                return mauManHinh;
            }
            set
            {
                mauManHinh = value;
            }
        }

        private string ip;

        public string IP
        {
            get { return ip; }
            set { ip = value; }
        }


        private int port;

        public int Port
        {
            get { return port; }
            set { port = value; }
        }

      
        private int chieuCaoManHinh;

        public int ChieuCaoManHinh
        {
            get 
            {
                chieuCaoManHinh = LayTiLe(this.Height, TiLeManHinhVaChan); 
                return chieuCaoManHinh; 
            }
            set { chieuCaoManHinh = value; }
        }

        private int chieuRongManHinh;

        public int ChieuRongManHinh
        {
            get 
            {
                chieuRongManHinh = this.Width - 1;    
                return chieuRongManHinh; 
            }
            set { chieuRongManHinh = value; }
        }

        private string textTren = "Name";

        public string TextTren
        {
            get { return textTren; }
            set { textTren = value; }
        }

        private string textPhiaDuoi = "0313769";

        public string TextPhiaDuoi
        {
            get { return textPhiaDuoi; }
            set { textPhiaDuoi = value; }
        }
        

        private int offsetChanMayTinh = 10;

        public int OffsetChanMayTinh
        {
            get { return offsetChanMayTinh; }
            set { offsetChanMayTinh = value; }
        }
        private int offsetManHinh = 3;

        public int OffsetManHinh
        {
            get { return offsetManHinh; }
            set { offsetManHinh = value; }
        }

        private Color mauChan;

        public Color MauChan
        {
            get { return mauChan; }
            set { mauChan = value; }
        }

        private Color mauVien;

        public Color MauVien
        {
            get { return mauVien; }
            set { mauVien = value; }
        }



        private int chieuDaiMayTinh;

        public int ChieuDaiMayTinh
        {
            get { return chieuDaiMayTinh; }
            set { chieuDaiMayTinh = value; }
        }

        private Brush mauChuTren = Brushes.Yellow;

        public Brush MauChuTren
        {
            get { return mauChuTren; }
            set { mauChuTren = value; }
        }

        private Brush mauChuDuoi = Brushes.Blue;

        public Brush MauChuDuoi
        {
            get { return mauChuDuoi; }
            set { mauChuDuoi = value; }
        }

        private Brush vienBrush;

        public Brush VienBrush
        {
            get { return vienBrush; }
            set { vienBrush = value; }
        }

        private Point diemDauChanPhai;

        public Point DiemDauChanPhai
        {
            get 
            {
                diemDauChanPhai.X = ChieuRongManHinh -  OffsetChanMayTinh;
                diemDauChanPhai.Y = LayTiLe(ChieuCaoMayTinh, TiLeManHinhVaChan) + 1;
                return diemDauChanPhai; 
            }
            set { diemDauChanPhai = value; }
        }

        private Point diemDauChanTrai;

        public Point DiemDauChanTrai
        {
            get 
            {
                diemDauChanTrai.X = OffsetChanMayTinh;
                diemDauChanTrai.Y = LayTiLe(ChieuCaoMayTinh, TiLeManHinhVaChan) + 1;
                return diemDauChanTrai; 
            }
            set { diemDauChanTrai = value; }
        }

        private Color mauVienChan = Color.Red;

        public Color MauVienChan
        {
            get { return mauVienChan; }
            set { mauVienChan = value; }
        }

        private Point diemCuoiChanPhai;

        public Point DiemCuoiChanPhai
        {
            
            get 
            {
                diemCuoiChanPhai.X = ChieuRongManHinh;
                diemCuoiChanPhai.Y = ChieuCaoMayTinh;
                return diemCuoiChanPhai; 
            }
            set { diemCuoiChanPhai = value; }
        }

        private int chieuCaoMayTinh;

        public int ChieuCaoMayTinh
        {
            get 
            {
                chieuCaoMayTinh = this.Height - 1;
                return chieuCaoMayTinh;
            }
            set { chieuCaoMayTinh = value; }
        }

        private int chieuRongMayTinh;

        public int ChieuRongMayTinh
        {
            get 
            {
                chieuRongMayTinh = this.Width - 1;
                return chieuRongMayTinh; 
            }
            set { chieuRongMayTinh = value; }
        }

        private bool hieuLuc = false;

        public bool HieuLuc
        {
            get { return hieuLuc; }
            set { hieuLuc = value; }
        }


        private Point diemCuoiChanTrai;

        public Point DiemCuoiChanTrai
        {
            get
            {
                diemCuoiChanTrai.X = 0;
                diemCuoiChanTrai.Y = ChieuCaoMayTinh;
                return diemCuoiChanTrai; 
            }
            set { diemCuoiChanTrai = value; }
        }




        private int LayTiLe(int ChieuDai, double TiLe)
        {
            return (int)(((double)ChieuDai) * TiLe);
        }

        private int LayTiLe(int ChieuDai, int Tu, int Mau)
        {
            return ChieuDai * Tu / Mau;
        }

        

        public MayTinh()
        {
            InitializeComponent();
        }

        private void MayTinh_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.DrawRectangle(new Pen(Brushes.Blue), 0, 0, ChieuRongManHinh, ChieuCaoManHinh);
            VeHinhTrong(g, Color.Blue);
            VeChan(g);
            
            

        }

        private void VeHinhTrong(Graphics g, Color MauNen)
        {
            g.DrawRectangle(new Pen(MauNen), offsetManHinh, OffsetManHinh, ChieuRongManHinh - 2 * OffsetManHinh, ChieuCaoManHinh - 2 * OffsetManHinh);
            g.FillRectangle(MauManHinh, OffsetManHinh, OffsetManHinh, ChieuRongManHinh - 2 * OffsetManHinh, ChieuCaoManHinh - 2 * OffsetManHinh);
            g.DrawString(TextTren, new Font("Arial", 12), MauChuTren, new PointF(5, ChieuCaoManHinh / 2 - 9));
        }

        private void VeChan(Graphics g)
        {
            g.DrawLine(new Pen(MauVienChan), DiemDauChanPhai, DiemCuoiChanPhai);
            g.DrawLine(new Pen(MauVienChan), DiemDauChanTrai, DiemCuoiChanTrai);
            g.DrawLine(new Pen(MauVienChan), DiemCuoiChanTrai, DiemCuoiChanPhai);
            int fontSize = ChieuCaoMayTinh - ChieuCaoManHinh;
            fontSize = fontSize / 2;
            g.DrawString(TextPhiaDuoi, new Font("Arial", fontSize), MauChuDuoi, new PointF(8, ChieuCaoMayTinh - 13));                

        }

        private void MayTinh_Click(object sender, EventArgs e)
        {
            
        }

        private void MayTinh_Load(object sender, EventArgs e)
        {
            
        }

        private void sendMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void disableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

    }
}
