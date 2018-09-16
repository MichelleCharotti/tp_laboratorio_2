using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades1;

namespace MiCalculadora
{
    public partial class Form1 : Form
    {
        public Form1()
        {                                                                 
            InitializeComponent();

                string[] operadores= { "+","-","/","*" };

                for(int i=0;i<4;i++)
                {
                    this.cmdOperador.Items.Add(operadores[i]);
                }

              this.cmdOperador.DropDownStyle = ComboBoxStyle.DropDownList;
              this.cmdOperador.SelectedIndex = 0;
        }

        /// <summary>
        /// Permite modificar el tamaño del textBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.txtNumero1.Multiline = true;
        }

        /// <summary>
        /// Permite modificar el tamaño del textBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.txtNumero2.Multiline = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Retorna el resultado de la operacion entre dos numeros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _btnOperar_Click(object sender, EventArgs e)
        {
            double resultado=0;

            resultado=Operar(this.txtNumero1.Text,this.txtNumero2.Text,this.cmdOperador.Text);

            this.lblResultado.Text = resultado.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Reinicia los datos de los textBox,comboBox y label
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.ResetText();
            this.txtNumero2.ResetText();
            this.cmdOperador.SelectedIndex = 0;
            this.lblResultado.Text = "0";
        }

        /// <summary>
        /// Ejecuta el metodo limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Realiza las operaciones con los numeros
        /// </summary>
        /// <param name="numero1">Recibe un string</param>
        /// <param name="numero2">Recibe un string</param>
        /// <param name="operador">Recibe un string</param>
        /// <returns>Retorna el resultado de la operacion</returns>
        private static double Operar(string numero1,string numero2,string operador)
        {
            double retorno=0;

            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            Calculadora calcu = new Calculadora();

            retorno= calcu.Operar(num1,num2,operador);

            return retorno;
        }

        private void lblResultado_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Convierte el resultado a binario y si no es posible retorna un mensaje
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if ( this.lblResultado.Text != "" || this.lblResultado.Text != "0" )
            {
                Numero num = new Numero(this.lblResultado.Text);

                this.lblResultado.Text = num.DecimalBinario(this.lblResultado.Text);
            }
             else
            {
                this.lblResultado.Text = "Valor Invalido";
            }
            
        }

        /// <summary>
        /// Convierte el resultado a binario y si no es posible retorna un mensaje
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (this.lblResultado.Text != "" || this.lblResultado.Text != "0")
            {
                Numero num = new Numero(this.lblResultado.Text);

                this.lblResultado.Text = num.BinarioDecimal(this.lblResultado.Text);
            }
            else
            {
                this.lblResultado.Text = "Valor Invalido";
            }
        }
    }
}
