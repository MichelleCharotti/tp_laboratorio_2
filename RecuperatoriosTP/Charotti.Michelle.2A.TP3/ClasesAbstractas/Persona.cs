using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excepciones;

namespace ClasesAbstractas
{
    public abstract class Persona
    {
        #region Enumerado aninado

        public enum ENacionalidad{ Argentino, Extranjero}

        #endregion

        #region Atributos

        private string apellido;
        private string nombre;
        private int dni;
        private ENacionalidad nacionalidad;

        #endregion

        #region Propiedades

        public string Apellido
        {
            get
            {
                return this.apellido;
            }

            set
            {
                this.apellido = this.ValidarNombreApellido(value);
            }
        }

        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }

            set
            {
                this.nacionalidad = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }

            set
            {
                this.nombre = this.ValidarNombreApellido(value);
            }
        }

        public string StringToDNI
        {
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }
        #endregion
        #region Constructores
        public Persona()
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region metodos
        /// <summary>
        /// comprueba si el dni "dato" condice con la nacionalidad
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns> 
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int dni = 0;

            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato >= 1 && dato <= 89999999)
                    {
                        dni = dato;
                    }
                    else
                    {
                        throw new NacionalidadInvalidaException();
                    }
                    break;
                case ENacionalidad.Extranjero:
                    if (dato >= 90000000 && dato <= 99999999)
                    {
                        dni = dato;
                    }
                    else
                    {
                        throw new NacionalidadInvalidaException();
                    }
                    break;
                default:
                    break;
            }

            return dni;
        }

        /// <summary>
        /// intenta parsear el dni en forma de string "dato" y comprueba si el dni "dato" condice con la nacionalidad
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni;
            int aux = 0;

            if (dato.Length >= 1 && dato.Length <= 8 && (int.TryParse(dato, out aux)))
            {
                dni = aux;
            }
            else
            {
                throw new DniInvalidoException();
            }
            return dni;
        }

        /// <summary>
        /// Validará que los nombres sean cadenas con caracteres válidos para nombres. Caso contrario, no se cargará.
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            Regex regex = new Regex("[a-zA-Z]");
            string cadena = "";

            foreach (Match match in regex.Matches(dato))
            {
                cadena += match.Value;
            }

            return cadena;
        }
        #endregion
        #region sobrecarga
        /// <summary>
        /// devuelve los datos de la persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "NOMBRE COMPLETO:" + this.Apellido + " " + this.Nombre + "\nNACIONALIDAD:" + this.Nacionalidad + "\nDNI:" + this.dni;
        }

        #endregion
    }
}
