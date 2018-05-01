﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Forms;
using LabExam.Exceptions;
using LabExam.Logging;

namespace LabExam.Logic
{
    //1.logging logic was removed because it's not a responsibility of this class
    //2.bad semantic meaning of names of variables
    //variables was renamed
    //3.for removing static there is a couple of reasons:
    //1.can't use "this" when working with events
    //2.it's not handy to work with dependencies as ILogger when deailing with static classes.
    public sealed class PrinterManager
    {
        #region fields
        private readonly ILogger logger;
        private List<Printer> printers;
        #endregion

        public ReadOnlyCollection<Printer> Printers { get; private set; }

        #region constructors
        public PrinterManager(ILogger logger)
        {
            this.logger = logger;
            this.printers = new List<Printer>();
            this.Printers = new ReadOnlyCollection<Printer>(printers);
        }
        #endregion

        #region methods

        public void Add(Printer printer)
        {
            if (!printers.Contains(printer))
            {
                printers.Add(printer);
            }
            else
            {
                throw new PrinterAlreadyExistException("Already exist!");
            }
        }

        public void Print(Printer printer, FileStream printedFile)
        {
            logger.Log($"Print({printer}) started");
            OnPrintStateChanged(new PrinterEventArgs(printer, "Start"));

            printer.Print(printedFile);

            logger.Log($"Print({printer}) finished");
            OnPrintStateChanged(new PrinterEventArgs(printer, "End"));
        }

        #endregion

        #region events
        //to follow the protocol for events
        public event EventHandler<PrinterEventArgs> PrintStateChanged = delegate { };

        private void OnPrintStateChanged(PrinterEventArgs args)
        {
            PrintStateChanged(this, args);
        }
        #endregion
    }
}