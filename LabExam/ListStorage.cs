using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExam
{
    public class ListStorage : IStorage
    {
        private List<Printer> printers = new List<Printer>();

        public IEnumerable<Printer> GetPrinters()
        {
            foreach(var item in printers)
            {
                yield return item;
            }
        }

        public void Save(Printer printer)
        {
            if (printer == null)
            {
                throw new ArgumentNullException();
            }

            if (!printers.Contains(printer))
            {
                printers.Add(printer);
                Console.WriteLine("Printer added");
            }
        }
    }
}
