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
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Obtener los datos de los campos de texto
            int idProducto = int.Parse(txtIdProducto.Text);
            int cantidadRecibida = int.Parse(txtCantidadRecibida.Text);
            DateTime fechaEntrada = dtpFechaEntrada.Value.Date; // Obtener solo la fecha sin la hora
            TimeSpan horaEntrada = dtpHoraEntrada.Value.TimeOfDay; // Obtener solo la hora 
            int idProveedor = int.Parse(txtIdProveedor.Text);
            string numeroFacturacion = txtNumeroFactEntrada.Text;

            try
            {
                // Crear la conexión
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Crear la consulta SQL
                    string query = @"INSERT INTO Entradas (IdProducto, CantidadRecibida, FechaEntrada, HoraEntrada, IdProveedor, NumeroFacturacion) 
                             VALUES (@IdProducto, @CantidadRecibida, @FechaEntrada, @HoraEntrada, @IdProveedor, @NumeroFacturacion)";

                    // Crear el comando con la consulta SQL y la conexión
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Agregar los parámetros
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
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LimpiarCamposEntrada()
        {
            // Limpiar los campos de texto
            txtIdProducto.Text = "";
            txtCantidadRecibida.Text = "";
            dtpFechaEntrada.Value = DateTime.Now.Date;
            dtpHoraEntrada.Value = DateTime.Now;
            txtIdProveedor.Text = "";
            txtNumeroFactEntrada.Text = "";
        }
    }
}
