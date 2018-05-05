using System;
using System.Collections.Generic;
using System.IO;

namespace LabExam.Logic
{
    //when struct it can be created being in the invalid state
    public class Printer:IEquatable<Printer>
    {
        #region constructors
        public Printer(string name, string model)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"{nameof(name)} is null or empty");
            }

            if (String.IsNullOrEmpty(model))
            {
                throw new ArgumentException($"{nameof(model)} is null or empty");
            }

            this.Name = name;
            this.Model = model;
        }
        #endregion

        #region constructors
        public string Name { get; }
        public string Model { get; }
        #endregion

        #region methods
        internal void Print(Stream fs)
        {
            OnPrintStarted(new PrinterEventArgs(this));

            for (int i = 0; i < fs.Length; i++)
            {
                // simulate printing
                Console.WriteLine(fs.ReadByte());
            }

            OnPrintEnded(new PrinterEventArgs(this));
        }

        //to provide a unique
        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }

            if (obj == null)
            {
                return false;
            }

            Printer printer = obj as Printer;

            if(printer != null)
            {
                return printer.Equals(printer);
            }

            return false;
        }

        public bool Equals(Printer printer)
        {
            if (this == printer)
            {
                return true;
            }

            if(printer == null)
            {
                return false;
            }

            return printer != null &&
                   Name == printer.Name &&
                   Model == printer.Model;
        }

        public override int GetHashCode()
        {
            var hashCode = -1566092560;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Model);
            return hashCode;
        }

        public override string ToString()
        {
            return $"{Name}:{Model}";
        }
        #endregion

        #region events
        public event EventHandler<PrinterEventArgs> PrintStarted = delegate { };
        public event EventHandler<PrinterEventArgs> PrintEnded = delegate { };

        protected virtual void OnPrintStarted(PrinterEventArgs args)
        {
            PrintStarted(this, args);
        }

        protected virtual void OnPrintEnded(PrinterEventArgs args)
        {
            PrintEnded(this, args);
        }
        #endregion

    }
}