using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaAlmacen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string opcionSeleccionada = cmbOpciones.SelectedItem.ToString();

            switch (opcionSeleccionada)
            {
                case "Producto":
                    // Abre la ventana para registrar un producto
                    FormRegistro formRegistroProducto = new FormRegistro();
                    formRegistroProducto.ShowDialog();
                    break;
                case "Salidas":
                    // Abre la ventana para registrar una salida
                    FormSalidas formRegistroSalida = new FormSalidas();
                    formRegistroSalida.ShowDialog();
                    break;
                case "Entradas":
                    // Abre la ventana para registrar una entrada
                    FormEntradas formRegistroEntrada = new FormEntradas();
                    formRegistroEntrada.ShowDialog();
                    break;
                case "Movimientos":
                    // Abre la ventana para registrar un movimiento
                    FormMovimientos formRegistroMovimiento = new FormMovimientos();
                    formRegistroMovimiento.ShowDialog();
                    break;
                case "Proveedor":
                    // Abre la ventana para registrar un proveedor
                    FormProveedores formProveedores = new FormProveedores();
                    formProveedores.ShowDialog();
                    break;
                default:
                    MessageBox.Show("Selecciona una opción válida.");
                    break;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Abre la ventana correspondiente según la opción seleccionada
            FormFiltrarcs nuevaVentana = new FormFiltrarcs();
            nuevaVentana.ShowDialog();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }

       
    }
}
