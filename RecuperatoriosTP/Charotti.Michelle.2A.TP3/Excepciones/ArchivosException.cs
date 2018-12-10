using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        #region constructor
        public ArchivosException(Exception innerException) : base("\nError, en el archivo", innerException)
        { }
        #endregion
    }
}
