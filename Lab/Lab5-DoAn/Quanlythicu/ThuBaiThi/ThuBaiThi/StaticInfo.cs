using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;	

namespace ThuBaiThi
{
    class StaticInfo
    {
        public static string FirstIP = "";
        public static string LastIP = "";
        public static string SubnetMask = "";
        public static string Path = "";

        public static ArrayList ListDeThi = new ArrayList();


        public static bool DisableClient = true;

        public static ArrayList ListIPInRange()
        {
            ArrayList listIP = new ArrayList();
            string[] parts = FirstIP.Split('.');
            string firstIPPart = parts[0] + "." + parts[1] + "." + parts[2] + ".";
            for (int i = 0; i < CountIP(); i++)
            {
                listIP.Add(firstIPPart + ((int)(int.Parse(parts[3]) + i)).ToString());
            }
            return listIP;
        }

        public static int CountIP()
        {
            string[] ip1 = FirstIP.Split('.');
            string[] ip2 = LastIP.Split('.');
            int firstIndex = int.Parse(ip1[3]);
            int lastIndex = int.Parse(ip2[3]);
            return lastIndex - firstIndex;
        }
        

    }
}
