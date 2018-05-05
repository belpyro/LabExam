using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExam
{
    public static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Select your choice:");
            Console.WriteLine("1:Add new printer");
            Console.WriteLine("2:Print on Canon");
            Console.WriteLine("3:Print on Epson");
            string pathToFile = "D:\\Epam\\Epam.ASP.NET\\LabExam\\LabExam\\bin\\Debug\\log.txt";
            ILogger logger = new Logger(pathToFile);
            PrinterManager manager = new PrinterManager(logger);

            while (true)
            {
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.D1)
                {
                    manager.CreatePrinter();
                }

                if (key.Key == ConsoleKey.D2)
                {
                    manager.Print(new Printer("1","Canon"));
                }

                if (key.Key == ConsoleKey.D3)
                {
                    manager.Print(new Printer("2","Epson"));
                }

                for (int i = 0; i < manager.Printers.Count; i++)
                {
                    Console.WriteLine("Printers " + i + ' ' + " Name: " + manager.Printers[i].Name + " Model: " + manager.Printers[i].Model);
                }
            }
        }

        private static void Print(this PrinterManager manager, Printer printer)
        {
            if(manager == null || printer == null)
            {
                throw new ArgumentNullException($"{(nameof(manager))} cant be a null");
            }
            if (printer == null)
            {
                throw new ArgumentNullException($"{(nameof(printer))} cant be a null");
            }

            Console.WriteLine(printer.GetType());
            manager.Print(printer);
        }

        private static void CreatePrinter(this PrinterManager manager)
        {
            Console.WriteLine("Enter printer name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter printer model");
            string model = Console.ReadLine();
            Printer printer = new Printer(name, model);

            manager.Add(printer);
        }
    }
}
