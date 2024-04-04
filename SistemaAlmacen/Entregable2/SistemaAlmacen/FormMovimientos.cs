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
        string connectionString = "Data Source=(localdb)\\senati;Initial Catalog= logins;Integrated Security=True";
        public FormMovimientos()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Obtener los datos de los campos de texto
            string tipo = txtTipo.Text;
            int idProducto = int.Parse(txtIdProducto.Text);
            int cantidadMovida = int.Parse(txtCantidadMovida.Text);
            DateTime fechaMovimiento = dtpFechaMovimiento.Value.Date; // Obtener solo la fecha sin la hora
            DateTime horaMovimiento = DateTime.ParseExact(txtHoraMovimiento.Text, "HH:mm", CultureInfo.InvariantCulture); // Obtener solo la hora sin la fecha
            string origen = txtOrigen.Text;
            string destino = txtDestino.Text;

            try
            {
                // Crear la conexión
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Crear la consulta SQL
                    string query = @"INSERT INTO Movimientos (Tipo, IdProducto, CantidadMovida, FechaMovimiento, HoraMovimiento, Origen, Destino) 
                             VALUES (@Tipo, @IdProducto, @CantidadMovida, @FechaMovimiento, @HoraMovimiento, @Origen, @Destino)";

                    // Crear el comando con la consulta SQL y la conexión
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Agregar los parámetros
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
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LimpiarCamposMovimiento()
        {
            // Limpiar los campos de texto
            txtTipo.Text = "";
            txtIdProducto.Text = "";
            txtCantidadMovida.Text = "";
            dtpFechaMovimiento.Value = DateTime.Now.Date;
            txtHoraMovimiento.Text = "";
            txtOrigen.Text = "";
            txtDestino.Text = "";
        }
    }
    
}
