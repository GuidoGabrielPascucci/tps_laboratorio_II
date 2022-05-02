using System;
using System.Text;


namespace Entidades
{
    public class Suv : Vehiculo
    {

        #region Constructores
        public Suv(EMarca marca, string chasis, ConsoleColor color) : base(chasis, marca, color) { }
        #endregion



        #region Propiedades
        protected override ETamanio Tamanio
        {
            get { return ETamanio.Grande; }
        }
        #endregion



        #region Métodos
        /// <summary>
        /// Muestra todos los datos del tipo de Vehículo SUV.
        /// </summary>
        /// <returns>Un string con todos los datos.</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("");
            sb.AppendLine("SUV");
            sb.AppendLine("");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"TAMAÑO : {this.Tamanio}");
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion

    }
}
