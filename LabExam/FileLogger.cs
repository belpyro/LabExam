using System.IO;

namespace LabExam
{
    public class FileLogger : ILogger
    {
        public void Log(string s)
        {
            var swr = File.AppendText(@"C:\temp\log.txt");
            swr.Write(s);
            swr.Flush();
            swr.Close();
        }
    }
}