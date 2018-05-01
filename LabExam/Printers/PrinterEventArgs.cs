using System;

namespace LabExam.Logic
{
    public class PrinterEventArgs : EventArgs
    {
        public Printer Printer { get; set; }
        public string Message { get; set; }

        public PrinterEventArgs(Printer printer, string message)
        {
            this.Printer = printer ?? throw new ArgumentNullException($"{nameof(printer)} is null");
            this.Message = message;
        }
    }
}