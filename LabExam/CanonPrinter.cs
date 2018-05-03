namespace LabExam
{
    /// <summary>
    /// Canon Printer
    /// </summary>
    internal class CanonPrinter : Printer
    {
        public CanonPrinter() : base("Canon", "123x")//calls Printer's constrctor with needed parameters, nothing else needed as buisness logic is the same as in the parrent class
        {
        }
    }
}