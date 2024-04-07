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
using System.Text.RegularExpressions;

namespace SistemaAlmacen
{
    public partial class FormProveedores : Form
    {
        // Cadena de conexión a la base de datos
        string connectionString = "Data Source=(localdb)\\senati;Initial Catalog= sistemaAlmacen;Integrated Security=True";
        public FormProveedores()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Obtener los datos de los campos de texto
            string nombreEmpresa = txtNombreEmpresa.Text;
            string nombreContacto = txtNombreContacto.Text;
            string direccion = txtDireccion.Text;
            string telefono = txtTelefono.Text;
            string correo = txtCorreo.Text;
            string terminosPago = txtTerminosPago.Text;

            try
            {
                // Crear la conexión
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Crear la consulta SQL
                    string query = @"INSERT INTO Proveedores (nombre_empresa, nombre_contacto, direccion, telefono, correo, terminos_pago) 
                             VALUES (@NombreEmpresa, @NombreContacto, @Direccion, @Telefono, @Correo, @TerminosPago)";

                    // Crear el comando con la consulta SQL y la conexión
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Agregar los parámetros
                        command.Parameters.AddWithValue("@NombreEmpresa", nombreEmpresa);
                        command.Parameters.AddWithValue("@NombreContacto", nombreContacto);
                        command.Parameters.AddWithValue("@Direccion", direccion);
                        command.Parameters.AddWithValue("@Telefono", telefono);
                        command.Parameters.AddWithValue("@Correo", correo);
                        command.Parameters.AddWithValue("@TerminosPago", terminosPago);

                        // Abrir la conexión
                        connection.Open();

                        // Ejecutar el comando
                        int rowsAffected = command.ExecuteNonQuery();

                        // Cerrar la conexión
                        connection.Close();

                        // Verificar si se insertaron filas
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Proveedor agregado correctamente.");
                            LimpiarCampos();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo agregar la empresa.");
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
            // Limpiar los campos de texto
            txtNombreEmpresa.Text = "";
            txtNombreContacto.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtTerminosPago.Text = "";
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;
            if (!EsCorreoValido(correo))
            {
                // Si el correo es inválido, deshabilita el botón de envío
                btnAgregar.Enabled = false;
                errorProvider1.SetError(txtCorreo, "Por favor, introduce un correo electrónico válido.");
            }
            else
            {
                // Si el correo es válido, habilita el botón de envío
                btnAgregar.Enabled = true;
                errorProvider1.SetError(txtCorreo, "");
            }
        }

        public bool EsCorreoValido(string correo)
        {
            // Expresión regular para verificar el formato de un correo electrónico
            string patronCorreo = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Verifica si el correo coincide con el patrón de expresión regular
            return Regex.IsMatch(correo, patronCorreo);
        }
    }
    
}
