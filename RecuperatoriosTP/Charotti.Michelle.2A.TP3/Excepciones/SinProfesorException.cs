using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        #region constructor
        public SinProfesorException() : base("\nNo hay profesor para la clase.")
        {}
        #endregion
    }
}
