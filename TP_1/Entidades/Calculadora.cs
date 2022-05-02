using System;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Realiza suma, resta, multiplicación y división -dependiendo del parámetro operador- 
        /// </summary>
        /// <param name="num1">un objeto de tipo Operando</param>
        /// <param name="num2">otro objeto de tipo Operando</param>
        /// <param name="operador">operador de tipo CHAR</param>
        /// <returns>El resultado de la operación; o valor 0 si no pasa la validación del operador</returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double result = 0;

            if (ValidarOperador(operador) != '+')
            {
                switch (operador)
                {
                    case '+':
                        result = num1 + num2;
                        break;

                    case '-':
                        result = num1 - num2;
                        break;

                    case '*':
                        result = num1 * num2;
                        break;

                    case '/':
                        result = num1 / num2;
                        break;
                }
            }

            return result;
        }


        /// <summary>
        /// Realiza una validación del operador seleccionado por el usuario al realizar la operación.
        /// </summary>
        /// <param name="operador">el operador de tipo CHAR</param>
        /// <returns>'+' si es una cadena vacía; '-' si es uno de los cuatro operadores solicitados (+, -, *, /)</returns>
        private static char ValidarOperador(char operador) => operador.ToString() == string.Empty ? '+' : '-';
    }
}
