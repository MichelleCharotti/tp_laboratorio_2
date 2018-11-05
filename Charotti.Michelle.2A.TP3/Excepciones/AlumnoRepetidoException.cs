using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException:Exception
    {
        #region constructores
        public AlumnoRepetidoException(string menssage) : base(menssage)
        { }
        #endregion
    }
}
