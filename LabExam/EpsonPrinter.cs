using System;
using System.IO;

namespace LabExam
{
    internal class EpsonPrinter:AbstractPrinter
    {
        public EpsonPrinter()
        {
            Model = "231";
            Name = "Epson";
        }
        public override string Name { get; set; }

        public override string Model { get; set; }
    }
}