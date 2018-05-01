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

            printerManager.PrintStateChanged += OnPrintStateChanged;
        }

        private void OnPrintStateChanged(object sender, PrinterEventArgs e)
        {
            Console.WriteLine($"{e.Printer} {e.Message}");
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

        ~PrinterOption()
        {
            printerManager.PrintStateChanged -= OnPrintStateChanged;
        }
    }
}
