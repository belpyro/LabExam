using LabExam.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabExam.UI.UserOptions
{
    public class PrinterOption : IUserOption
    {
        private readonly Printer printer;
        private readonly PrinterManager printerManager;

        public PrinterOption(PrinterManager printerManager, Printer printer)
        {
            this.printer = printer ?? throw new ArgumentNullException($"{printer} is null");
            this.printerManager = printerManager ?? throw new ArgumentNullException($"{printerManager} is null");
        }

        public void Action()
        {
            var printedFileDialog = new OpenFileDialog();
            printedFileDialog.ShowDialog();

            var printedFile = File.OpenRead(printedFileDialog.FileName);

            printerManager.Print(printer, printedFile);
        }

        public string ShowOption()
        {
            return printer.ToString();
        }
    }
}
