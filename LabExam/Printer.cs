using System;
using System.IO;

namespace LabExam
{
    //internal struct Printer
    //{
    //    public string Name { get; set; }

    //    public string Model { get; set; }
    //}

    public class Printer : IPrinter
    {
        public string Name { get; set; }
        public string Model { get; set; }

        public void Print(FileStream fs)
        {
            for (int i = 0; i < fs.Length; i++)
            {
                // simulate printing
                Console.WriteLine(fs.ReadByte());
            }
        }
    }
}