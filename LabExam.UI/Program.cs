using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabExam.Logging;
using LabExam.Logic;
using LabExam.UI.UserOptions;

namespace LabExam.UI
{
    class PrintersHandlerUI
    {
        private static PrinterManager printerManager;
        private static ConsoleManager consoleManager;

        [STAThread]
        static void Main(string[] args)
        {
            Config();

            consoleManager.Run();
        }

        private static void Config()
        {
            string pathToLog = ConfigurationSettings.AppSettings["pathToLog"];
            printerManager = new PrinterManager(new FileLogger(pathToLog));
            consoleManager = new ConsoleManager(printerManager, new DefaultOptionsFactory());
        }
    }
}
