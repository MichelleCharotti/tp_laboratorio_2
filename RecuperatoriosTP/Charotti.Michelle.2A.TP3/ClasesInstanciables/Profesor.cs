using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region Atributos
        private Queue<Universidad.EClases> _claseDelDia;
        private static Random _random;
        #endregion
        #region Constructores
        static Profesor()
        {
            Profesor._random = new Random();
        }
        public Profesor() : base()
        {}
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad): base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseDelDia = new Queue<Universidad.EClases>();
            this._randomClase();
        }

        #endregion
        #region Metodos
        /// <summary>
        /// genera un numero random, lo castea a EClases y lo agrega a la queue del profesor dos veces
        /// </summary>
        private void _randomClase()
        {
            for (int i = 0; i < 2; i++)
            {
                this._claseDelDia.Enqueue((Universidad.EClases)Profesor._random.Next(0, 3));
            }
        }
        /// <summary>
        /// Muestra los datos del profesor
        /// </summary>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// devuelve las clases del dia del profesor
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("\nClase del dia:");

            foreach (Universidad.EClases temporal in this._claseDelDia)
            {
                sb.AppendLine(temporal.ToString());
            }

            return sb.ToString();
        }
        #endregion
        #region SobreCargas
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases claseDelProfesor in i._claseDelDia)
            {
                if (claseDelProfesor == clase)
                    return true;
            }
            return false;
        }
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion
    }
}
