using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExam
{
    class Program
    {
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
                Print(new Printer("Canon", "123x"));
            }

            if (key.Key == ConsoleKey.D3)
            {
                Print(new Printer("Epson", "231"));
            }
            for (int i = 2; i < PrinterManager.Printers.Count; i++)
            {

            }
            while (true)
            {
                // waiting
            }
        }

        private static void Print(Printer printer)
        {
            PrinterManager.Print(printer);
            PrinterManager.Log($"Печатается на {printer.Name}");
        }

        private static void CreatePrinter()
        {
            Console.WriteLine("Enter printer name");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter printer model");
            string Model = Console.ReadLine();
            PrinterManager.Add(new Printer(Name, Model));
        }
    }
}
