using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace LabExam
{
    internal static class PrinterManager
    {
        public static List<object> Printers { get; }

        public static event EventHandler<EventArgs> PrintingStarted;
        public static event EventHandler<EventArgs> PrintingFinished;

        static PrinterManager()
        {
            Printers = new List<object>();
        }

        public static void Add(Printer printer)
        {
            if (Printers.Contains(printer)) return;
            Printers.Add(printer);
            Console.WriteLine("Printer added");
        }

        private static void OnPriningStarted(EventArgs e)
        {
            PrintingStarted?.Invoke(null, e);
        }

        private static void OnPriningfinished(EventArgs e)
        {
            PrintingFinished?.Invoke(null, e);
        }

        public static void Print(this Printer printer)
        {
            OnPriningStarted(null);
            var o = new OpenFileDialog();
            o.ShowDialog();
            var f = File.OpenRead(o.FileName);
            printer.Print(f);
            OnPriningfinished(null);

            Logger.Log("Printed on " + printer.Name);
        }
    }
}