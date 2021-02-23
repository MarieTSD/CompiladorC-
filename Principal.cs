using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ProyectoCompiladores_IDE
{
    public partial class Principal : Form
    {
        string rutaArchivo;
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
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                rutaArchivo = openFileDialog1.FileName;

                using (StreamReader lectura = new StreamReader(rutaArchivo))
                {
                    cuadro.Text = lectura.ReadToEnd();
                }
            }
            MessageBox.Show("Archivo abierto con éxito");
        }

        private void ClickBoton_ArchivoGuardar(object sender, EventArgs e)
        {
            if (rutaArchivo != null)
            {
                using (StreamWriter escritura = new StreamWriter(rutaArchivo))
                {
                    escritura.Write(cuadro.Text);
                }
            }
            else
            {
                if (guardar.ShowDialog() == DialogResult.OK)
                {
                    rutaArchivo = guardar.FileName;
                    using (StreamWriter escritura = new StreamWriter(guardar.FileName))
                    {
                        escritura.Write(cuadro.Text);
                    }
                }
            }
            MessageBox.Show("Actualización Guardada");
        }

        private void ClickBoton_ArchivoCerrar(object sender, EventArgs e)
        {
            
            if (guardar.ShowDialog() == DialogResult.OK)
            {

                using (StreamWriter escritura = new StreamWriter(guardar.FileName))
                {
                    escritura.Write(cuadro.Text);
                }
                MessageBox.Show("Archivo Guardado");
            }

        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void Principal_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.O)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    rutaArchivo = openFileDialog1.FileName;

                    using (StreamReader lectura = new StreamReader(rutaArchivo))
                    {
                        cuadro.Text = lectura.ReadToEnd();
                    }
                    MessageBox.Show("Archivo abierto con éxito");
                }
            }
            else if (e.Control && e.KeyCode == Keys.S)
            {
                if (rutaArchivo != null)
                {
                    using (StreamWriter escritura = new StreamWriter(rutaArchivo))
                    {
                        escritura.Write(cuadro.Text);
                    }
                    MessageBox.Show("Actualización Guardada");
                }
                else
                {
                    if (guardar.ShowDialog() == DialogResult.OK)
                    {
                        rutaArchivo = guardar.FileName;
                        using (StreamWriter escritura = new StreamWriter(guardar.FileName))
                        {
                            escritura.Write(cuadro.Text);
                        }
                        MessageBox.Show("Archivo Guarado");
                    }
                }
            }
            else if (e.Control && e.KeyCode == Keys.G)
            {
                if (guardar.ShowDialog() == DialogResult.OK)
                {

                    using (StreamWriter escritura = new StreamWriter(guardar.FileName))
                    {
                        escritura.Write(cuadro.Text);
                    }
                    MessageBox.Show("Archivo Guardado");
                }
            }
            else if (e.Control && e.KeyCode == Keys.X)
            {
                //cuadro.Text = "";
                //MessageBox.Show("Archivo cerrado");
                this.Dispose();
            }
        }

        private void cerrarCtrlXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //cuadro.Text = "";
            //MessageBox.Show("Archivo cerrado");
            this.Dispose();
        }

        
    }
}
