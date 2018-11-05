using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;


namespace ClasesInstanciables
{
    public class Universidad
    {
        public enum EClases { Programacion,Laboratorio,Legislacion,SPD}
        #region atributos
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion
        #region propiedades
        public List<Alumno> Alumnos {
            get { return this.alumnos; }
            set { this.alumnos = value; } }
        public List<Profesor> Instructores {
            get { return this.profesores; }
            set { this.profesores = value; } }
        public List<Jornada> Jornadas {
            get { return this.jornada; }
            set { this.jornada = value; } }
        public Jornada this[int i] {
            get {
                if (i >= 0 && i <= Jornadas.Count)
                {
                    return this.Jornadas[i];
                }
                return null;
            }
            set {
                if (i >= 0 && i < jornada.Count)
                {
                    this.Jornadas[i] = value;
                }
            } }
        #endregion
        #region constructor
        public Universidad()
        {
            this.Jornadas = new List<Jornada>();
            this.Instructores = new List<Profesor>();
            this.Alumnos = new List<Alumno>();
        }
        #endregion
        #region metodos
        /// <summary>
        /// guarda los datos de la instancia pasada por parametro en un archivo xml
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> miUni = new Xml<Universidad>();

            return miUni.Guardar("Universidad.xml", uni);
        }
        /// <summary>
        /// devuelve los datos de la universidad
        /// </summary>
        /// <returns></returns>
        private string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Jornada i in uni.Jornadas)
            {
                sb.AppendLine(i.ToString());
            }
            sb.AppendLine("<------------------------------------------->");
            sb.AppendLine("ALUMNOS");
            sb.AppendLine("<------------------------------------------->");

            foreach (Alumno i in uni.Alumnos)
            {
                sb.AppendLine(i.ToString());
            }

            sb.AppendLine("<------------------------------------------->");
            sb.AppendLine("profesores de la universidad");
            sb.AppendLine("<------------------------------------------->");

            foreach (Profesor i in uni.Instructores)
            {
                sb.AppendLine(i.ToString());
            }
            return sb.ToString();
        }
        #endregion
        #region sobrecargas
        public static bool operator !=(Universidad g,Alumno a)
        {
            return !(g == a);
        }
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor p in u.Instructores)
            {
                if (p != clase)
                { return p; }
            }
            throw new SinProfesorException("Todos los profesores pueden dar esta clase");
        }
        public static Universidad operator +(Universidad g,EClases clase)
        {
            foreach (Profesor i in g.Instructores)
            {
                if (i == clase)
                {
                    Jornada jornada = new Jornada(clase, i);

                    foreach (Alumno a in g.Alumnos)
                    {
                        if (a == clase)
                        {
                           // jornada.Alumnos.Add(a);
                            jornada += a;
                        }
                    }
                    g.Jornadas.Add(jornada);
                    break;
                }
                throw new SinProfesorException("No hay profesor para dar esta clase");
            }
            return g;
        }
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g != a)
            {
                g.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException("Alumno repetido");
            }
            return g;
        }
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
            {
                g.Instructores.Add(i);
            }
            else
            {
                throw new Exception("Profesor repetido.");
            }
            return g;
        }
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;
            foreach (Alumno i in g.Alumnos)
            {
                if (i.Equals(a))
                {
                    retorno = true;
                }
            }
            return retorno;
        }
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno=false;
            foreach (Profesor p in g.Instructores)
            {
                if (p == i)
                { retorno = true; }
            }
            return retorno;
        }
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor p in u.Instructores)
            {
                if (p == clase)
                { return p; }
            }
            throw new SinProfesorException("No hay ningun profesor disponible"); ;
        }
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
        #endregion
    }
}
