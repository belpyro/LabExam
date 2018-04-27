using System;
using System.IO;

namespace LabExam
{
    internal sealed class EpsonPrinter : Printer
    {
        public EpsonPrinter()
        {
            Model = "231";
            Name = "Epson";
        }
    }
}