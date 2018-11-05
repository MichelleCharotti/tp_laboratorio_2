using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;
using Excepciones;

namespace ClasesInstanciables
{

    public sealed class Alumno:Universitario
    {
        public enum EEstadoCuenta { AlDia,Deudor,Becado}
        #region atributos
        public Universidad.EClases claseQueToma;
        public EEstadoCuenta estadoCuenta;
        #endregion
        #region constructores
        public Alumno():base()
        { }
        public Alumno(int id,string nombre,string apellido,string dni,ENacionalidad nacionaledad,Universidad.EClases claseQueToma):base(id,nombre,apellido,dni,nacionaledad)
        {
            this.claseQueToma = claseQueToma;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionaledad,Universidad.EClases claseQueToma,EEstadoCuenta estadoCuenta):this(id,nombre,apellido,dni,nacionaledad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion
        #region metodos
        /// <summary>
        /// devuelve los datos del alumno
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() +this.ParticiparEnClase();
        }
        /// <summary>
        /// devuelve las clases que toma el alumno
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return "\nTOMA CLASE DE "+this.claseQueToma;
        }
        #endregion
        #region sobrecargas
        public static bool operator !=(Alumno a,Universidad.EClases clase)
        {
            return !(a == clase);
        }
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return (a.claseQueToma == clase && a.estadoCuenta!=EEstadoCuenta.Deudor);
        }
        public override string ToString()
        {
            return this.MostrarDatos(); 
        }
        #endregion
    }
}
