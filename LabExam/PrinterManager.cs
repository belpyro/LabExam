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
            Printers = new List<Printer>();
        }

        public static List<Printer> Printers { get; set; }

        public static void Add(Printer p1)
        {            
            if (!Printers.Contains(p1))
            {
                Printers.Add(p1);
                Console.WriteLine("Printer added");
            }
        }

        public static void Print(Printer p1)
        {
            Log("Print started");
            var o = new OpenFileDialog();
            o.ShowDialog();
            if (o.FileName == null || o.FileName == String.Empty )
                throw new ArgumentNullException("You didn't select file");

            OnPrinted += Message;
            OnPrinted("Print started");
            var f = File.OpenRead(o.FileName);
            p1.Print(f);
            Log("Print finished");
        }

        public static void Log(string s)
        {
            File.AppendText("log.txt").Write(s);
        }

        public static void Message(string s)
        {
            Console.WriteLine(s);
        }
        public static event PrinterDelegate OnPrinted;
    }
}