using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excepciones;

namespace ClasesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad { Argentino, Extranjero }

        #region atributos
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion
        #region propiedades
        public string Apellido
        {
            get { return this.apellido; }
            set {
                if (ValidarNombreApellido(value) != "INVALIDO")
                    this.apellido = value;
            }
        }

        public int DNI
        {
            get { return this.dni; }
            set { this.dni = this.ValidarDni(this.Nacionalidad, value); }//value; }
        }

        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set {
                if (value == ENacionalidad.Argentino || value == ENacionalidad.Extranjero)
                { this.nacionalidad = value; }
                else
                { throw new NacionalidadInvalidaException("La nacionalidad es inválida!"); }
            }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set {
                if (ValidarNombreApellido(value) != "INVALIDO")
                    this.nombre = value;
            }
        }

        public string StringToDNI
        {
            set
            {
                int aux = ValidarDni(this.Nacionalidad, value);

                if (aux != 0)
                {
                   this.DNI = aux;
                }
                else
                {
                    throw new DniInvalidoException("El DNI es invalido.");
                }
            }
        }
        #endregion
        #region constructores
        public Persona()
        {
        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
        this.DNI=dni;
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
            
           if(ENacionalidad.Argentino ==nacionalidad)
            {
                if(dato<=89999999 && dato>=1)
                {
                    return dato;
                }
            }
            else 
            {
                if (dato <= 99999999 && dato >= 90000000)
                {
                   return dato;
                }
            }
       
                throw new NacionalidadInvalidaException("La nacionalidad no se condice con el numero de DNI");
        }

        /// <summary>
        /// intenta parsear el dni en forma de string "dato" y se lo pasa a ValidarDni()
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            return this.ValidarDni(nacionalidad,Convert.ToInt32(dato));
        }

        /// <summary>
        /// Validará que los nombres sean cadenas con caracteres válidos para nombres. Caso contrario, no se cargará.
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            if (Regex.IsMatch(dato, @"^[a-zA-Z]+$"))
            { return dato; }

            return "INVALIDO";
        }
        #endregion
        #region sobrecarga
        /// <summary>
        /// devuelve los datos de la persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "\nNOMBRE COMPLETO:" + this.Apellido +" "+ this.Nombre + "\nNACIONALIDAD:" + this.Nacionalidad+ "\nDNI:" + this.dni;
        }
        #endregion
    }
}