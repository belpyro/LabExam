using System;

namespace LabExam
{
    internal class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            Console.WriteLine("Select your choice:");
            Console.WriteLine("1:Add new printer");
            Console.WriteLine("2:Print on Canon");
            Console.WriteLine("3:Print on Epson");
            Console.WriteLine("Escape:To exit");

            ConsoleKey key;

            while (true)//the loop introdused so a user could do more than one operation
            {
                key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.D1:
                        CreatePrinter();
                        break;
                    case ConsoleKey.D2:
                        new CanonPrinter().Print();
                        break;
                    case ConsoleKey.D3:
                        new EpsonPrinter().Print();
                        break;
                    case ConsoleKey.Escape:
                        return;
                    default:
                        Console.WriteLine("The operation is not supported");
                        break;
                }
            }
        }

        private static void CreatePrinter()
        {
            Console.WriteLine("Enter printer name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter printer model");
            string model = Console.ReadLine();
            PrinterManager.Add(new Printer(model, name));
        }
    }
}
