using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        #region atributos
        private string _mensajeBase;
        #endregion
        #region Metodos
        public DniInvalidoException() : this("DNI invalido")
        {
        }
        public DniInvalidoException(Exception e):this("\nDNI con formato erroneo.", e)
        {
        }
        public DniInvalidoException(string message) : base(message)
        {
            this._mensajeBase = message;
        }
        public DniInvalidoException(string message, Exception e) : base(message, e)
        {
        }
        #endregion
    }
    }
