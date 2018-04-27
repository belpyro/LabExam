using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExam
{
    class Program
    {
        public static PrinterManager printerManager = new PrinterManager();
        [STAThread]
        static void Main(string[] args)
        {
            
            Console.WriteLine("Select your choice:");
            Console.WriteLine("1:Add new printer");
            Console.WriteLine("2:Print on Canon");
            Console.WriteLine("3:Print on Epson");

            var key = Console.ReadKey();

            if (key.Key == ConsoleKey.D1)
            {
                CreatePrinter();
            }

            if (key.Key == ConsoleKey.D2)
            {
                Print(new CanonPrinter());
            }

            if (key.Key == ConsoleKey.D3)
            {
                Print(new EpsonPrinter());
            }

            while (true)
            {
                // waiting
            }
        }

        private static void Print(EpsonPrinter epsonPrinter)
        {
            printerManager.Print(epsonPrinter);
            printerManager.Logger.Log("Printed on Epson");
        }

        private static void Print(CanonPrinter canonPrinter)
        {
            printerManager.Print(canonPrinter);
            printerManager.Logger.Log("Printed on Canon");
        }

        private static void CreatePrinter()
        {
            try
            {
                Console.WriteLine("Enter printer name");
                string Name = Console.ReadLine();
                Console.WriteLine("Enter printer model");
                string Model = Console.ReadLine();
                printerManager.Add(new Printer(Name, Model));
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
