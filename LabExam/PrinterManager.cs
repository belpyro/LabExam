using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace LabExam
{
    //public delegate void PrinterDelegate(string arg);

    public class PrinterEventArgs : EventArgs
    {
        private readonly string message;

        public PrinterEventArgs(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException(nameof(message));
            }
            
            this.message = message;
        }

        public string Message
        {
            get => this.message;
        }
}

    public class PrinterManager
    {
        private IStorage storage; //хранилище для принтеров
        private ILogger logger; //логгер

        public PrinterManager(IStorage storage, ILogger logger)  
        {
            this.storage = storage ?? throw new ArgumentNullException();
            this.logger = logger ?? throw new ArgumentNullException();
        }

        public PrinterManager(IStorage storage) : this(storage, new FileLogger()) { } //если логгер не указан, то используем дефолтный

        //public static List<IPrinter> Printers { get; set; }

        public void Add(Printer printer) //API сервиса, которое может добавить принтер в какое-либо хранилище
        {
            //метод не должен быть завязан для работы в консоли

            /*Console.WriteLine("Enter printer name"); 
            p1.Name = Console.ReadLine();
            Console.WriteLine("Enter printer model");
            p1.Model = Console.ReadLine();*/

            /*if (!Printers.Contains(p1))
            {
                Printers.Add(p1);
                Console.WriteLine("Printer added");
            }*/

            storage.Save(printer); //сервис не должен завязываться на конкретное хранилище
        }

        public void Print(Printer printer) 
        {
            Notify("Print started"); //оповещаем подписчиков о начале печати
            var o = new OpenFileDialog();
            o.ShowDialog();
            var f = File.OpenRead(o.FileName);
            printer.Print(f); //вызываем метод печати базового класса print либо переопределенного в его наследниках
            Notify("Print finished"); //оповещаем подписчиков о конце печати
        }

        /*public static void Print(CanonPrinter p1)
        {
            Log("Print started");
            var o = new OpenFileDialog();
            o.ShowDialog();
            var f = File.OpenRead(o.FileName);
            p1.Print(f);
            Log("Print finished");
        }*/

        public void Log(string s)
        {
            /*File.AppendText("log.txt").Write(s);*/
            logger.Log(s);//не завязываемся на конкретный логгер
        }

        public IEnumerable<Printer> GetPrinters() //имеем возможность получить коллекцию принтеров, не завязываясь на конкретную коллекцию
            => storage.GetPrinters();

        public event EventHandler<PrinterEventArgs> Printer = delegate { };

        public void Notify(string message)
        {
            Log(message);//логируем сообщение, отправленное подписчикам
            this.OnPrinter(new PrinterEventArgs(message));
        }

        protected virtual void OnPrinter(PrinterEventArgs e)
        {
            var temp = this.Printer;
            temp?.Invoke(this, e);
        }
    }
}