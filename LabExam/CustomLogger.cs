using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExam
{
    sealed class CustomLogger : ILogger
    {
        /// <summary>
        /// Logs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Log(string message)
        {
            try
            {

                File.AppendText("log.txt").Write(message);
            }
            catch(IOException)
            {
                throw;
            }
        }
    }
}
