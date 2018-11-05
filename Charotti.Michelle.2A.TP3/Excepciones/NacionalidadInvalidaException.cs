using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
   public class NacionalidadInvalidaException:Exception
    {
        #region constructores
        public NacionalidadInvalidaException()
        { }
        public NacionalidadInvalidaException(string menssage) : base(menssage)
        {
        }
        #endregion
    }
}
