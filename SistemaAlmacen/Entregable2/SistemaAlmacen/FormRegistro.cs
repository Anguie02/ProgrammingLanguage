using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaAlmacen
{
    public partial class FormRegistro : Form
    {

        // Cadena de conexión a la base de datos
        string connectionString = "Data Source=(localdb)\\senati;Initial Catalog= sistemaAlmacen;Integrated Security=True";
        public FormRegistro()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Obtener los datos de los campos de texto
            string nombre = txtNombre.Text;
            string descripcion = txtDescripcion.Text;
            string sku = txtSku.Text;
            string categoria = txtCategoria.Text;
           

            // Validar y convertir el precio a decimal
            if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                MessageBox.Show("El precio ingresado no es válido.");
                return;
            }

            // Validar y convertir la cantidad a entero
            if (!int.TryParse(txtCantStock.Text, out int cantidad))
            {
                MessageBox.Show("La cantidad ingresada no es válida.");
                return;
            }

            string unidadMedida = txtUMedida.Text;

            // Obtener la fecha de vencimiento del DateTimePicker
            DateTime? fechaVencimiento = null;
            if (!checkBoxNoAplica.Checked)
            {
                fechaVencimiento = dtpFechaVencimiento.Value;
            }

            try
            {
                // Crear la conexión
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Crear la consulta SQL
                    string query = @"INSERT INTO Productos (nombre, descripcion, sku, categoria, precio, cantidad_stock, unidad_medida, fecha_vencimiento) 
                             VALUES (@Nombre, @Descripcion, @SKU, @Categoria, @Precio, @Cantidad, @UnidadMedida, @FechaVencimiento)";

                    // Crear el comando con la consulta SQL y la conexión
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Agregar los parámetros
                        command.Parameters.AddWithValue("@Nombre", nombre);
                        command.Parameters.AddWithValue("@Descripcion", descripcion);
                        command.Parameters.AddWithValue("@SKU", sku);
                        command.Parameters.AddWithValue("@Categoria", categoria);
                        command.Parameters.AddWithValue("@Precio", precio);
                        command.Parameters.AddWithValue("@Cantidad", cantidad);
                        command.Parameters.AddWithValue("@UnidadMedida", unidadMedida);
                        command.Parameters.AddWithValue("@FechaVencimiento", fechaVencimiento);

                        // Abrir la conexión
                        connection.Open();

                        // Ejecutar el comando
                        int rowsAffected = command.ExecuteNonQuery();

                        // Cerrar la conexión
                        connection.Close();

                        // Verificar si se insertaron filas
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Producto agregado correctamente.");
                            LimpiarCampos();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo agregar el producto.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            // Limpiar los campos de texto y el DateTimePicker
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtSku.Text = "";
            txtCategoria.Text = "";
            txtPrecio.Text = "";
            txtCantStock.Text = "";
            txtUMedida.Text = "";
            checkBoxNoAplica.Checked = false;
            dtpFechaVencimiento.Value = DateTime.Now; // Establecer la fecha de vencimiento a la fecha actual
        }
    }
}

