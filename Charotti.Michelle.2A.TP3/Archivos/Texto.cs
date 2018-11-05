using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto: IArchivo<string>
    {
        /// <summary>
        /// toma los datos y los guarda en un archivo de texto
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = true;
            try
            {
                StreamWriter sw = new StreamWriter(archivo, false);
                sw.WriteLine(datos);
                sw.Close();
            }
            catch (Exception)
            {
                retorno = false;
                throw new ArchivosException("No se pudo guardar el archivo");
            }
            return retorno;
        }

        /// <summary>
        /// lee los datos de el path archivo y los pasa a una variable para mostrarlos por consola
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, string datos)
        {
            throw new NotImplementedException();
        }

        public bool Leer(string archivo, out string datos)
        {
            bool retorno = true;
            try
            {
                StreamReader sr = new StreamReader(archivo);           
                    datos = sr.ReadLine();
            }
            catch (Exception)
            {
                retorno = false;
                throw new ArchivosException("No se puede leer el archivo"); 
            }
            return retorno;
        }
    }
}
