using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace LabExam
{
    internal class PrinterManager
    {
        /// <summary>
        /// ILogger for adding any loggers that need.
        /// </summary>
        private readonly ILogger logger;
        public PrinterManager(ILogger logger)
        {
            this.logger = logger;
            Printers = new List<Printer>();
        }

        public List<Printer> Printers { get; private set; }
        
        public void Add(Printer printer)
        {
            if (!Printers.Contains(printer))
            {
                Printers.Add(printer);
                logger.Log("Printer added");

            }
            else
            {
                logger.Log("Printer already exist");
                throw new ArgumentException($"{(printer)} already exist!");
            }
        }

        /// <summary>
        /// Change from specific printes to IPrinter
        /// for improving flexibility.
        /// </summary>
        /// <param name="printer"></param>
        public void Print(Printer printer)
        {
            if (!Printers.Contains(printer))
            {
                Printers.Add(printer);
            }

            logger.Log($"{(printer)} started to print!");
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();

            var textOfFile = File.OpenRead(fileDialog.FileName);
            printer.Print(textOfFile);

            logger.Log($"{(printer)} finished to print!");
        }
    }
}
