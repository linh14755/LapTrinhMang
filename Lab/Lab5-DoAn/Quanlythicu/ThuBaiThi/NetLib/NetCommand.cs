using System;
using System.Collections.Generic;
using System.Text;

namespace NetLib
{
 

    public class NetCommand
    {
        public const  string Connect = "Connect";
        public const string StatusConnect = "StatusConnect";
        public const string SendMessageToClient = "SendMessageToClient";
        public const string EnableClient = "EnableClient";
        public const string GetMonThi = "GetMonThi";
        public const string GetThoiGianLamBai = "GetThoiGianLamBai";
        public const string SendDSThi = "SendDSThi";
        public const string GoiDeThi = "GoiDeThi";
        public const string BatDauLamBai = "BatDauLamBai";
        public const string ClientPath = "ClientPath";
        public const string ServerPath = "ServerPath";
        public const string BatDauTinhThoiGian = "BatDauTinhThoiGian";


        public const string ClientFinish = "ClientFinish";
        public const string MSSV = "MSSV";




        public static string GetCommand(string ReceiveCommand)
        { 
            string[] temp = ReceiveCommand.Split('-');
            if (temp.Length != 2)
                return "";
            else
                return temp[0];
        }

        public static string GetParam(string ReceiveCommand)
        {
            string[] temp = ReceiveCommand.Split('-');
            if (temp.Length != 2)
                return "";
            else
                return temp[1];
        }

        public static string CombineCommandParam(string Command, string Param)
        {
            return Command + "-" + Param;
        }
    }

    
}
