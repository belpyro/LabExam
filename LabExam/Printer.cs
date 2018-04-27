using System;
using System.IO;

namespace LabExam
{
    internal class Printer : IPrinter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Printer"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="model">The model.</param>
        /// <exception cref="ArgumentNullException">
        /// Name is empty!
        /// or
        /// Model is empty!
        /// </exception>
        public Printer(string name, string model)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name is empty!");
            }

            if (String.IsNullOrWhiteSpace(model))
            {
                throw new ArgumentNullException("Model is empty!");
            }

            this.Name = name;
            this.Model = model;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get ;}

        /// <summary>
        /// Gets the model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        public string Model { get;}

        /// <summary>
        /// Prints the specified file stream.
        /// </summary>
        /// <param name="fileStream">The file stream.</param>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void Print(FileStream fileStream)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Prints the specified file stream.
        /// </summary>
        /// <param name="fileStream">The file stream.</param>
        void IPrinter.Print(FileStream fileStream)
        {
            this.Print(fileStream);
        }
    }
}