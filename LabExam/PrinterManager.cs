using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace LabExam
{
    public delegate void PrinterDelegate(string arg);

    internal class PrinterManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrinterManager"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public PrinterManager(ILogger logger = null)
        {
            if(ReferenceEquals(logger,null))
            {
                this.Logger = new CustomLogger();
            }
            else
            {
                this.Logger = logger;
            }

            Printers = new List<IPrinter>();
            
        }

        /// <summary>
        /// Gets the logger.
        /// </summary>
        /// <value>
        /// The logger.
        /// </value>
        public ILogger Logger { get; }

        /// <summary>
        /// Gets or sets the printers.
        /// </summary>
        /// <value>
        /// The printers.
        /// </value>
        private List<IPrinter> Printers { get; set; }

        /// <summary>
        /// Adds the specified p1.
        /// </summary>
        /// <param name="p1">The p1.</param>
        /// <returns></returns>
        public bool Add(IPrinter p1)
        {
            if (!Printers.Contains(p1))
            {
                Printers.Add(p1);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Prints the specified p1.
        /// </summary>
        /// <param name="p1">The p1.</param>
        /// <exception cref="ArgumentNullException">Printer is null!</exception>
        public void Print(IPrinter p1)
        {
            if (ReferenceEquals(p1, null))
            {
                throw new ArgumentNullException("Printer is null!");
            }

            Logger.Log("Print started");
            var o = new OpenFileDialog();
            o.ShowDialog();
            var f = File.OpenRead(o.FileName);
            p1.Print(f);
            Logger.Log("Print finished");
        }

        /// <summary>
        /// Occurs when [on printed].
        /// </summary>
        public static event PrinterDelegate OnPrinted;
    }
}