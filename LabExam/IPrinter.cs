using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExam
{
    interface IPrinter
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get;}

        /// <summary>
        /// Gets the model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        string Model { get;}

        /// <summary>
        /// Prints the specified file stream.
        /// </summary>
        /// <param name="fileStream">The file stream.</param>
        void Print(FileStream fileStream);
    }
}
