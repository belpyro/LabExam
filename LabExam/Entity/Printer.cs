using LabExam.Entity;

namespace LabExam.Entity
{
    /// <summary>
    /// Class describing printer in general
    /// </summary>
    public sealed class Printer : BasePrinter
    {
        public Printer(string name, string model)
        {
            this.Name = name;

            this.Model = model;
        }
    }
}