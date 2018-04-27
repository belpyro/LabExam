using System;

namespace LabExam
{
    internal class PrinterEventArgs : EventArgs
    {
        public Printer Printer { get; set; }

        public PrinterEventArgs(Printer printer)
        {
            this.Printer = printer ?? throw new ArgumentNullException($"{nameof(printer)} is null");
        }
    }
}