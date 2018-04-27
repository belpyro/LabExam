using System;
using System.IO;

namespace LabExam
{
    /// <summary>
    /// Printer class, was changed from a struct to add hierarchy
    /// </summary>
    internal class Printer
    {
        public string Name { get; protected set; } //proteted setter as printers' name shouldn't be change externally, at the same time child classe may initialize printers with their own values

        public string Model { get; protected set; } //proteted setter as printers' models shouldn't be change externally, at the same time child classe may initialize printers with their own values

        /// <summary>
        /// Printer constructor
        /// </summary>
        /// <param name="model"> printer's name</param>
        /// <param name="name">printer's model</param>
        public Printer(string model, string name) //paprametrized constructor only as every printer hould have a model and a name
        {
            Name = name;
            Model = model;
        }

        /// <summary>
        /// Simulates printing
        /// </summary>
        /// <param name="fs">filestream to write to</param>
        public virtual void Print(FileStream fs)//printing method is here as most of the printes impliment the ssme printing logic
        {
            for (int i = 0; i < fs.Length; i++)
            {
                // simulate printing
                Console.WriteLine(fs.ReadByte());
            }
        }
    }
}