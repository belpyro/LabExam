using System;

namespace LabExam
{
    internal class CanonPrinter : Printer
    {
        public CanonPrinter()
        {
            Name = "Canon";
            Model = "123x";
        }

        //возможность задания модели
        public CanonPrinter(string model) : this()
        {
            Model = model ?? throw new ArgumentNullException($"{nameof(model)} cannot be null.");
        }
    }
}