using System;
using System.Text;


namespace Entidades
{
    public class Sedan : Vehiculo
    {

        #region Campos
        private ETipo tipo;
        #endregion



        #region Constructores
        public Sedan(EMarca marca, string chasis, ConsoleColor color) : base(chasis, marca, color)
        {
            this.tipo = ETipo.CuatroPuertas;
        }


        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo) : this(marca, chasis, color)
        {
            this.tipo = tipo;
        }
        #endregion



        #region Propiedades
        protected override ETamanio Tamanio
        {
            get { return ETamanio.Mediano; }
        }
        #endregion



        #region Métodos
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("");
            sb.AppendLine("SEDAN");
            sb.AppendLine("");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"TAMAÑO : {this.Tamanio}");
            sb.AppendLine($"TIPO : {this.tipo}");
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion

    

        #region Enums
        public enum ETipo
        {
            CuatroPuertas,
            CincoPuertas
        }
        #endregion

    }

}
