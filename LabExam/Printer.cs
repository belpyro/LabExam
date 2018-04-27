using System;
using System.IO;

namespace LabExam
{
    // базовый класс с набором общих полей
    internal class Printer
    {
        //обеспечение неизменяемости класса для безопасности

        private readonly string _name;
        private readonly string _model;

        public string Name { get; internal set; }

        public string Model { get; internal set; }

        //метод для работы с аргументами события
        public void Print(object sender, PrintArgs args)
        {
            for (int i = 0; i < args.Text.Length; i++)
            {
                // simulate printing
                Console.WriteLine(args.Text[i]);
            }
        }

        public void Register(PrinterManager manager)
        {
            manager.NewPrinting += Print;
        }

        public void UnRegister(PrinterManager manager)
        {
            manager.NewPrinting -= Print;
        }

    }
}