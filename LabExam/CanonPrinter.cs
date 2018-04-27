using System;
using System.IO;

namespace LabExam
{
    internal sealed class CanonPrinter : Printer
    {
        public CanonPrinter()
        {
            Name = "Canon";
            Model = "123x";
        }
    }
}