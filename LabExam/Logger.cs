using System;
using System.IO;

namespace LabExam
{
    internal static class Logger
    {
        static Logger()
        {
            PrinterManager.PrintingStarted += LogStartertedPrinting;
            PrinterManager.PrintingFinished += LogFinishedPrinting;
        }

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
