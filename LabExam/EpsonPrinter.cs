using System;
using System.IO;

namespace LabExam
{
    internal class EpsonPrinter : Printer
    {
        public EpsonPrinter()
        {
            Model = "231";
            Name = "Epson";
        }

        // возможность задания модели
        public EpsonPrinter(string model) : this()
        {
            Model = model;
        }
    }
}