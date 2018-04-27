using System;
using System.IO;

namespace LabExam
{
    internal sealed class EpsonPrinter : Printer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EpsonPrinter"/> class.
        /// </summary>
        public EpsonPrinter() : this("Epson", "231")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CanonPrinter"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="model">The model.</param>
        public EpsonPrinter(string name, string model) : base(name, model)
        {
        }

        /// <summary>
        /// Prints the specified file stream.
        /// </summary>
        /// <param name="fileStream">The file stream.</param>
        public override void Print(FileStream fileStream)
        {
            for (int i = 0; i < fileStream.Length; i++)
            {
                // simulate printing
                Console.WriteLine(fileStream.ReadByte());
            }
        }
    }
}