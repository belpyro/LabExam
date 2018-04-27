using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace LabExam
{
    internal class PrinterManager
    {
        public  event EventHandler<PrintArgs> NewPrinting = delegate {}; //событие для печати

        protected virtual void OnNewPrinting(PrintArgs args)
        {
            EventHandler<PrintArgs> temp = NewPrinting;
            temp?.Invoke(this, args);
        }

        static PrinterManager()
        {
            Printers = new List<Printer>();
        }

        public static List<Printer> Printers { get; set; }



        public static void Add(Printer p)
        {
            Console.WriteLine("Enter printer name");
            p.Name = Console.ReadLine();
            Console.WriteLine("Enter printer model");
            p.Model = Console.ReadLine();

            if (!Printers.Contains(p))
            {
                Printers.Add(p);
                Console.WriteLine("Printer added");
            }
        }

        public void Print(Printer printer, ILogger logger) //читабельное имя, более общий тип параметра
        {
            logger.Log("Print started");
            var o = new OpenFileDialog();
            o.ShowDialog();
            var f = new PrintArgs(File.OpenRead(o.FileName));
            printer.Print(this, f);
            logger.Log("Print finished");
        }
    }
}