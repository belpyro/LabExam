using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace LabExam
{
    public sealed class PrinterManager
    {
        private static readonly Lazy<PrinterManager> instance =
               new Lazy<PrinterManager>(() => new PrinterManager());

        private ILogger logger;

        private PrinterManager()
        {
            Printers = new List<Printer>();
        }

        public static PrinterManager Instance { get => instance.Value; }

        public List<Printer> Printers { get; private set; }

        public ILogger Logger
        {
            get
            {
                if (logger == null)
                {
                    logger = new FileLogger("log.txt");
                }

                return logger;
            }

            set
            {
                logger = value ?? throw new ArgumentNullException();
            }
        }

        public void Add(Printer printer)
        {
            if (printer == null)
            {
                throw new ArgumentNullException(nameof(printer));
            }

            if (Printers.Contains(printer))
            {
                throw new ArgumentException("Printer is already added");
            }

            printer.StartPrint += (sender, args) => Log($"Printer {printer.Model} {printer.Name} is printing");
            printer.EndPrint += (sender, args) => Log($"Printer {printer.Model} {printer.Name} has ended printing");
            Printers.Add(printer);
            Log("Printer was added");
        }

        public void Print(Printer printer)
        {
            if (printer == null)
            {
                throw new ArgumentNullException(nameof(printer));
            }

            if (!Printers.Contains(printer))
            {
                throw new ArgumentException("Printer can not be found");
            }

            var o = new OpenFileDialog();
            o.ShowDialog();
            using (var stream = File.OpenRead(o.FileName))
            {
                printer.Print(stream);
            }
        }

        public void Log(string message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            Logger.Log(message);
        }
    }
}