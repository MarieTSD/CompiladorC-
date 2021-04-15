using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCompiladores_IDE
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Principal());
                
               // Console.WriteLine("No has agregado el archivo de texto");
            }
            else
            {
                string[] lineas = System.IO.File.ReadAllLines(@".\"+args[0]);
                lexico analizador = new lexico();
                int lineaP = 1;
                foreach (string linea in lineas)
                {
                    analizador.Analizado_Lexico(linea, lineaP);
                    lineaP++;
                }
                analizador.obtenerTokens2();
                analizador.obtenerTokens2E();
                Console.WriteLine(analizador.tokensResultados());
                Console.WriteLine("| Tokens Errores |\t");
                Console.WriteLine(analizador.tokensResultadosE());
            }

        }
    }
}
