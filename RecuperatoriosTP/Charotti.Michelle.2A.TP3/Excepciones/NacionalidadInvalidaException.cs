using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        #region constructor
        public NacionalidadInvalidaException():this("Nacionaliad Invalida")
        {}
        public NacionalidadInvalidaException(string message):base(message)
        {}
        #endregion
    }
}