using System;
using System.IO;

namespace LabExam
{
    // Impliments IPrinter for further extension or adding new printers
    internal class CanonPrinter : Printer
    {
              
        public CanonPrinter(string name, string model) : base(name, model)
        {

        }             

        // Overriding of Print method for determine printer
        public override void Print(FileStream fileStream)
        {
            Console.WriteLine($"Canon {this.Name} is printing...");

            base.Print(fileStream);
        }

        public void Register(PrinterManager printerManager)
        {
            printerManager.Printing += StartPrinting;
        }

        public void Unregister(PrinterManager printerManager)
        {
            printerManager.Printing -= StartPrinting;
        }

        public void StartPrinting(object sender, PrintEventArgs e)
        {
            Console.WriteLine($"Start printing, message: {e.PrintingArg}");
        }
    }
}