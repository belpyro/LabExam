using System.IO;

namespace LabExam
{
    public interface IPrinter
    {
        string Name { get; set; }
        string Model { get; set; }
        void Print(FileStream fs);
    }
}
