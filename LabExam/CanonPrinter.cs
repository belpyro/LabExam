using System;
using System.IO;

namespace LabExam
{
    internal sealed class CanonPrinter : Printer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CanonPrinter"/> class.
        /// </summary>
        public CanonPrinter() : this("Canon", "123x")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CanonPrinter"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="model">The model.</param>
        public CanonPrinter(string name, string model) : base(name, model)
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