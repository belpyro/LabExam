namespace LabExam
{
    internal class Printer:AbstractPrinter
    {
        public Printer(string name,string model)
        {
            Name = name;
            Model = model;
        }

        public override string Name { get; set; }

        public override string Model { get; set; }
    }
}