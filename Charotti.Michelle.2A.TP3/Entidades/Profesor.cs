using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;

namespace ClasesInstanciables
{
   public sealed class Profesor:Universitario
    {
        #region atributos
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion
        #region constructores
        public Profesor():base()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
        }

        static Profesor()
        {
            Profesor.random = new Random();
        }

        public Profesor(int id,string nombre,string apellido,string dni,ENacionalidad nacionalidad):base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        #endregion
        #region metodos
        /// <summary>
        /// genera un numero random, lo castea a EClases y lo agrega a la queue del profesor dos veces
        /// </summary>
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)(Profesor.random.Next(3)));
        }
        /// <summary>
        /// Muestra los datos del profesor
        /// </summary>
        protected override string MostrarDatos()
        {
              return base.MostrarDatos() + this.ParticiparEnClase();
        }
        /// <summary>
        /// devuelve las clases del dia del profesor
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            string retorno= "CLASES DEL DIA ";
            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                retorno="\n"+clase.ToString();
            }
            return retorno;
        }
        #endregion
        #region sobrecargas
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        public static bool operator!=(Profesor i,Universidad.EClases clase)
        {
            return !(i==clase);
        }
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;
            foreach (Universidad.EClases e in i.clasesDelDia)
                if (e == clase)
                {
                    retorno= true;
                }
            return retorno;
        }
        #endregion
    }
}
