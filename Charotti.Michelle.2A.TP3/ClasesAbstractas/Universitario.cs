using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region atributos
        private int legajo;
        #endregion
        #region constructores
        public Universitario():base()
        {
        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion
        #region metodos
        /// <summary>
        /// Muestra los datos de la clase 
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            return "\nLEGAJO NUMERO:" + this.legajo+base.ToString();
        }

        protected abstract string ParticiparEnClase();
        
        #endregion
        #region sobrecargas
        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj is Universitario)
            {
                if (this == (Universitario)obj)
                {
                    retorno=true;
                }
            }
            return retorno;
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg2 == pg1);
        }

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return (pg1.legajo==pg2.legajo || pg1.DNI==pg2.DNI);
        }
        #endregion
    }
}
