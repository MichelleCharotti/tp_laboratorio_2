using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException:Exception
    {
        #region constructores
        public SinProfesorException(string menssage) : base(menssage)
        { }
        #endregion
    }
}
