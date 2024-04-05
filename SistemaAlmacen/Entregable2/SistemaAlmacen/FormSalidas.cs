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
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Obtener los datos de los campos de texto
            int idProducto = int.Parse(txtIdProducto.Text);
            int cantidadRetirada = int.Parse(txtCantidadRetirada.Text);
            DateTime fechaSalida = dtpFechaSalida.Value.Date; // Obtener solo la fecha sin la hora
            TimeSpan horaSalida = dtpHoraSalida.Value.TimeOfDay;  // Obtener solo la hora sin la fecha
            string motivo = txtMotivo.Text;
            string numeroFacturacion = txtNumeroFact.Text;

            try
            {
                // Crear la conexión
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Crear la consulta SQL
                    string query = @"INSERT INTO Salidas (IdProducto, CantidadRetirada, FechaSalida, HoraSalida, Motivo, NumeroFacturacion) 
                             VALUES (@IdProducto, @CantidadRetirada, @FechaSalida, @HoraSalida, @Motivo, @NumeroFacturacion)";

                    // Crear el comando con la consulta SQL y la conexión
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Agregar los parámetros
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
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LimpiarCamposSalida()
        {
            // Limpiar los campos de texto
            txtIdProducto.Text = "";
            txtCantidadRetirada.Text = "";
            dtpFechaSalida.Value = DateTime.Now.Date;
            dtpHoraSalida.Value = DateTime.Now;
            txtMotivo.Text = "";
            txtNumeroFact.Text = "";
        }

    }
    
}
