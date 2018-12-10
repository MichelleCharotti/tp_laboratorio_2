using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        #region Metodos
        /// <summary>
        /// toma los datos y los guarda en un archivo de texto
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter streamWriter = null;

            try
            {
                streamWriter = new StreamWriter(archivo);
                streamWriter.Write(datos);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                if (!(streamWriter is null))
                    streamWriter.Close();
            }
            return true;
        }
        /// <summary>
        /// lee los datos de el path archivo y los pasa a una variable para mostrarlos por consola
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            StreamReader streamReader = null;
            datos = "";

            try
            {
                streamReader = new StreamReader(archivo);
                datos = streamReader.ReadToEnd();
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                if (!(streamReader is null))
                    streamReader.Close();
            }
            return true;
        }

        #endregion
    }
}
