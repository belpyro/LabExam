using System;
using System.IO;

namespace LabExam
{
    internal class CanonPrinter:AbstractPrinter
    {
        public CanonPrinter()
        {
            Name = "Canon";
            Model = "123x";
        }

       
        public override string Name { get; set; }

        public override string Model { get; set; }
    }
}