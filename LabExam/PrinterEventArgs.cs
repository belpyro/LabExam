using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExam
{
    internal class PrinterEventArgs : EventArgs
    {
        public Printer Printer { get; set; }
        public string Message { get; set; }

        public PrinterEventArgs(Printer printer, string message)
        {
            this.Printer = printer;
            this.Message = message;
        }
    }
}
