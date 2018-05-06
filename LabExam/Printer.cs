using System;
using System.IO;

namespace LabExam
{
    public abstract class Printer : IEquatable<Printer>
    {
        public Printer(string name, string model)
        {
            if (string.IsNullOrWhiteSpace(name))  
            {
                throw new ArgumentException(nameof(name));
            }

            if (string.IsNullOrWhiteSpace(model))
            {
                throw new ArgumentException(nameof(model));
            }

            Name = name;
            Model = model;
        }

        public event EventHandler<PrintEventArgs> StartPrint = delegate { };

        public event EventHandler<PrintEventArgs> EndPrint = delegate { };

        public string Name { get; private set; }

        public string Model { get; private set; }

        public bool Equals(Printer other)
        {
            if (other is null) 
            {
                return false;
            }

            if (this.Name == other.Name && this.Model == other.Model)
            {
                return true;
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            if (obj.GetType() == this.GetType())
            {
                return this.Equals((Printer)obj);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Model.GetHashCode() ^ this.Name.GetHashCode();
        }

        public void Print(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            OnStartPrint(new PrintEventArgs(this));
            EmulatePrint(stream);
            OnEndPrint(new PrintEventArgs(this));
        }

        protected abstract void EmulatePrint(Stream stream);

        protected virtual void OnStartPrint(PrintEventArgs e) => StartPrint?.Invoke(this, e);

        protected virtual void OnEndPrint(PrintEventArgs e) => EndPrint?.Invoke(this, e);
    }
}