using System.IO;

namespace PackageManager
{
    public class LogController
    {
        private static TextWriter output;

        public static void Create(TextWriter writer)
        {
            output = writer;
        }

        public static string Log(string message)
        {
            output.WriteLine(message);
            return message;
        }
    }
}
