using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCompiladores_IDE
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            this.CenterToScreen(); // Centra el programa en el centro de la pantalla
            //this.Text = "Principal"; //Nombre en la ventana
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // Codigo del evento click en boton "mensaje"
            MessageBox.Show("Hola Mundo!"); // Abre una ventana de dialogo con el mensaje
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Codigo del evento click en boton "salir"
            Application.Exit(); //Cierra la aplicacion
        }

        private void ClickBoton_ArchivoAbrir(object sender, EventArgs e)
        {
            MessageBox.Show("Abriendo Archivo. :)");
        }

        private void ClickBoton_ArchivoGuardar(object sender, EventArgs e)
        {
            MessageBox.Show("Guardando Archivo. :o");
        }

        private void ClickBoton_ArchivoCerrar(object sender, EventArgs e)
        {
            MessageBox.Show("Cerrando Archivo. :(");
        }
    }
}
