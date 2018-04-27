using System;
using System.IO;

namespace LabExam
{
    /// <summary>
    /// Class for logging
    /// </summary>
    internal static class Logger//Was added as a seperate class as logging as a separate responsibility 
    {
        /// <summary>
        /// Static constructor for subcrubing to the printermanger' events
        /// </summary>
        static Logger()
        {
            PrinterManager.PrintingStarted += LogStartertedPrinting;
            PrinterManager.PrintingFinished += LogFinishedPrinting;
        }

        /// <summary>
        /// Handles event of a print start
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private static void LogStartertedPrinting(object sender, EventArgs eventArgs)
        {
            Log("Print started");
        }

        /// <summary>
        /// Handles event of a print finishs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private static void LogFinishedPrinting(object sender, EventArgs eventArgs)
        {
            Log("Print finished");
        }

        /// <summary>
        /// Writes logs to a file
        /// </summary>
        /// <param name="s">Log message</param>
        public static void Log(string s)
        {
            File.AppendText("log.txt").Write(s);
        }
    }
}
