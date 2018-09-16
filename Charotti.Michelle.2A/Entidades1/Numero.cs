using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace Entidades1
{
   public class Numero
    {

        #region atributo
        private double _numero;
        #endregion
        #region propiedad
        public string SetNumero
        {
            set
            {
                this._numero = this.ValidarNumero(value);
            }
        }
        #endregion
        #region constructores
        public Numero()
        {
            this._numero = 0;
        }

        public Numero(double numero)
        {
            this._numero = numero;
        }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        #endregion
        #region metodos
        /// <summary>
        /// Valida si el parametro que se le pasa es un numero
        /// </summary>
        /// <param name="strNumero">Recibe un string</param>
        /// <returns>Retorna un numero double si es un numero valido o 0 si no lo es</returns>
        private double ValidarNumero(string strNumero) 
        {
            double valor;

            if (double.TryParse(strNumero, out valor))
            {
             return valor;
            }
                
            else
            {
             return 0;
            }
        }

        /// <summary>
        /// Convierte un numero binario a decimal
        /// </summary>
        /// <param name="binario">Recibe un string</param>
        /// <returns>Retorna el numero en decimal o sino un mensaje de error</returns>
        public string BinarioDecimal(string binario)
        {   
            string cadena = "";
            Regex val = new Regex(@"[0-1]$");

            binario = binario.Replace(" ", "");

            if (val.IsMatch(binario))
            {
                binario = RevertirString(binario);
                int digito;
                int i = 0;
                double numDouble = 0;

                while (binario.Contains("0") || binario.Contains("1"))
                {
                    digito = (int)Char.GetNumericValue(binario[i]);
                    numDouble += digito * (Math.Pow(2, i));
                    i++;

                    if (i == binario.Length)
                    {
                        break;
                    }
                }
                cadena= numDouble.ToString();
            }
            else
            {
                cadena= "Valor invalido";
            }
            return cadena;
        }

        /// <summary>
        /// Revierte un string del ultimo al primero
        /// </summary>
        /// <param name="str">Recibe un string</param>
        /// <returns>Retorna invertido el string</returns>
        public static string RevertirString(string str)
        {
            char[] cadena = str.ToCharArray();
            Array.Reverse(cadena);
            return new string(cadena);
        }
     
        /// <summary>
        /// Convierte un numero decimal a binario
        /// </summary>
        /// <param name="numero">Recibe un double</param>
        /// <returns>Retorna un numero binario</returns>
        public string DecimalBinario(double numero)
        {
            string cadena = "";
            int numDecimal = Convert.ToInt32(numero);

            if (numDecimal == 0)
            {
                cadena = "0";
            }

            while (numDecimal > 0)
            {
                double operacion = numDecimal % 2;
                numDecimal /= 2;

                if (operacion == 0 || operacion == 1)
                {
                    cadena += Convert.ToString(operacion) + "";
                }
            }

            return RevertirString(cadena);
        }

        /// <summary>
        /// Convierte un numero decimal a binario
        /// </summary>
        /// <param name="numero">Recibe un string</param>
        /// <returns>Retorna un numero binario</returns>
        public string DecimalBinario(string numero)
        {
            string cadena = "";

            cadena = this.DecimalBinario(Convert.ToDouble(numero));

            return cadena;
        }
        #endregion
        #region sobrecarga
         public static double operator -(Numero n1,Numero n2)
         {
             return n1._numero - n2._numero;
         }

        public static double operator +(Numero n1,Numero n2)
        {
            return n1._numero + n2._numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1._numero * n2._numero;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            return n1._numero / n2._numero;
        }
        #endregion
    }
}
