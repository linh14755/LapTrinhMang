using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Server
{
    public class SinhVien
    {
        int mssv;
        string ten;
        string lop;
        public SinhVien() { }
        public SinhVien(int mssv, string ten,string lop)
        {
            this.mssv = mssv;
            this.ten = ten;
            this.lop = lop;
        }
        public SinhVien(DataRow row)
        {
            this.mssv = int.Parse(row["mssv"].ToString());
            this.ten = row["ten"].ToString();
            this.lop = row["lop"].ToString();
        }

        public int Mssv { get => mssv; set => mssv = value; }
        public string Ten { get => ten; set => ten = value; }
        public string Lop { get => lop; set => lop = value; }
    }
}
