using System;
using System.Linq;

namespace LabExam
{
    internal class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            string command;

            while (true)//the loop introduced so a user could do more than one operation
            {
                ShowMenu();

                command = Console.ReadLine();

                Execute(command);
            }
        }

        private static void Execute(string command)
        {
            int index;
            const int defautlNumberofOperations = 4;

            if (!Int32.TryParse(command, out index))
            {
                Console.WriteLine("Invalid operation");
                Console.ReadKey();
                return;
            }

            if (index >= PrinterManager.Printers.Count + defautlNumberofOperations)
            {
                Console.WriteLine("The operation is not supported");
                Console.ReadKey();
                return;
            }

            switch (index)
            {
                case 1:
                    CreatePrinter();
                    break;
                case 2:
                    new CanonPrinter().Print();
                    break;
                case 3:
                    new EpsonPrinter().Print();
                    break;
                case -1://exit from the program
                    return;
                default:
                    PrinterManager.Printers.ElementAt(index - defautlNumberofOperations).Print();
                    break;
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

        private static void ShowMenu()
        {
            Console.WriteLine("Select your choice:");
            Console.WriteLine("1:Add new printer");
            Console.WriteLine("2:Print on Canon");
            Console.WriteLine("3:Print on Epson");
            Console.WriteLine("-1:To exit");

            int i = 3;
            foreach (var printer in PrinterManager.Printers)
            {
                Console.WriteLine(++i + ":Print on " + printer.Name);
            }
        }
}
}
