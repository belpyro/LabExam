using System;
using System.IO;

namespace LabExam
{
    public class Printer : IPrint
    {
        public string Name { get; set; }

        public string Model { get; set; }

        public virtual void Print(FileStream fs)
        {
            for (int i = 0; i < fs.Length; i++)
            {
                // simulate printing
                Console.WriteLine(fs.ReadByte());
            }
        }
    }
}