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
                Print(new Printer("Canon","123x"));
            }

            if (key.Key == ConsoleKey.D3)
            {
                Print(new Printer("Epson","231"));
            }
            
            while (true)
            {
                // waiting
            }
        }

        private static void Print(Printer Printer)
        {
            PrintClass.Print(Printer);
            Printer.Log($"Printed on {Printer.Name}{Printer.Model}");
        }

        

        private static void CreatePrinter()
        {
            Console.WriteLine("Enter name of printer");
            string name = Console.ReadLine();
            Console.WriteLine("Enter model of printer");
            string model = Console.ReadLine();
            AddClass.Add(new Printer(name,model));
        }
    }
}
