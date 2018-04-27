using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace LabExam
{
    public delegate void PrinterDelegate(string arg);

    internal static class PrinterManager
    {
        static PrinterManager()
        {
            //Printers = new List<Printer>();
            Printers = new HashSet<Printer>();
        }

        //public static List<object> Printers { get; set; }

        public static HashSet<Printer> Printers { get; set; }

        public static void Add(Printer p1)
        {
            Console.WriteLine("Enter printer name");
            p1.Name = Console.ReadLine();
            Console.WriteLine("Enter printer model");
            p1.Model = Console.ReadLine();

            Printers.Add(p1);
            Console.WriteLine("Printer added");
        }

        public static void Print(Printer p1)
        {
            Log("Print started");
            var o = new OpenFileDialog();
            o.ShowDialog();
            var f = File.OpenRead(o.FileName);
            p1.Print(f);
            Log("Print finished");
        }

        public static void Log(string s)
        {
            File.AppendText("log.txt").Write(s);
        }

        public static event PrinterDelegate OnPrinted;
    }
}

