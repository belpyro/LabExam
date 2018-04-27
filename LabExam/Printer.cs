using System;
using System.IO;

namespace LabExam
{
    internal class Printer
    {
        public string Name { get; protected set; }

        public string Model { get; protected set; }

        public Printer(string model, string name)
        {
            Name = name;
            Model = model;
        }

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