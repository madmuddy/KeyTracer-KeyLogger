using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KeyTracer
{
    static class Writter
    {
        public static int Write(string[] lines, bool reWrite)
        {
            try
            {
                if (!reWrite)
                {
                    if (!File.Exists(Consts.keytracePath))
                    {
                        using (StreamWriter sw = new StreamWriter(Consts.keytracePath))
                        {
                            sw.Close();
                        }
                    }
                    else
                    {
                        File.AppendAllLines(Consts.keytracePath, lines);
                    }
                    return 1;
                }

                using (StreamWriter sw = new StreamWriter(Consts.keytracePath))
                {
                    for (int x = 0; x < lines.Length; x++)
                    {
                        sw.WriteLine(lines[x]);
                        
                    }

                    sw.Close();
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
