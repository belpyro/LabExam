using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExam
{
    class Program
    {
        private static PrinterManager printerManager;

        [STAThread]
        static void Main(string[] args)
        {
            Config();

            while (true)
            {
                ListOfChoises();

                int key;
                bool isSucces = Int32.TryParse(Console.ReadLine(), out key);

                if (!isSucces)
                {
                    InputError();
                    continue;
                }

                HandleChoice(key);

            }
        }

       

        private static void Config()
        {
            string pathToLog = ConfigurationSettings.AppSettings["pathToLog"];
            printerManager = new PrinterManager(new FileLogger(pathToLog));

            printerManager.Add(new Printer("Canon", "123x"));
            printerManager.Add(new Printer("Epson", "231"));
        }

        private static void ListOfChoises()
        {
            Console.WriteLine("Select your choice:");

            Console.WriteLine("0:Add new printer");

            Printer[] printers = printerManager.Printers;

            for (int i = 0; i < printers.Length; i++)
            {
                Console.WriteLine($"{i + 1}.{printers[i]}");
            }
        }

        private static void HandleChoice(int key)
        {
            if (key == 0)
            {
                CreatePrinter();
                return;
            }

            key--;

            if (key >= printerManager.Printers.Length)
            {
                InputError();
                return;
            }

            Print(printerManager.Printers[key]);
        }

        private static void CreatePrinter()
        {
            printerManager.Add();
        }

        private static void Print(Printer printer)
        {
            printerManager.PrintStarted += (sender, args) => Console.WriteLine($"{args.Printer} started printing");
            printerManager.PrintEnded += (sender, args) => Console.WriteLine($"{args.Printer} ended printing");
            printerManager.Print(printer);
            

        }

        private static void InputError()
        {
            Console.WriteLine("Input Error!");
        }
    }
}
