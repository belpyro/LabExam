using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace LabExam
{
    public delegate void PrinterDelegate(string arg);

    public class NewPrinterMessageEventArgs: EventArgs
    {
        public string message;

        public NewPrinterMessageEventArgs(string msg)
        {
            message = msg;
        }
    }
    
    internal static class PrinterManager
    {
        public delegate void PrinterMessageEventHandler(object sender, NewPrinterMessageEventArgs e);

        public static PrinterDelegate logger;

        static PrinterManager()
        {
            Printers = new List<Printer>
            {
                new CanonPrinter(),
                new EpsonPrinter()
            };

            logger = Log;
        }

        public static List<Printer> Printers { get; set; }

        public static void Add()
        {
            //TODO: FIX - if printer already exists, this object will not be added and will remain forever
            Printer p = new Printer();

            Console.WriteLine($"{Environment.NewLine}Enter printer name");
            p.Name = Console.ReadLine();
            Console.WriteLine("Enter printer model");
            p.Model = Console.ReadLine();

            //TODO: FIX - actually does allow to create duplicates
            if (!Printers.Contains(p))
            {
                Printers.Add(p);
                Console.WriteLine("Printer added");
            }
            else
            {
                Console.WriteLine($"printer with name: '{p.Name}' and model: '{p.Model}' already exists in the list");
            }            
        }

        public static void Print(Printer p1)
        {
            //TODO: FIX how to deal with events in static class?
            OnPrintStarted(null, new NewPrinterMessageEventArgs($"Print on  ttt {p1.Name} started.{Environment.NewLine}"));

            Log($"Print on {p1.Name} started.{Environment.NewLine}");
            var f = SelectFile();
            p1.Print(f);

            OnPrintEnded(null, new NewPrinterMessageEventArgs($"Print on tt {p1.Name} finished.{Environment.NewLine}"));
            Log($"Print on {p1.Name} finished.{Environment.NewLine}");
        }

        private static FileStream SelectFile()
        {
            var o = new OpenFileDialog();
            o.ShowDialog();
            return File.OpenRead(o.FileName);
        }
        
        //TODO: FIX - need to remove dependency on hardcoded type of logger inside
        public static void Log(string s)
        {
            var swr = File.AppendText(@"C:\temp\log.txt");
            swr.Write(s);
            swr.Flush();
            swr.Close();
        }

        public static event PrinterMessageEventHandler OnPrintStarted;
        public static event PrinterMessageEventHandler OnPrintEnded;
    }    
}