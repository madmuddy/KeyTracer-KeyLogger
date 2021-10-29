namespace KeyTracer
{
    static class Consts
    {
        public static string serverLocation = "https://googledrive.com";
        public static string Server = "http://ngrkok.com";

        public static string serverKeyTraces = "/keytraces.php";

        public static string keytraceFileName = "keytrace.kys";
        public static string serverFileName = "keytrace.ser";

        public static string programPath = "";
        public static string tempPath = "";

        public static string keytracePath = "";
        public static string serverPath = "";

        public static int uploadDelay = 10000;
        public static int serverTimeout = 20000;
        public static int matchDelayTime = 1;

        public static bool isConnected = false;
        public static bool isUploading = false;

        public static bool doWork = true;
    }
}
