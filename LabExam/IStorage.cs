using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExam
{
    public interface IStorage
    {
        void Save(Printer printer);
        IEnumerable<Printer> GetPrinters();
    }
}
