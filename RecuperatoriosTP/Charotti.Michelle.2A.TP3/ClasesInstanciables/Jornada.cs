using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Jornada
    {
        #region atributos
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;
        #endregion
        #region Propiedades
        public List<Alumno> Alumnos
        {
            get{ return this._alumnos;}
            set{ this._alumnos = value; }
        }
        public Universidad.EClases Clase
        {
            get{ return this._clase;}
            set{ this._clase = value;}
        }
        public Profesor Instructor
        {
            get{return this._instructor;}
            set{ this._instructor = value; }
        }
        #endregion
        #region Constructores
        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }
        public Jornada(Universidad.EClases clase, Profesor instructor): this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }
        #endregion
        #region Metodos
        /// <summary>
        /// guarda el archivo Jornada.txt con los datos actuales
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto t = new Texto();

            return t.Guardar("..\\..\\Jornada.txt", jornada.ToString());
        }
        /// <summary>
        /// lee el archivo Jornada.txt
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            string retorno = "";
            Texto t = new Texto();

            t.Leer("..\\..\\Jornada.txt", out retorno);

            return retorno;
        }

        #endregion
        #region SobreCargas
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno temporal in j._alumnos)
            {
                if (temporal == a)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j._alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return j;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("\nClase: {0},\nInstructor: {1}", this._clase.ToString(), this._instructor.ToString());
            sb.AppendLine("Alumnos:");
            foreach (Alumno item in this._alumnos)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
        #endregion
    }
}
