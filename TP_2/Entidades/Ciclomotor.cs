using System;
using System.Text;


namespace Entidades
{
    public class Ciclomotor : Vehiculo
    {

        #region Constructores
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color) : base(chasis, marca, color) { }
        #endregion



        #region Propiedades
        protected override ETamanio Tamanio
        {
            get { return ETamanio.Chico; }
        }
        #endregion



        #region Métodos
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("");
            sb.AppendLine("CICLOMOTOR");
            sb.AppendLine("");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"TAMAÑO : {this.Tamanio}");
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return Convert.ToString(sb);
        }
        #endregion

    }
}
