using System;
using System.IO;

namespace LabExam
{
    internal class EpsonPrinter : Printer
    {
        public EpsonPrinter(string name, string model) : base(name, model) { }

        protected override void EmulatePrint(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            using (stream)
            {
                for (int i = 0; i < stream.Length; i++)
                {
                    stream.ReadByte();
                }
            }
        }
    }
}