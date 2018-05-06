using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExam
{
    public class PrinterFactory
    {
        public void CreatePrinter(string name, string model)
        {
            switch (model)
            {
                case "Canon":
                    PrinterManager.Instance.Add(new CanonPrinter(name, model));
                    break;
                case "Epson":
                    PrinterManager.Instance.Add(new EpsonPrinter(name, model));
                    break;
                default:
                    throw new InvalidOperationException("there is no such model");
                    break;
            }
        }
    }
}
