using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T> where T : new()
    {
        /// <summary>
        /// guarda datos de tipo T en el path de archivo xml
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = true;
            try
            {
            TextWriter tw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @archivo, false);
            XmlSerializer objXml = new XmlSerializer(typeof(T), "");
            objXml.Serialize(tw, datos);
            tw.Close();
            
            }
            catch (Exception)
            {
                retorno = false;
                throw new ArchivosException("No se pudo guardar el archivo XML");
            }
            return retorno;
         }

        /// <summary>
        /// lee datos de tipo T desd eel path archivo xml y los guarda en una variable para mostrarlo
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, T datos)
        {
            throw new NotImplementedException();
        }

        public bool Leer(string archivo, out T datos)
        {
            bool retorno = true;
            try
            {
               datos = new T();

                TextReader tr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @archivo, true);
                XmlSerializer objXml = new XmlSerializer(typeof(T), datos.ToString());

                T p = (T)objXml.Deserialize(tr);
                Console.WriteLine(p.ToString());

                tr.Close();
            }
            catch (Exception)
            {
                retorno = false;
                throw new ArchivosException("No se pudo leer el archivo XML");
            }
            return retorno;
        }
    }
}
