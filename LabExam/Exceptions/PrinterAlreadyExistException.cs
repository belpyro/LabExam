using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExam.Exceptions
{
    public class PrinterAlreadyExistException:Exception
    {
        public PrinterAlreadyExistException():base()
        {

        }

        public PrinterAlreadyExistException(string message) : base(message)
        {

        }

        public PrinterAlreadyExistException(string message,Exception innerException) : base(message, innerException)
        {

        }
    }
}
