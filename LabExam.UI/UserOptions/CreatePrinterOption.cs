using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabExam.Logic;

namespace LabExam.UI.UserOptions
{
    class CreatePrinterOption : IUserOption
    {
        private readonly PrinterManager printerManager;
        private readonly ConsoleManager consoleManager;

        public CreatePrinterOption(PrinterManager printerManager, ConsoleManager consoleManager)
        {
            this.printerManager = printerManager;
            this.consoleManager = consoleManager;
        }

        public string ShowOption()
        {
            return "Add new Printer";
        }

        public void Action()
        {
            while (true)
            {
                Console.WriteLine("Enter printer name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter printer model");
                string model = Console.ReadLine();

                Printer newPrinter;

                try
                {
                    newPrinter = new Printer(name, model);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                printerManager.Add(newPrinter);
                consoleManager.AddUserOption(new PrinterOption(printerManager, newPrinter));

                break;
            }
        }
    }
}
