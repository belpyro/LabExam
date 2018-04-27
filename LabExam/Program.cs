using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace LabExam
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var kernel = new StandardKernel(new ConfigModule());
            var manager = kernel.Get<PrinterManager>();
            IPrinterFactory factory = new PrinterFactory(manager);
            Console.WriteLine("Select your choice:");
            Console.WriteLine("1:Add new printer");
            Console.WriteLine("2:Print on Canon");
            Console.WriteLine("3:Print on Epson");

            var key = Console.ReadKey();

            if (key.Key == ConsoleKey.D1)
            {
                factory.CreatePrinter();//UI, не должен знать процесс создания принтера
            }

            if (key.Key == ConsoleKey.D2)
            {
                Print(manager, new CanonPrinter());
            }

            if (key.Key == ConsoleKey.D3)
            {
                Print(manager, new EpsonPrinter());
            }

            while (true)
            {
                // waiting
            }
        }

        private static void Print(PrinterManager manager, Printer Printer)
        {
            manager.Print(Printer);
            manager.Log("Printed on Epson");
        }

        /*private static void Print(CanonPrinter canonPrinter)
        {
            manager.Print(canonPrinter);
            PrinterManager.Log("Printed on Canon");
        }*/

        /*private static void CreatePrinter(PrinterManager manager)
        {
            Console.WriteLine("Enter printer name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter printer model");
            string model = Console.ReadLine();
            manager.Add(new Printer() { Name = name, Model = model });
        }*/
    }
}
