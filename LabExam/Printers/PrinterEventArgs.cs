using System;

namespace LabExam.Logic
{
    public class PrinterEventArgs : EventArgs
    {
        public Printer Printer { get; set; }

        public PrinterEventArgs(Printer printer)
        {
            this.Printer = printer ?? throw new ArgumentNullException($"{nameof(printer)} is null");
        }
    }
}