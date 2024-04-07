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
    public partial class FormEntradas : Form
    {
        // Cadena de conexión a la base de datos
        string connectionString = "Data Source=(localdb)\\senati;Initial Catalog= sistemaAlmacen;Integrated Security=True";
    
        public FormEntradas()
        {
            InitializeComponent();
            LlenarComboBoxProductos();
            LlenarComboBoxProveedores();
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

        private void LlenarComboBoxProveedores()
        {
            try
            {
                // Crear la conexión
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Abrir la conexión
                    connection.Open();

                    // Crear la consulta SQL para obtener los IDs y nombres de los proveedores
                    string query = "SELECT id_proveedor, nombre_empresa FROM Proveedores";

                    // Crear el comando con la consulta SQL y la conexión
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Ejecutar el comando y obtener los datos
                        SqlDataReader reader = command.ExecuteReader();

                        // Recorrer los datos y agregar los IDs y nombres de los proveedores al ComboBox
                        while (reader.Read())
                        {
                            // Concatenar el ID y el nombre del proveedor y agregarlos al ComboBox
                            string idProveedor = reader["id_proveedor"].ToString();
                            string nombreProveedor = reader["nombre_empresa"].ToString();
                            cmbIdProveedor.Items.Add($"{idProveedor} - {nombreProveedor}");
                        }

                        // Cerrar el lector
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier error que ocurra durante la recuperación de datos
                MessageBox.Show("Error al llenar ComboBox de proveedores: " + ex.Message);
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Obtener el ID del producto seleccionado en el ComboBox
            int idProducto = 0;
            if (cmbIdProducto.SelectedItem != null && int.TryParse(cmbIdProducto.SelectedItem.ToString(), out idProducto))
            {
                // Obtener el ID del proveedor seleccionado en el ComboBox
                int idProveedor = 0;
                if (cmbIdProveedor.SelectedItem != null && int.TryParse(cmbIdProveedor.SelectedItem.ToString().Split('-')[0].Trim(), out idProveedor))
                {
                    // Obtener los demás datos de los campos de texto
                    int cantidadRecibida = int.Parse(txtCantidadRecibida.Text);
                    DateTime fechaEntrada = dtpFechaEntrada.Value.Date;
                    TimeSpan horaEntrada = dtpHoraEntrada.Value.TimeOfDay;
                    string numeroFacturacion = txtNumeroFactEntrada.Text;

                    try
                    {
                        // Crear la conexión y el comando SQL
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            string query = @"INSERT INTO Entradas (id_producto, cantidad_recibida, fecha_entrada, hora_entrada, id_proveedor, numero_factura) 
                        VALUES (@IdProducto, @CantidadRecibida, @FechaEntrada, @HoraEntrada, @IdProveedor, @NumeroFacturacion)";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                // Agregar parámetros al comando
                                command.Parameters.AddWithValue("@IdProducto", idProducto);
                                command.Parameters.AddWithValue("@CantidadRecibida", cantidadRecibida);
                                command.Parameters.AddWithValue("@FechaEntrada", fechaEntrada);
                                command.Parameters.AddWithValue("@HoraEntrada", horaEntrada);
                                command.Parameters.AddWithValue("@IdProveedor", idProveedor);
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
                                    MessageBox.Show("Entrada agregada correctamente.");
                                    LimpiarCamposEntrada();
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo agregar la entrada.");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al agregar la entrada: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un proveedor válido.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un producto válido.");
            }
        }

        private void LimpiarCamposEntrada()
        {
            // Limpiar los campos de texto
            txtCantidadRecibida.Text = "";
            dtpFechaEntrada.Value = DateTime.Now.Date;
            dtpHoraEntrada.Value = DateTime.Now;
            txtNumeroFactEntrada.Text = "";

            // Reiniciar selección del ComboBox
            cmbIdProducto.SelectedIndex = -1;
            cmbIdProveedor.SelectedIndex= -1;
        }

    }
}
