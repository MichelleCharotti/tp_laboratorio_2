using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
   public class DniInvalidoException:Exception
    {
        #region propiedad
        private string mensajeBase;
        #endregion
        #region constructores
        public DniInvalidoException():this("El DNI es invalido")
        { }
        public DniInvalidoException(Exception e):this("El DNI es invalido",e)
        { }
        public DniInvalidoException(string message):base(message)
        {
            this.mensajeBase = message;
        }
        public DniInvalidoException(string message,Exception e):base(message,e)
        {
            this.mensajeBase = message;
        }
        #endregion
    }
}
