using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExam.Exceptions
{
    class PrinterDoesntExistException:Exception
    {
        public PrinterDoesntExistException() : base()
        {

        }

        public PrinterDoesntExistException(string message) : base(message)
        {

        }

        public PrinterDoesntExistException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
