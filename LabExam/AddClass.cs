using System;
using System.Collections.Generic;



namespace LabExam
{
    class AddClass
    {
        static AddClass()
        {
            Printers = new List<object>();
        }

        public static List<object> Printers { get; set; }

        public static void Add(Printer p1)
        {
            if (!Printers.Contains(p1))
            {
                Printers.Add(p1);
                Console.WriteLine("Printer added");
            }
        }
    }
}
