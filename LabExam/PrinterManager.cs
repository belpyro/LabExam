using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LabExam
{
    /// <summary>
    /// Printer manager class
    /// </summary>
    internal static class PrinterManager
    {
        private static List<Printer> printers;//so printers list cannot be changed

        public static IReadOnlyCollection<Printer> Printers => printers.AsReadOnly(); //so printers list cannot be changed
        public static event EventHandler<EventArgs> PrintingStarted; ///event for printing started
        public static event EventHandler<EventArgs> PrintingFinished; //ecent for printing finished

        static PrinterManager()
        {
            printers = new List<Printer>();
        }

        public static void Add(Printer printer)
        {
            if (Printers.Any(p=> printer.Name == p.Name && printer.Model == p.Model)) Console.WriteLine("Printer already exists"); ;//check if there is a printer with the same name and model number
            printers.Add(printer);
            Console.WriteLine("Printer added");
        }

        /// <summary>
        /// Calls subscribers when printing started
        /// </summary>
        /// <param name="e"></param>
        private static void OnPriningStarted(EventArgs e)
        {
            PrintingStarted?.Invoke(null, e);
        }

        /// <summary>
        /// Calls subscribers when printing finished
        /// </summary>
        /// <param name="e"></para
        private static void OnPriningfinished(EventArgs e)
        {
            PrintingFinished?.Invoke(null, e);
        }

        public static void Print(this Printer printer)//extension method for printing
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