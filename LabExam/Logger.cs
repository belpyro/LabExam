using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabExam
{
    /// <summary>
    /// Imitation of working a Logger
    /// </summary>
    public class Logger : ILogger
    {
        public string PathToFile;

        public Logger()
        {
        }

        public Logger(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }

            this.PathToFile = path;
        }

        public void Log(string message)
        {
            if (!File.Exists(PathToFile))
            {
                File.Create(PathToFile);
            }

            using (var file = File.AppendText(PathToFile))
            {
                file.Write(message);
            }
        }
    }
}
