using LabExam.Logic;
using LabExam.UI.UserOptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExam.UI
{
    public class ConsoleManager
    {
        #region fields
        private PrinterManager printerManager;
        private List<IUserOption> options = new List<IUserOption>();
        #endregion

        #region constructos
        public ConsoleManager(PrinterManager printerManager, IUserOptionsFactory factory)
        {
            options = factory?.CreateOptions(printerManager, this).ToList() ?? throw new ArgumentNullException($"{factory} is null");
            this.printerManager = printerManager ?? throw new ArgumentNullException($"{printerManager} is null");
        }
        #endregion

        #region methods
        public void AddUserOption(IUserOption userOption)
        {
            if (userOption == null)
            {
                throw new ArgumentNullException($"{userOption} is null");
            }

            options.Add(userOption);
        }

        public void Run()
        {
            while (true)
            {
                ShowOptions();

                bool isSuccess = Int32.TryParse(Console.ReadLine(), out int key);

                if (!isSuccess)
                {
                    InputError();
                    continue;
                }

                HandleOption(key);
            }

        }

        private void InputError()
        {
            Console.Write("Input Error!");
        }

        private void ShowOptions()
        {
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{options[i].ShowOption()}");
            }
        }

        private void HandleOption(int key)
        {
            options[key - 1].Action();
        }
        #endregion
    }
}