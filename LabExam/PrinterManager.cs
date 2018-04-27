using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Forms;

namespace LabExam
{
    //1.logging logic was removed because it's not a responsibility of this class
    //2.bad semantic meaning of names of variables
    //variables was renamed
    //3.for removing static there is a couple of reasons:
    //1.can't use "this" when working with events
    //2.it's not handy to work with dependencies as ILogger when deailing with static classes.
    internal class PrinterManager
    {
        #region fields
        private readonly ILogger logger;
        private List<Printer> printers;
        #endregion

        public Printer[] Printers
        {
            get
            {
                return printers.ToArray();
            }
        }

        #region constructors
        public PrinterManager(ILogger logger)
        {
            this.logger = logger;
            this.printers = new List<Printer>();
        }
        #endregion

        #region methods

        public void Add()
        {
            Console.WriteLine("Enter printer name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter printer model");
            string model = Console.ReadLine();

            Add(new Printer(name, model));
        }

        public void Add(Printer printer)
        {
            if (!printers.Contains(printer))
            {
                printers.Add(printer);
                Console.WriteLine("Printer added");
            }
            else
            {
                Console.WriteLine("Already Exist");
            }
        }

        public void Print(Printer printer)
        {
            logger.Log($"Print({printer}) started");
            OnPrintStarted(new PrinterEventArgs(printer));

            var printedFileDialog = new OpenFileDialog();
            printedFileDialog.ShowDialog();

            var printedFile = File.OpenRead(printedFileDialog.FileName);
            printer.Print(printedFile);

            logger.Log($"Print({printer}) finished");
            OnPrintEnded(new PrinterEventArgs(printer));
        }

        #endregion

        #region events
        //to follow the protocol for events
        public event EventHandler<PrinterEventArgs> PrintStarted = delegate { };
        public event EventHandler<PrinterEventArgs> PrintEnded = delegate { };

        protected virtual void OnPrintStarted(PrinterEventArgs args)
        {
            PrintStarted(this, args);
        }

        protected virtual void OnPrintEnded(PrinterEventArgs args)
        {
            PrintEnded(this, args);
        }

        #endregion
    }
}