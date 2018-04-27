using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExam
{
    internal class FileLogger : ILogger
    {
        public string Path { get; set; }

        public FileLogger(string path)
        {
            Path = path ?? throw new ArgumentNullException($"{path} is null");

            if (!File.Exists(path))
            {
                File.Create(path);
            }
        }

        public void Log(string message)
        {
            using (var file = File.AppendText(Path))
            {
                file.Write(message);
            }
        }
    }
}
