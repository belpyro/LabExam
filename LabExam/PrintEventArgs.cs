using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExam
{
    /// <summary>
    /// Class for describing event of printing
    /// </summary>
    public sealed class PrintEventArgs : EventArgs
    {
        private string name;
        private string model;

        public PrintEventArgs(Printer printer)
        {
            if (printer == null)
            {
                throw new ArgumentNullException(nameof(printer));
            }

            this.name = printer.Name;
            this.model = printer.Model;
        }

        public string PrinterName => this.name;

        public string PrinterModel => this.model;
    }
}
