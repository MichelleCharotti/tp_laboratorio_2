using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    interface IArchivo<T>
    {
        #region Metodos
        /// <summary>
        /// Metodo de Interfaz para guardar datos
        /// </summary>
        /// <param name="archivos"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool Guardar(string archivos, T datos);

        /// <summary>
        /// Metodo de Interfaz para leer datos
        /// </summary>
        /// <param name="archivos"></param>
        /// <param name="datos"></param>
        /// <returns><</returns>
        bool Leer(string archivos, out T datos);

        #endregion
    }
}
