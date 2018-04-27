using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LabExam
{
    public class FileLogger : ILogger
    {
        public void Log(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }

            File.AppendText("log.txt").Write(s);
        }
    }
}