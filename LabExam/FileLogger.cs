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
        private readonly string fileName;

        public FileLogger(string fileName)
        {
            this.fileName = fileName ?? throw new ArgumentNullException(nameof(fileName));
        }

        public void Log(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }

            if (!File.Exists(fileName))
            {
                throw new ArgumentException(nameof(fileName));
            }

            File.AppendText(fileName).Write(s);
        }
    }
}