using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabExam.Logic;

namespace LabExam.UI.UserOptions
{
    class DefaultOptionsFactory : IUserOptionsFactory
    {
        public IEnumerable<IUserOption> CreateOptions(PrinterManager printerManager, ConsoleManager consoleManager)
        {
            return new IUserOption[]
            {
                new CreatePrinterOption(printerManager,consoleManager)
            };
        }
    }
}
