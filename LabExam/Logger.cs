using System;
using System.IO;

namespace LabExam
{
    /// <summary>
    /// Class for logging
    /// </summary>
    internal static class Logger
    {
        /// <summary>
        /// Static constructor for subcrubing to the printer events
        /// </summary>
        static Logger()
        {
            PrinterManager.PrintingStarted += LogStartertedPrinting;
            PrinterManager.PrintingFinished += LogFinishedPrinting;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private static void LogStartertedPrinting(object sender, EventArgs eventArgs)
        {
            Log("Print started");
        }

        private static void LogFinishedPrinting(object sender, EventArgs eventArgs)
        {
            Log("Print finished");
        }

        public static void Log(string s)
        {
            File.AppendText("log.txt").Write(s);
        }
    }
}
