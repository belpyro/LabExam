using System.IO;

namespace LabExam
{
    public class DefaultLogger : ILogger
    {
        public void Log(string message)
        {
            File.AppendText("log.txt").Write(message);
        }
    }
}
