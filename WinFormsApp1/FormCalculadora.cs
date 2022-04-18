using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        /// <summary>
        /// Constructor de FormCalculadora
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
        }


        /// <summary>
        /// EVENTO CLICK del btn Operar. Toma los inputs y los usa para realizar la operación indicada por el usuario. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (this.txtNumero1.Text != string.Empty && this.txtNumero2.Text != string.Empty && this.cmbOperador.SelectedIndex != -1)
            {
                string operador = this.cmbOperador.Items[cmbOperador.SelectedIndex].ToString();
                double result = Operar(this.txtNumero1.Text, this.txtNumero2.Text, operador);
                
                double num;

                if (!double.TryParse(this.txtNumero1.Text, out num))
                {
                    this.txtNumero1.Text = num.ToString();
                }

                if (!double.TryParse(this.txtNumero2.Text, out num))
                {
                    this.txtNumero2.Text = num.ToString();
                }

                StringBuilder operacion = new StringBuilder();

                if (result != double.MinValue && operador != " ")
                {
                    operacion.Append(this.txtNumero1.Text + " " + operador + " " + this.txtNumero2.Text + " = " + result);
                    this.lstOperaciones.Items.Add(operacion);
                    lblResultado.Text = result.ToString();
                }
                else if (result == double.MinValue)
                {
                    lblResultado.Text = "Error. No se puede dividir por cero";
                }
                else
                {
                    MessageBox.Show("Debes ingresar un operando para poder realizar una operación!", "Atención",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Debes ingresar dos números y seleccionar un operador para poder realizar una acción!", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        /// <summary>
        /// Crea las instancias que usará el método Calculadora.Operar y lo invoca
        /// </summary>
        /// <param name="numero1">Operando Uno STRING</param>
        /// <param name="numero2">Operando Dos STRING</param>
        /// <param name="operador">Operador STRING</param>
        /// <returns>El resultado de la operación que asigna Calculadora.Operar</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Operando a = new Operando(numero1);
            Operando b = new Operando(numero2);

            char op = Convert.ToChar(operador);
            double result = Calculadora.Operar(a, b, op);

            return result;
        }


        /// <summary>
        /// EVENTO CLICK del btn Convertir A Binario. Valida que se pueda realizar la operación de conversión
        /// del resultado en decimal a número binario y lo muestra en el label Resultado. En caso de error muestra
        /// Message boxes según tipo de error.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text != string.Empty && lblResultado.Text != "Error. No se puede dividir por cero" && lblResultado.Text != "Valor inválido")
            {
                Operando resultadoDecimal = new Operando();
                lblResultado.Text = resultadoDecimal.DecimalBinario(lblResultado.Text);
            }
            else
            {
                switch (lblResultado.Text)
                {
                    case "":
                        MessageBox.Show("Error: No hay resultado disponible.\n\n" +
                                        "Debes ingresar dos números y seleccionar un operador para poder realizar una acción!",
                                        "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;

                    case "Error. No se puede dividir por cero":
                        MessageBox.Show("Operación imposible de realizar...",
                                        "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;

                    case "Valor inválido":
                        MessageBox.Show("Valor inválido! No se pudo ejecutar la operación...",
                                        "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
        }


        /// <summary>
        /// EVENTO CLICK del btn Convertir A Decimal. Valida que se pueda realizar la operación de conversión
        /// del resultado en binario a número decimal y lo muestra en el label Resultado. En caso de error muestra
        /// Message boxes según tipo de error.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text != string.Empty && lblResultado.Text != "Error. No se puede dividir por cero" && lblResultado.Text != "Valor inválido")
            {
                Operando resultadoBinario = new Operando();
                lblResultado.Text = resultadoBinario.BinarioDecimal(lblResultado.Text);
            }
            else
            {
                switch (lblResultado.Text)
                {
                    case "":
                        MessageBox.Show("Error: No hay resultado disponible.\n\n" +
                                        "Debes ingresar dos números y seleccionar un operador para poder realizar una acción!",
                                        "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;

                    case "Error. No se puede dividir por cero":
                        MessageBox.Show("Operación imposible de realizar...",
                                        "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;

                    case "Valor inválido":
                        MessageBox.Show("Valor inválido! No se pudo ejecutar la operación...",
                                        "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
        }


        /// <summary>
        /// Limpia los text-boxes, label y combo-box
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = string.Empty;
            this.txtNumero2.Text = string.Empty;
            this.lblResultado.Text = string.Empty;
            cmbOperador.SelectedIndex = -1;
        }


        /// <summary>
        /// EVENTO CLICK del btn Limpiar. Invoca al método Limpiar() de la clase.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }


        /// <summary>
        /// EVENTO LOAD. Invoca al método Limpiar() de la clase.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.Limpiar();
        }


        /// <summary>
        /// EVENTO CLICK del btn Cerrar. Invoca el método Close() para cerrar el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// EVENTO FORMCLOSING. Cierra el formulario previa validación del usuario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult choice = MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (choice != DialogResult.Yes)
                e.Cancel = true;
        }
    }
}
