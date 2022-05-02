using System;
using System.Text;


namespace Entidades
{
    public abstract class Vehiculo
    {

        #region Campos
        private string chasis;
        private EMarca marca;
        private ConsoleColor color;
        #endregion



        #region Constructores
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }
        #endregion



        #region Propiedades
        protected abstract ETamanio Tamanio { get; }
        #endregion



        #region Métodos
        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns>Un String con los datos del Vehículo</returns>
        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"CHASIS: {this.chasis}");
            sb.AppendLine($"MARCA : {this.marca.ToString()}");
            sb.AppendLine($"COLOR : {this.color.ToString()}");
            sb.AppendLine("---------------------");

            return Convert.ToString(sb);
        }
        #endregion



        #region Operadores
        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }


        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }
        #endregion



        #region Conversiones
        public static explicit operator string(Vehiculo p)
        {
            return p.Mostrar();
        }
        #endregion



        #region Enums
        public enum EMarca
        {
            Chevrolet,
            Ford,
            Renault,
            Toyota,
            BMW,
            Honda,
            HarleyDavidson
        }

        public enum ETamanio
        {
            Chico,
            Mediano,
            Grande
        }
        #endregion

    }

}
