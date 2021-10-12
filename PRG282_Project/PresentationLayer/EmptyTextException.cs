using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG282_Project.PresentationLayer
{
    class EmptyTextException : Exception
    {
        public EmptyTextException() 
        { 
        }
        public EmptyTextException(string message) : base(message)
        {
        }
        public EmptyTextException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
