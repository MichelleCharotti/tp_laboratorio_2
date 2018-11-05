using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Archivos;
using Excepciones;

namespace ClasesInstanciables
{
    public class Jornada
    {
        #region atributos
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion
        #region propiedades
        public List<Alumno> Alumnos {
            get { return this.alumnos; } 
            set { this.alumnos = value; } }

        public Universidad.EClases Clase {
            get { return this.clase; }
            set { this.clase = value; } }

        public Profesor Instructor {
            get { return this.instructor; }
            set { this.instructor = value; } }
        #endregion
        #region constructores
        private Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase,Profesor instructor):this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion
        #region metodos
        /// <summary>
        /// guarda el archivo Jornada.txt con los datos actuales
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto jor = new Texto();
            return jor.Guardar("Jornada.txt", jornada.ToString());
        }
        /// <summary>
        /// lee el archivo Jornada.txt
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            
            Texto jor = new Texto();
            string retorno;
            jor.Leer("Jornada.txt",out retorno);

            return retorno;
        }
        #endregion
        #region sobrecargas
        public static bool operator !=(Jornada j,Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
           if(j!=a)
            {
                j.Alumnos.Add(a);
            }
            return j;
        }

        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;
            foreach (Alumno e in j.Alumnos)
                if (e == a)
                {
                    retorno = true;
                }
            return retorno;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA:");
            sb.AppendFormat("CLASE DE {0} POR NOMBRE COMPLETO: {1}\n",this.Clase ,this.Instructor.ToString());
            
            sb.AppendLine("\nALUMNOS:");
            foreach (Alumno a in this.Alumnos)
            {
                sb.AppendLine(a.ToString());
            }
            return sb.ToString();
        }
        #endregion
    }
}
