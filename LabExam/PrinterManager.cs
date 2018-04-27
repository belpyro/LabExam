using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LabExam
{
    internal static class PrinterManager
    {
        public static List<Printer> Printers { get; }

        public static event EventHandler<EventArgs> PrintingStarted;
        public static event EventHandler<EventArgs> PrintingFinished;

        static PrinterManager()
        {
            Printers = new List<Printer>();
        }

        public static void Add(Printer printer)
        {
            if (Printers.Any(p=> printer.Name == p.Name && printer.Model == p.Model)) Console.WriteLine("Printer already exists"); ;
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