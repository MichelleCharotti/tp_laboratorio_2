using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        #region Enumerados

        public enum EEstadoCuenta { AlDia, Deudor, Becado }

        #endregion
        #region Atributos

        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        #endregion
        #region Constructores
        public Alumno() : base()
        {
            this._claseQueToma = default(Universidad.EClases);
            this._estadoCuenta = default(EEstadoCuenta);
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma): base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        #endregion
        #region metodo
        /// <summary>
        /// devuelve los datos del alumno
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());

            switch (this._estadoCuenta)
            {
                case EEstadoCuenta.AlDia:
                    sb.AppendLine("\nEstado de Cuenta: Cuota al dia");
                    break;
                case EEstadoCuenta.Becado:
                    sb.AppendLine("\nEstado de Cuenta: Becado");
                    break;
                case EEstadoCuenta.Deudor:
                    sb.AppendLine("\nEstado de Cuenta:Deudor");
                    break;
                default:
                    break;
            }

            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// devuelve las clases que toma el alumno
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return String.Format("\nToma clase de: {0}", this._claseQueToma.ToString());
        }
        #endregion
        #region sobrecarga
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return (a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor);
        }
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return (a._claseQueToma != clase);
        }
        #endregion
    }
}
