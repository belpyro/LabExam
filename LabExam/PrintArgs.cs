using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExam
{
    //аргументы для события
    internal class PrintArgs : EventArgs
    {
        private byte[] text;

        public PrintArgs(FileStream fs)
        {
            for (int i = 0; i < fs.Length; i++)
            {
                // simulate printing
                text[i] = (byte)fs.ReadByte();
            }
        }

        public byte[] Text => text;
    }
}
