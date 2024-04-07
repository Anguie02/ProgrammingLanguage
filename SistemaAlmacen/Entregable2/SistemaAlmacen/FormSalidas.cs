using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaAlmacen
{
    public partial class FormSalidas : Form
    {
        // Cadena de conexión a la base de datos
        string connectionString = "Data Source=(localdb)\\senati;Initial Catalog= sistemaAlmacen;Integrated Security=True";
        public FormSalidas()
        {
            InitializeComponent();
            LlenarComboBoxProductos();
        }

        private void LlenarComboBoxProductos()
        {
            try
            {
                // Crear la conexión
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Abrir la conexión
                    connection.Open();

                    // Crear la consulta SQL para obtener los IDs de la tabla de productos
                    string query = "SELECT id_producto FROM Productos";

                    // Crear el comando con la consulta SQL y la conexión
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Ejecutar el comando y obtener los datos
                        SqlDataReader reader = command.ExecuteReader();

                        // Recorrer los datos y agregar los IDs al ComboBox
                        while (reader.Read())
                        {
                            cmbIdProducto.Items.Add(reader["id_producto"].ToString());
                        }

                        // Cerrar el lector
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier error que ocurra durante la recuperación de datos
                MessageBox.Show("Error al llenar ComboBox de productos: " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Obtener el ID del producto seleccionado en el ComboBox
            int idProducto = 0;
            if (cmbIdProducto.SelectedItem != null && int.TryParse(cmbIdProducto.SelectedItem.ToString().Split('-')[0].Trim(), out idProducto))
            {
                // Obtener los demás datos de los campos de texto
                int cantidadRetirada = int.Parse(txtCantidadRetirada.Text);
                DateTime fechaSalida = dtpFechaSalida.Value.Date;
                TimeSpan horaSalida = dtpHoraSalida.Value.TimeOfDay;
                string motivo = txtMotivo.Text;
                string numeroFacturacion = txtNumeroFact.Text;

                try
                {
                    // Crear la conexión y el comando SQL
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = @"INSERT INTO Salidas (id_producto, cantidad_retirada, fecha_salida, hora_salida, motivo_salida, numero_factura) 
                        VALUES (@IdProducto, @CantidadRetirada, @FechaSalida, @HoraSalida, @Motivo, @NumeroFacturacion)";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Agregar parámetros al comando
                            command.Parameters.AddWithValue("@IdProducto", idProducto);
                            command.Parameters.AddWithValue("@CantidadRetirada", cantidadRetirada);
                            command.Parameters.AddWithValue("@FechaSalida", fechaSalida);
                            command.Parameters.AddWithValue("@HoraSalida", horaSalida);
                            command.Parameters.AddWithValue("@Motivo", motivo);
                            command.Parameters.AddWithValue("@NumeroFacturacion", numeroFacturacion);

                            // Abrir la conexión
                            connection.Open();

                            // Ejecutar el comando
                            int rowsAffected = command.ExecuteNonQuery();

                            // Cerrar la conexión
                            connection.Close();

                            // Verificar si se insertaron filas
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Salida agregada correctamente.");
                                LimpiarCamposSalida();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo agregar la salida.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar la salida: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un producto válido.");
            }
        }

        private void LimpiarCamposSalida()
        {
            // Limpiar los campos de texto
            txtCantidadRetirada.Text = "";
            dtpFechaSalida.Value = DateTime.Now.Date;
            dtpHoraSalida.Value = DateTime.Now;
            txtMotivo.Text = "";
            txtNumeroFact.Text = "";

            // Reiniciar selección del ComboBox
            cmbIdProducto.SelectedIndex = -1;
        }

    }
    
}
