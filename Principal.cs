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
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace ProyectoCompiladores_IDE
{
    public partial class Principal : Form
    {
        string rutaArchivo;

        Regex reservadas = new Regex(@"program|int|float|bool|and|or|not|if|else|fi|do|until|while|read|write|#.*");
        Regex otro_rx = new Regex(@"<.*>|\"".*\""");
        String tokenResultado;
        public Principal()
        {
            InitializeComponent();
            this.CenterToScreen(); // Centra el programa en el centro de la pantalla
                                   //this.Text = "Principal"; //Nombre en la ventana
            
        }


        //-------------------------Menu Archivo
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
                MarcarTexto();
                MessageBox.Show("Archivo abierto con éxito");
            }
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
                    MarcarTexto();
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
                        MessageBox.Show("Archivo Guardado");
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
            else if (e.Control && e.KeyCode == Keys.A)
            {
                cuadro.SelectAll();
            }
            else if(e.Control && e.KeyCode == Keys.U)
            {
                if (cuadro.CanUndo == true)
                {
                    cuadro.Undo();
                    cuadro.ClearUndo();
                }
            }
            else if(e.Control && e.KeyCode == Keys.D)
            {
                if (cuadro.SelectedText != "")
                {
                    cuadro.Cut();
                }
                else
                {
                    MessageBox.Show("Todavia no has seleccionado nada");
                }
            }
        }

        private void cerrarCtrlXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //cuadro.Text = "";
            //MessageBox.Show("Archivo cerrado");
            this.Dispose();
        }
        //--FIN-------------------------Menu Archivo



        //--------------------------Menu Editar
        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cuadro.SelectionLength > 0)
            {
                cuadro.Copy();
            }
            else
            {
                MessageBox.Show("Selecciona lo que deseas copiar");
            }
                
        }

        private void unToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cuadro.CanUndo == true)
            {
                cuadro.Undo();
                cuadro.ClearUndo();
            }
        }

        private void pegarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
               
                if (cuadro.SelectionLength > 0)
                {
                    
                    if (MessageBox.Show("¿Quieres sobreescibir?", "Cortar", MessageBoxButtons.YesNo) == DialogResult.No)
                        
                        cuadro.SelectionStart = cuadro.SelectionStart + cuadro.SelectionLength;
                }
                cuadro.Paste();
            }
        }

        private void cortarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cuadro.SelectedText != "")
            {
                cuadro.Cut();
            }
            else
            {
                MessageBox.Show("Todavia no has seleccionado nada");
            }
                
                
        }

        private void seleccionarTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cuadro.SelectAll();
        }
        //--FIN----------------------------Menu Editar




        //--------------------------Propiedades de variables reservadas
        private void Cambio_Texto(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space
                || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                MarcarTexto();
            }
        }

        private void MarcarTexto()
        {
            int posActual = cuadro.SelectionStart;
            cuadro.SelectAll();
            cuadro.SelectionColor = Color.Black;
            MatchCollection matchesReservadas = reservadas.Matches(cuadro.Text);
            MatchCollection matchesOtro = otro_rx.Matches(cuadro.Text);

            foreach (Match temp in matchesReservadas)
            {
                cuadro.Select(temp.Index, temp.Length);
                cuadro.SelectionColor = Color.Blue;
            }
            foreach (Match temp in matchesOtro)
            {
                cuadro.Select(temp.Index, temp.Length);
                cuadro.SelectionColor = Color.Red;
            }

            cuadro.SelectionStart = posActual;
            cuadro.SelectionLength = 0;
        }

        private void Click_compilar(object sender, EventArgs e)
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
           
            string[] lineas = System.IO.File.ReadAllLines(rutaArchivo);
            //string cadenas ="+-{;}";
            //Console.WriteLine("Coincidencias primer archivo: \t");
            lexico analizador = new lexico();
            int lineaP = 1;
            foreach (string linea in lineas)
            {

                analizador.Analizado_Lexico(linea, lineaP);
                lineaP++;
            }
            analizador.obtenerTokens2();
            LexicoTextBox.Text = analizador.tokensResultados();
            analizador.obtenerTokens2E();
            ErroresTextBox.Text = analizador.tokensResultadosE();
            /*
            //Programa para ejecutar el comando externo
            string cadena = lanzaProceso(@".\Program.exe", rutaArchivo);
            char caracter = '|';
            string[] resTokens = cadena.Split(caracter);
            LexicoTextBox.Text = resTokens[0];
            ErroresTextBox.Text = resTokens[2];
           */



        }
        //--FIN----------------------Propiedades de variables reservadas

        private static string lanzaProceso(string Proceso, string Parametros)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(Proceso, Parametros);
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.UseShellExecute = false; //No utiliza RunDLL32 para lanzarlo   //Opcional: establecer la carpeta de trabajo en la que se ejecutará el proceso   //startInfo.WorkingDirectory = "C:\\MiCarpeta\\";
                                               //Redirige las salidas y los errores
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            Process proc = Process.Start(startInfo); //Ejecuta el proceso
            proc.WaitForExit(); // Espera a que termine el proceso
            string error = proc.StandardError.ReadToEnd();
            if (error != null && error != "") //Error
                throw new Exception("Se ha producido un error al ejecutar el proceso '" + Proceso + "'\n" + "Detalles:\n" + "Error: " + error);
            else //Éxito
                //return proc.Container.Components.Cast<proc.StandardOutput.ReadToEnd()>
                return proc.StandardOutput.ReadToEnd(); //Devuelve el resultado 
                
        }
       

    }
}
