using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExam
{
    /// <summary>
    /// Created interface IPrinter 
    /// it's need for improving a flexibility of creating a Printers.
    /// </summary>
    interface IPrinter
    {
        void Print(Stream stream);
    }
}
