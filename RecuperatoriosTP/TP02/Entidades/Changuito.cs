using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Changuito
    {
        public enum ETipo
        {
            Dulce, Leche, Snacks, Todos
        }
        #region atributos
        private List<Producto> _productos;
        private int _espacioDisponible;
        #endregion

        #region "Constructores"
        /// <summary>
        /// inicializa la lista
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="patente"></param>
        /// <param name="color"></param>
        private Changuito()
        {
            this._productos = new List<Producto>();
        }
        /// <summary>
        /// constructor con parametro
        /// </summary>
        /// <param name="espacioDisponible"></param>
        public Changuito(int espacioDisponible):this()
        {
            this._espacioDisponible = espacioDisponible;
        }
        #endregion

       

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Mostrar(Changuito c, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles\n", c._productos.Count, c._espacioDisponible);
            sb.AppendLine("");
            foreach (Producto v in c._productos)
            {
                switch (tipo)
                {
                    case ETipo.Snacks:
                        if(v is Snacks)
                        {
                            sb.AppendLine(((Snacks)v).Mostrar());
                        }
                        
                        break;
                    case ETipo.Dulce:
                        if(v is Dulce)
                        {
                            sb.AppendLine(((Dulce)v).Mostrar());
                        }
                        break;
                    case ETipo.Leche:
                        if(v is Leche)
                        {
                            sb.AppendLine(((Leche)v).Mostrar());
                        }
                        break;
                    default:
                            sb.AppendLine(v.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region Sobrecargas y operadores
        /// <summary>
        /// Muestro el Changuito y TODOS los Productos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Changuito.Mostrar(this, ETipo.Todos);
        }

        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns></returns>
        public static Changuito operator +(Changuito c, Producto p)
        {
            if(c._productos.Count >=c._espacioDisponible)
            {
                return c;
            }
            foreach (Producto v in c._productos)
            {
                if (v == p)
                {
                    return c;
                }
            }

            c._productos.Add(p);
            return c;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns></returns>
        public static Changuito operator -(Changuito c, Producto p)
        {
            foreach (Producto v in c._productos)
            {
                if (v == p)
                {
                    c._productos.Remove(v);
                    break;
                }
            }

            return c;
        }
        #endregion
    }
}
