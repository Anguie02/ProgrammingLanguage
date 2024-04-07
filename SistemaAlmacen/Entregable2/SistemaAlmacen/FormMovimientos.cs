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
    public partial class FormMovimientos : Form
    {
        // Cadena de conexión a la base de datos
        string connectionString = "Data Source=(localdb)\\senati;Initial Catalog= sistemaAlmacen;Integrated Security=True";
        public FormMovimientos()
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
            // Verificar si se ha seleccionado un producto en el ComboBox
            if (cmbIdProducto.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un producto válido.");
                return;
            }

            // Obtener el tipo de movimiento
            string tipo = cmbTipo.SelectedItem.ToString();

            // Obtener el ID del producto seleccionado en el ComboBox
            int idProducto = 0;
            if (!int.TryParse(cmbIdProducto.SelectedItem.ToString().Split('-')[0].Trim(), out idProducto))
            {
                MessageBox.Show("Por favor, seleccione un producto válido.");
                return;
            }

            // Obtener los demás datos de los campos de texto
            int cantidadMovida = int.Parse(txtCantidadMovida.Text);
            DateTime fechaMovimiento = dtpFechaMovimiento.Value.Date; // Obtener solo la fecha sin la hora
            TimeSpan horaMovimiento = dtpHoraMovimiento.Value.TimeOfDay; // Obtener solo la hora sin la fecha
            string origen = txtOrigen.Text;
            string destino = txtDestino.Text;

            try
            {
                // Crear la conexión y el comando SQL
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO Movimientos (tipo, id_producto, cantidad_movida, fecha_movimiento, hora_movimiento, origen, destino) 
                    VALUES (@Tipo, @IdProducto, @CantidadMovida, @FechaMovimiento, @HoraMovimiento, @Origen, @Destino)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Agregar parámetros al comando
                        command.Parameters.AddWithValue("@Tipo", tipo);
                        command.Parameters.AddWithValue("@IdProducto", idProducto);
                        command.Parameters.AddWithValue("@CantidadMovida", cantidadMovida);
                        command.Parameters.AddWithValue("@FechaMovimiento", fechaMovimiento);
                        command.Parameters.AddWithValue("@HoraMovimiento", horaMovimiento);
                        command.Parameters.AddWithValue("@Origen", origen);
                        command.Parameters.AddWithValue("@Destino", destino);

                        // Abrir la conexión
                        connection.Open();

                        // Ejecutar el comando
                        int rowsAffected = command.ExecuteNonQuery();

                        // Cerrar la conexión
                        connection.Close();

                        // Verificar si se insertaron filas
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Movimiento agregado correctamente.");
                            LimpiarCamposMovimiento();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo agregar el movimiento.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el movimiento: " + ex.Message);
            }
        }

        private void LimpiarCamposMovimiento()
        {
            // Limpiar los campos de texto y selección
            txtCantidadMovida.Text = "";
            dtpFechaMovimiento.Value = DateTime.Now;
            dtpHoraMovimiento.Value = DateTime.Now;
            txtOrigen.Text = "";
            txtDestino.Text = "";

            // Reiniciar selección del ComboBox
            cmbIdProducto.SelectedIndex = -1;
            cmbTipo.SelectedIndex = -1;

        }

       
}
    }
