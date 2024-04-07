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
    public partial class FormFiltrarcs : Form
    {
        // Cadena de conexión a la base de datos
        string connectionString = "Data Source=(localdb)\\senati;Initial Catalog=sistemaAlmacen;Integrated Security=True";

        public FormFiltrarcs()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Obtener el texto del campo de filtro
            string filtro = txtFiltrar.Text;

            // Determinar el tipo de búsqueda seleccionado por el usuario en el ComboBox
            string tipoBusqueda = comboFiltrar.SelectedItem?.ToString();

            // Si el usuario no ha seleccionado ningún tipo de búsqueda, se asume búsqueda por nombre
            if (string.IsNullOrEmpty(tipoBusqueda))
            {
                tipoBusqueda = "Nombre";
            }

            try
            {
                // Crear la conexión
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Crear la consulta SQL
                    string query = "";

                    // Construir la consulta según el tipo de búsqueda seleccionado
                    if (tipoBusqueda == "Nombre")
                    {
                        query = @"SELECT * FROM Productos WHERE nombre LIKE @Filtro";
                    }
                    else if (tipoBusqueda == "Categoría")
                    {
                        query = @"SELECT * FROM Productos WHERE categoria LIKE @Filtro";
                    }

                    // Crear el comando con la consulta SQL y la conexión
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Agregar el parámetro para el filtro
                        command.Parameters.AddWithValue("@Filtro", "%" + filtro + "%");

                        // Abrir la conexión
                        connection.Open();

                        // Crear un DataTable para almacenar los resultados
                        DataTable dataTable = new DataTable();

                        // Llenar el DataTable con los datos del comando
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dataTable.Load(reader);
                        }

                        // Mostrar los datos en el DataGridView
                        dataGridViewProductos.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

        }
    }
    
}
