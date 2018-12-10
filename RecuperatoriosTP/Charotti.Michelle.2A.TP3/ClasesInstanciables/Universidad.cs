using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Universidad
    {
        #region Enumerados

        public enum EClases{ Programacion,Laboratorio,Legislacion,SPD}
        #endregion

        #region Atributo

        private List<Alumno> _alumnos;
        private List<Jornada> _jornada;
        private List<Profesor> _profesores;

        #endregion
        #region Propiedades
        public List<Alumno> Alumno
        {
            get{ return this._alumnos;}
            set{ this._alumnos = value;}
        }
        public List<Profesor> Instructores
        {
            get{ return this._profesores;}
            set{ this._profesores = value;}
        }
        public List<Jornada> Jornadas
        {
            get{ return this._jornada; }
            set{ this._jornada = value;}
        }

        /// <summary>
        /// Devuelve y establece un valor de una determinada posicion del array
        /// </summary>
        /// <param name="i">valor de la posicion del array</param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            {
                if (i >= 0 && i < this._jornada.Count)
                {
                    return this._jornada[i];
                }
                else
                {
                    return null;
                }
            }
            set { this._jornada[i] = value;}
        }
        #endregion
        #region Constructor
        public Universidad()
        {
            this._alumnos = new List<Alumno>();
            this._jornada = new List<Jornada>();
            this._profesores = new List<Profesor>();
        }

        #endregion
        #region Metodos
        /// <summary>
        /// guarda los datos de la instancia pasada por parametro en un archivo xml
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> x = new Xml<Universidad>();

            return x.Guardar("..\\..\\Universidad.Xml", uni);
        }

        /// <summary>
        /// devuelve los datos de la universidad
        /// </summary>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");

            foreach (Jornada item in uni._jornada)
            {
                sb.AppendLine(item.ToString());
                sb.AppendLine("<--------------------------------->\n");
            }

            return sb.ToString();
        }


        #endregion
        #region SobreCargas

        /// <summary>
        /// Devuelve los datos de la universidad
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno temporal in g._alumnos)
            {
                if (temporal == a)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;

            foreach (Profesor temporal in g._profesores)
            {
                if (temporal == i)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor retorno = new Profesor();
            int i;
            bool posicion = false;


            for (i = 0; i < u._profesores.Count; i++)
            {
                if (u._profesores[i] == clase)
                {
                    retorno = u._profesores[i];
                    posicion = true;
                    break;
                }
            }
            if (posicion == false)
            {

                throw new SinProfesorException();
            }
            return retorno;

        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor retorno = new Profesor();
            int i;

            for (i = 0; i < u._profesores.Count; i++)
            {
                if (u._profesores[i] != clase)
                {
                    retorno = u._profesores[i];
                    break;
                }
            }

            return retorno;
        }

        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada nuevaJornada = new Jornada(clase, g == clase);
            foreach (Alumno alumno in g._alumnos)
            {
                if (alumno == clase)
                    nuevaJornada += alumno;
            }
            g._jornada.Add(nuevaJornada);
            return g;
        }

        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g == a)
            {
                throw new AlumnoRepetidoException();
            }
            else
            {
                g._alumnos.Add(a);
            }

            return g;
        }

        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
            {
                g._profesores.Add(i);
            }

            return g;
        }
        #endregion
    }
}
