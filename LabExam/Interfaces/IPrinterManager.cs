using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabExam.Entity;

namespace LabExam.Interfaces
{
    /// <summary>
    /// Interface for printer manager
    /// </summary>
    public interface IPrinterManager
    {
        IList<BasePrinter> GetAll();

        void Add(string name, string model);

        void Print(BasePrinter printer, FileStream stream);
    }
}
