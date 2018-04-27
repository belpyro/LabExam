using System;
using System.IO;

namespace LabExam

{
    // Modified into abstract class for common method and properties
    public abstract class Printer
    {
        protected string name;
        protected string model;

        public Printer(string name, string model)
        {
            this.name = name;
            this.model = model;           
        }

        public string Name => name;

        public string Model => model;

        public virtual void Print(FileStream fileStream)
        {
            for (int i = 0; i < fileStream.Length; i++)
            {
                // simulate printing
                Console.WriteLine(fileStream.ReadByte());
            }
        }
    }
}