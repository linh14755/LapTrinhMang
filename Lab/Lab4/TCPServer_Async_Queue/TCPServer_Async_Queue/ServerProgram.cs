using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Windows.Forms;

namespace TCPServer_Async_Queue
{
   public class ServerProgram
    {
        TcpClient client;
        Queue<string> inQueue;
        Thread mainThread;
        Queue<string> outQueue;
        Thread receveThread;
        Thread sendThread;
        TcpListener server;
        StreamReader sr;
        StreamWriter sw;
        public ServerProgram(Form1 f)
        {
            this.form = f;
        }
        public event OutputEventHandle OnOutputData;

        void SetTextFunc(string str)
        {
            form.SetText(str);
        }
        public void StartServer()
        {
            mainThread = new Thread(new ParameterizedThreadStart(Listen));
            mainThread.Start();
        }
        public void Listen(object obj)
        {
            server = new TcpListener(IPAddress.Parse("127.0.0.1"), 6666);
            server.Start();
            SetTextFunc("Dang cho client ket noi...");

            client = server.AcceptTcpClient();
            SetTextFunc(client.Client.RemoteEndPoint + ": da ket noi toi!");

            NetworkStream ns = client.GetStream();
            sr = new StreamReader(ns);
            sw = new StreamWriter(ns);

            sendThread = new Thread(new ThreadStart(Send));
            sendThread.Start();

            receveThread = new Thread(new ThreadStart(Recive));
            receveThread.Start();
            outQueue.Enqueue("Hello client");
        }
        void Send()
        {
            while (true)
            {
                Thread.Sleep(1);
                if (outQueue.Count > 0)
                {
                    sw.WriteLine(outQueue.Dequeue());
                    sw.Flush();
                }
            }
        }
        void Recive()
        {
            string s;
            while (true)
            {
                Thread.Sleep(1);
                s = sr.ReadLine();
                inQueue.Enqueue(s);
                if (this.OnOutputData != null)
                {
                    this.OnOutputData(this, new OutputEventArgs(inQueue.Dequeue().ToString()));
                }
            }
        }
    }
    public delegate void OutputEventHandle(object sender, OutputEventArgs args);
    public class OutputEventArgs : EventArgs
    {
        string text;
        public OutputEventArgs(string text)
        {
            this.Text = text;
        }

        public string Text { get => text; set => text = value; }
    }
}
