using System;
using System.Collections.Generic;
using System.IO;

namespace LabExam.Logic
{
    //when struct it can be created being in the invalid state
    public class Printer
    {
        public string Name { get; }
        public string Model { get; }

        public Printer(string name, string model)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"{nameof(name)} is null or empty");
            }

            if (String.IsNullOrEmpty(model))
            {
                throw new ArgumentException($"{nameof(model)} is null or empty");
            }

            this.Name = name;
            this.Model = model;
        }

        internal virtual void Print(FileStream fs)
        {
            for (int i = 0; i < fs.Length; i++)
            {
                // simulate printing
                Console.WriteLine(fs.ReadByte());
            }
        }
        //to provide a unique
        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }

            var printer = obj as Printer;

            return printer != null &&
                   Name == printer.Name &&
                   Model == printer.Model;
        }

        public override int GetHashCode()
        {
            var hashCode = -1566092560;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Model);
            return hashCode;
        }

        public override string ToString()
        {
            return $"{Name}:{Model}";
        }
    }
}