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
        string connectionString = "Data Source=(localdb)\\senati;Initial Catalog=logins;Integrated Security=True";

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

                        // Crear un lector de datos para leer los resultados
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Limpiar el panel antes de agregar nuevos elementos
                            panelListar.Controls.Clear();

                            // Recorrer los resultados y agregarlos al panel
                            while (reader.Read())
                            {
                                // Crear un nuevo control para mostrar los datos
                                Label label = new Label();
                                label.Text = $"Nombre: {reader["Nombre"]}, Descripción: {reader["Descripcion"]}, SKU: {reader["SKU"]}, Categoría: {reader["Categoria"]}, Precio: {reader["Precio"]}, Cantidad en stock: {reader["CantidadEnStock"]}, Unidad de medida: {reader["UnidadMedida"]}, Fecha de vencimiento: {reader["FechaVencimiento"]}";

                                // Añadir el control al panel
                                panelListar.Controls.Add(label);
                            }
                        }

                        // Cerrar la conexión
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
    
}
