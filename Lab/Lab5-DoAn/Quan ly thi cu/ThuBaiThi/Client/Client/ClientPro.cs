using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Collections;
using NetLib;
using System.Windows.Forms;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Client
{
    class ClientPro
    {
        Thread t, sendThread, receiveThread;
        public Queue outQueue = new Queue();
        public Queue inQueue = new Queue();
        public Queue inCommandQueue = new Queue();

        public Queue CommandQueue = new Queue();

        NetworkStream ns;
        StreamWriter sw;
        StreamReader sr;
        TcpClient client;
        private string Name = "";
        public string CurrDir = "";
        public string ClientPath = "";
        public string ServerPath = "";
        public string ServerShareName = "";

        SinhVien sv;
        List<SinhVien> lsv = new List<SinhVien>();


        public void Connect(string TenServer)
        {
            if (CheckIPValid(TenServer)) 
            {
                try
                {

                    client = new TcpClient(TenServer, 3000);
                    ns = client.GetStream();
                    sr = new StreamReader(ns);
                    sw = new StreamWriter(ns);

                    sendThread = new Thread(new ThreadStart(Send));
                    sendThread.Start();

                    receiveThread = new Thread(new ThreadStart(Receive));
                    receiveThread.Start();
                    inQueue.Enqueue("Ket noi thanh cong");
                    string tenmay = Dns.GetHostName();
                    CommandQueue.Enqueue(NetCommand.Connect + "-" + tenmay);

                    CommandQueue.Enqueue(NetCommand.StatusConnect + "-Thanh Cong");
                    MessageBox.Show(CommandQueue.Dequeue().ToString());

                }
                catch
                {
                    CommandQueue.Enqueue(NetCommand.StatusConnect + "-That Bai");
                    MessageBox.Show(CommandQueue.Dequeue().ToString());

                }
            }
            else MessageBox.Show("IP không hợp lệ");
        }

        public void SendMSSV(string MSSV)
        {
           
            CommandQueue.Enqueue(NetCommand.CombineCommandParam(NetCommand.MSSV, MSSV + '`' + Dns.GetHostName()));
        }

        public void GoiBaiThiLenServer()
        {
            string rarPath = Environment.CurrentDirectory + "\\rar.exe";
            IPEndPoint ep = (IPEndPoint)client.Client.RemoteEndPoint;
            string ServerDir = @"\\" + ep.Address.ToString() + @"\" +  ServerPath+ "\\" + CurrDir;
            string clientpath = ClientPath + "\\" + CurrDir;
            string command = "a " + ServerDir + "  " + clientpath;
            Process.Start(rarPath, command);
            
        }

        public void Send()
        {
            while (true)
            {

                if (CommandQueue.Count > 0)
                {
                    string s = CommandQueue.Dequeue().ToString();
                    

                    sw.WriteLine(s);
                    sw.Flush();
                }
                Thread.Sleep(100);
            }

        }

        public void Receive()
        {
            while (true)
            {

                string s = "";
                try
                {
                    s = sr.ReadLine();
                    inCommandQueue.Enqueue(s);
                    try
                    {
                        lsv = JsonConvert.DeserializeObject<List<SinhVien>>(s);
                    }
                    catch
                    {
                        MessageBox.Show("Nhan duoc phia server: " + s);
                    }
                }
                catch { }



                Thread.Sleep(100);
            }
        }



        public void InPut(string text)
        {
            outQueue.Enqueue(text);
            inQueue.Enqueue(text);

        }

        public void Close()
        {
            if (t != null)
                t.Abort();
            if (receiveThread != null)
                receiveThread.Abort();
            if (sendThread != null)
                sendThread.Abort();
            if (ns != null)
                ns.Close();
            if (sw != null)
                sw.Close();
            if (this.client != null)

                this.client.Close();
        }

        private bool KiemTraKhacNull(params object[] obs)
        {
            foreach (object ob in obs)
            {
                if (ob == null)
                    return false;
            }
            return true;
        }

        public void SendFinishSignal()
        {
            CommandQueue.Enqueue(NetCommand.CombineCommandParam(NetCommand.ClientFinish, Dns.GetHostName() ));
        }
        public Boolean CheckIPValid(String strIP)
        {
            try
            {
                //  Split string by ".", check that array length is 3
                char chrFullStop = '.';
                string[] arrOctets = strIP.Split(chrFullStop);
                if (arrOctets.Length != 4)
                {
                    return false;
                }
                //  Check each substring checking that the int value is less than 255 and that is char[] length is !> 2
                Int16 MAXVALUE = 255;
                Int32 temp; // Parse returns Int32
                foreach (String strOctet in arrOctets)
                {
                    if (strOctet.Length > 3)
                    {
                        return false;
                    }

                    temp = int.Parse(strOctet);
                    if (temp > MAXVALUE)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public List<SinhVien> GetLSV()
        {
            return lsv;
        }

    }
}
