using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace KeyTracer
{
    static class Debug
    {
        public static int StartDebugging()
        {
            try
            {
                string server = "https://localhost/";

                StartUp.Configure();
                Consts.Server = server;
                
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
