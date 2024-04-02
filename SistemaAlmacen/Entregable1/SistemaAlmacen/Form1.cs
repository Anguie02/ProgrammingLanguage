using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaAlmacen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario secundario
            FormRegistro formularioSecundario = new FormRegistro();

            // Mostrar el formulario secundario
            formularioSecundario.Show();
        }
    }
}
