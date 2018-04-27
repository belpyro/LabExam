using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExam
{
    public class PrinterFactory : IPrinterFactory
    {
        private PrinterManager manager;

        public PrinterFactory(PrinterManager manager)
        {
            this.manager = manager;
        }

        public void CreatePrinter()
        {
            Console.WriteLine("Enter printer name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter printer model");
            string model = Console.ReadLine();
            manager.Add(new Printer() { Name = name, Model = model });
        }
    }
}
