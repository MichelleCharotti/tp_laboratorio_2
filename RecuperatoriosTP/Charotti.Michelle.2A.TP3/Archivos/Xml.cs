using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        #region Metodos
        /// <summary>
        /// guarda datos de tipo T en el path de archivo xml
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            XmlTextWriter writer = null;

            try
            {
                writer = new XmlTextWriter(archivo, Encoding.UTF8);
                xmlSerializer.Serialize(writer, datos);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                if (!(writer is null))
                    writer.Close();
            }
            return true;
        }
        /// <summary>
        /// lee datos de tipo T desd eel path archivo xml y los guarda en una variable para mostrarlo
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            XmlTextReader writer = null;
            datos = default(T);

            try
            {
                writer = new XmlTextReader(archivo);
                datos = (T)serializer.Deserialize(writer);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                if (!(writer is null))
                    writer.Close();
            }
            return true;
        }
        #endregion
    }
}
