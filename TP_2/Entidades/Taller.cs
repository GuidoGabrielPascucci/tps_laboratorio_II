using System;
using System.Collections.Generic;
using System.Text;


namespace Entidades
{
    public sealed class Taller
    {

        #region Campos
        private List<Vehiculo> vehiculos;
        private int espacioDisponible;
        #endregion



        #region Constructores
        private Taller()
        {
            this.vehiculos = new List<Vehiculo>();
        }


        public Taller(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion



        #region Métodos
        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="taller">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public string Listar(Taller t, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", t.vehiculos.Count, t.espacioDisponible);
            sb.AppendLine("");

            foreach (Vehiculo v in t.vehiculos)
            {
                if (v.GetType().Name.Equals(Convert.ToString(tipo), StringComparison.OrdinalIgnoreCase) || tipo is ETipo.Todos)
                    sb.AppendLine(v.Mostrar());
            }

            return Convert.ToString(sb);
        }


        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Listar(this, ETipo.Todos);
        }
        #endregion



        #region Operadores
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="taller">Objeto donde se agregará el elemento</param>
        /// <param name="vehiculo">Objeto a agregar</param>
        /// <returns></returns>
        public static Taller operator +(Taller taller, Vehiculo vehiculo)
        {
            if (taller.vehiculos.Count < taller.espacioDisponible)
            {
                foreach (Vehiculo v in taller.vehiculos)
                {
                    if (v == vehiculo)
                        return taller;
                }

                taller.vehiculos.Add(vehiculo);
            }

            return taller;
        }


        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="taller">Objeto donde se quitará el elemento</param>
        /// <param name="vehiculo">Objeto a quitar</param>
        /// <returns></returns>
        public static Taller operator -(Taller taller, Vehiculo vehiculo)
        {
            foreach (Vehiculo v in taller.vehiculos)
            {
                if (v == vehiculo)
                {
                    taller.vehiculos.Remove(v);
                    break;
                }
            }

            return taller;
        }
        #endregion



        #region Enums
        public enum ETipo
        {
            Ciclomotor,
            Sedan,
            SUV,
            Todos
        }
        #endregion

    }
}
