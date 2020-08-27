using LabExam.Logic;
using System.Collections.Generic;

namespace LabExam.UI.UserOptions
{
    public interface IUserOptionsFactory
    {
        IEnumerable<IUserOption> CreateOptions(PrinterManager printerManager, ConsoleManager consoleManager);
    }
}