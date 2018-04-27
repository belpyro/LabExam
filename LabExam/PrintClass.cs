using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace LabExam
{
    class PrintClass
    {
        public delegate void PrinterDelegate(string arg);
        public static void Print(Printer p1)
        {
            Log("Print started");
            var o = new OpenFileDialog();
            o.ShowDialog();
            var f = File.OpenRead(o.FileName);
            OnPrinted += Message;
            OnPrinted("Printing starts");
            p1.Print(f);
            OnPrinted("Printing finished");
            OnPrinted -= Message;

        }
        public static void Message(string message)
        {
            Console.WriteLine(message);
        }
        public static void Log(string s)
        {
            File.AppendText("log.txt").Write(s);
        }

        public static event PrinterDelegate OnPrinted;

    }
}
