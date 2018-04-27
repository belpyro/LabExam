﻿using System;
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

        private static void Print(Printer printer)
        {   
            var manager = new PrinterManager();
            manager.Print(printer);
            PrinterManager.Log($"Printed on ");
        }
        

        private static void CreatePrinter()
        {
            PrinterManager.Add(new Printer());
        }
    }
}
