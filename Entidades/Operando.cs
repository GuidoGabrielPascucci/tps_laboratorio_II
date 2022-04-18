using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;


        /// <summary>
        /// CONSTRUCTOR de la clase Operando. Recibe parámetro de tipo double, y lo setea al atributo privado número.
        /// </summary>
        /// <param name="numero">un número de tipo DOUBLE</param>
        public Operando(double numero)
        {
            this.numero = numero;
        }

        // wfwfwfwf

        /// <summary>
        /// CONSTRUCTOR de la clase Operando. Sin parámetros, invoca al constructor que recibe un double y le pasa 0 como valor.  
        /// </summary>
        public Operando() : this(0) {}


        /// <summary>
        /// CONSTRUCTOR de la clase Operando. Recibe un string y lo setea en la propiedad Numero.
        /// </summary>
        /// <param name="strNumero">un número de tipo STRING</param>
        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }


        /// <summary>
        /// SOBRECARGA OPERADOR +
        /// Realiza una SUMA entre dos instancias de clase que poseen cada una un atributo número específico.
        /// </summary>
        /// <param name="n1">un objeto de tipo Operando</param>
        /// <param name="n2">otro objeto de tipo Operando</param>
        /// <returns>La suma de ambos números</returns>
        public static double operator +(Operando n1, Operando n2) => n1.numero + n2.numero;


        /// <summary>
        /// SOBRECARGA OPERADOR -
        /// Realiza una RESTA entre dos instancias de clase que poseen cada una un atributo número específico.
        /// </summary>
        /// <param name="n1">un objeto de tipo Operando</param>
        /// <param name="n2">otro objeto de tipo Operando</param>
        /// <returns>La resta de ambos números</returns>
        public static double operator -(Operando n1, Operando n2) => n1.numero - n2.numero;


        /// <summary>
        /// SOBRECARGA OPERADOR *
        /// Realiza una MULTIPLICACIÓN entre dos instancias de clase que poseen cada una un atributo número específico.
        /// </summary>
        /// <param name="n1">un objeto de tipo Operando</param>
        /// <param name="n2">otro objeto de tipo Operando</param>
        /// <returns>La multiplicación de ambos números</returns>
        public static double operator *(Operando n1, Operando n2) => n1.numero * n2.numero;


        /// <summary>
        /// SOBRECARGA OPERADOR /
        /// Realiza una validación del segundo parámetro, para evaluar si el mismo es distinto de valor 0. Si TRUE realiza
        /// una DIVISIÓN entre dos instancias de clase que poseen cada una un atributo número específico. Si FALSE, devuelve
        /// el double mínimo.
        /// </summary>
        /// <param name="n1">un objeto de tipo Operando</param>
        /// <param name="n2">otro objeto de tipo Operando</param>
        /// <returns>La división de ambos números o double.MinValue</returns>
        public static double operator /(Operando n1, Operando n2) => n2.numero != 0 ? n1.numero / n2.numero : double.MinValue;


        /// <summary>
        /// Propiedad: Numero. Setea el atributo numero previa validación.
        /// </summary>
        public string Numero
        {
            set { this.numero = ValidarOperando(value); }
        }


        /// <summary>
        /// Realiza la comprobación de si el parámetro es un número binario.
        /// </summary>
        /// <param name="binario">un numero tipo STRING</param>
        /// <returns>TRUE si es binario / FALSE si no es binario.</returns>
        private bool EsBinario(string binario)
        {
            bool respuesta = true;

            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] != '0' && binario[i] != '1')
                {
                    respuesta = false;
                    break;
                }
            }

            return respuesta;
        }


        /// <summary>
        /// Convierte un número binario en su equivalente en decimal.
        /// </summary>
        /// <param name="binario">numero de tipo STRING</param>
        /// <returns>el resultado de la conversión (número decimal) o "Valor inválido" si el numero no es binario</returns>
        public string BinarioDecimal(string binario)
        {
            string result = "Valor inválido";
            int resultado = 0;
            
            if (EsBinario(binario))
            {
                int cantidadDeCaracteres = binario.Length;

                foreach (char caracter in binario)
                {
                    cantidadDeCaracteres--;

                    if (caracter == '1')
                    {
                        resultado += (int)Math.Pow(2, cantidadDeCaracteres);
                    }
                }

                result = resultado.ToString();
            }

            return result;
        }


        /// <summary>
        /// Invoca la sobrecarga del mismo método convirtiendo el parámetro de string a double para que realiza la conversión.
        /// </summary>
        /// <param name="numero">un número de tipo STRING</param>
        /// <returns>el resultado de la conversión realizada por la sobrecarga de este método</returns>
        public string DecimalBinario(string numero)
        {
            return DecimalBinario(Convert.ToDouble(numero));
        }


        /// <summary>
        /// Convierte un número decimal en su equivalente en binario.
        /// </summary>
        /// <param name="numero">un numero de tipo DOUBLE</param>
        /// <returns>el resultado de la conversión (número binario)</returns>
        public string DecimalBinario(double numero)
        {
            string valorBinario = string.Empty;
            int resultDiv = (int)Math.Abs(numero);
            int restoDiv;

            if (resultDiv >= 0)
            {
                do
                {
                    restoDiv = resultDiv % 2;
                    resultDiv /= 2;
                    valorBinario = restoDiv.ToString() + valorBinario;
                } while (resultDiv > 0);
            }

            return valorBinario;
        }


        /// <summary>
        /// Realiza la validación de si el string-input es un número que puede transformarse en double o no.
        /// </summary>
        /// <param name="strNumero">un input de tipo STRING</param>
        /// <returns>Si logra realizar la conversión devuelve el operando en tipo double, si no devuelve valor 0</returns>
        private double ValidarOperando(string strNumero) => double.TryParse(strNumero, out double operando) ? operando : 0;
    }
}
