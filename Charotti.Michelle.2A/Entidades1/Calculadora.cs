using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades1
{
    public class Calculadora
    {
        /// <summary>
        ///  Valida si el operador es correcto
        /// </summary>
        /// <param name="operador"> Recibe un string operador</param>
        /// <returns>Retorna el operador y si no es correcto devuelve "+" </returns>
        private static string ValidarOperador(string operador)
        {
        string retorno="";

            switch (operador)
            {
                case "+":
                    retorno = operador;
                    break;
                case "-":
                    retorno = operador;
                    break;
                case "/":
                    retorno = operador;
                    break;
                case "*":
                    retorno = operador;
                    break;
                default:
                    retorno = "+";
                    break;
            }
            return retorno;
        }

        /// <summary>
        /// Valida y realiza las operaciones entre los dos parametros
        /// </summary>
        /// <param name="num1">Recibe una clase Numero</param>
        /// <param name="num2">Recibe una clase Numero</param>
        /// <param name="operador">Recibe un string</param>
        /// <returns>Retorna el resultado de las operaciones</returns>
        public double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado=0;
            string operadores;

            operadores = ValidarOperador(operador);

            switch(operadores)
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
            }
            return resultado;
        }

    }
}
