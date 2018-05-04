using System;
using System.Collections.Generic;
using System.IO;

namespace LabExam
{
    /// <summary>
    /// Changed from struct Printer to class Printer
    /// for to have a possibility to create a Printer
    /// </summary>
    internal class Printer : IPrinter
    {
        public string Name { get; set; }

        public string Model { get; set; }

        public Printer()
        {
        }

        public Printer(string name, string model)
        {
            this.Name = name ?? throw new ArgumentNullException($"{nameof(name)} cant be a null");
            this.Model = model ?? throw new ArgumentNullException($"{nameof(model)} cant be a null");
        }

        /// <summary>
        /// for comparison with printers
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var printer = obj as Printer;
            return printer != null &&
                   Name == printer.Name &&
                   Model == printer.Model;
        }

        /// <summary>
        /// The uniqueness of each printer
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            var hashCode = -1566092560;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Model);
            return hashCode;
        }

        public void Print(FileStream fs)
        {
            for (int i = 0; i < fs.Length; i++)
            {
                Console.WriteLine(fs.ReadByte());
            }
        }
        public override string ToString()
        {
            return $"{Name} - {Model}";
        }
    }
}