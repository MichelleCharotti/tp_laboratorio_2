using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
   
    /// <summary>
    /// La clase Producto no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
        public enum EMarca
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }
        #region atributos
        private EMarca _marca;
        private string _codigoDeBarras;
        private ConsoleColor _colorPrimarioEmpaque;
        #endregion
        #region propiedades
        /// <summary>
        /// ReadOnly: Retornará la cantidad de ruedas del vehículo
        /// </summary>
        /*abstract*/
        protected abstract short CantidadCalorias { get; }
        #endregion
        #region constructores
        public Producto(string patente,EMarca marca, ConsoleColor color)
        {
            this._marca = marca;
            this._colorPrimarioEmpaque = color;
            this._codigoDeBarras = patente;
        }
        #endregion
        #region metodos
        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }
        #endregion
        #region sobrecargas y operadores
        public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CODIGO DE BARRAS: {0}\r\n", p._codigoDeBarras);
            sb.AppendFormat("MARCA          : {0}\r\n", p._marca.ToString());
            sb.AppendFormat("COLOR EMPAQUE  : {0}\r\n", p._colorPrimarioEmpaque.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            return (v1._codigoDeBarras == v2._codigoDeBarras);
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return !(v1 == v2);
        }
        #endregion
    }
}
