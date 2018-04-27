using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace LabExam
{
    public class Printer:AbstractPrinter
    {
        
        public Printer(string name, string model)
        {
            Name = name;
            Model = model;
        }
        public override string Name { get; set; }

        public override string Model { get; set; }
        public static void Log(string s)
        {
            File.AppendText("log.txt").Write(s);
        }
    }
}
