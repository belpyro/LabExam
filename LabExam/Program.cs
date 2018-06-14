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
            PrinterFactory factory = new PrinterFactory();

            while (true)
            {
                Console.WriteLine("Select your choice:");
                Console.WriteLine("1:Add new printer");
                Console.WriteLine("2:Print on Canon");
                Console.WriteLine("3:Print on Epson");

                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.D1)
                {
                    Console.WriteLine("Enter printer model");
                    string model = Console.ReadLine();
                    Console.WriteLine("Enter printer name");
                    string name = Console.ReadLine();
                    factory.CreatePrinter(name, model);
                }

                if (key.Key == ConsoleKey.D2)
                {
                    Console.WriteLine("Enter printer name");
                    string name = Console.ReadLine();
                    PrinterManager.Instance.Print(new CanonPrinter(name, "Canon"));
                }

                if (key.Key == ConsoleKey.D3)
                {
                    Console.WriteLine("Enter printer name");
                    string name = Console.ReadLine();
                    PrinterManager.Instance.Print(new EpsonPrinter(name, "Epson"));
                }
            }
        }
    }
}
