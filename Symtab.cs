using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCompiladores_IDE
{
    class Symtab
    {
        public struct Variable
        {
            public string nombre;
            public int linea;
            public token.DataType tipo;
        }

        public static List<string> errores = new List<string>();
        public static List<string> tablaS = new List<string>();
        private static Dictionary<string, Variable> tabla = new Dictionary<string, Variable>();

        public static void AñadirVariable(Nodo var)
        {
            Variable x;
            x.nombre = var.getLexema();
            x.linea = var.getLinea();
            x.tipo = var.getTipoDato();
            if (!BuscarVariable(var))
            {
                tabla.Add(var.getLexema(), x);
                tablaS.Add(var.getLexema() + "/" + var.getLinea() + "/" + var.getTipoDato().ToString());
            }
            else
            {
               // Console.WriteLine($"Var = {var.getLexema()} no añadida\t");
                errores.Add($"La llave {var.getLexema()} ya se encuentra en la tabla");
            }

            /* try
             {
                 tabla.Add(var.getLexema(), x);
             }
             catch
             {
                 errores.Add($"La llave {var.getLexema()} ya se encuentra en la tabla");
 ;
             }*/
        }

        public static void ActualizarVariable(Nodo var)
        {
            Variable temp = tabla[var.getLexema()];
            temp.linea = var.getLinea();
            //temp.tipo = var.getTipoDato();
            tabla[var.getLexema()] = temp;
        }

        public static bool BuscarVariable(Nodo var)
        {
            return tabla.ContainsKey(var.getLexema());
        }
        public static List<string> tablaSi()
        {
            return tablaS;
        }
        public static Variable GetVariable(Nodo var)
        {
            return tabla[var.getLexema()];
        }

        public static List<string> GetTabla()
        {
            List<string> lista = new List<string>();

            foreach(KeyValuePair<string,Variable> pair in tabla)
            {
                lista.Add($"Var = {pair.Key}, Linea = {pair.Value.linea}");
            }

            return lista;
        }

        public static String GetSymtab()
        {
            String aux = "";

            foreach(KeyValuePair<string,Variable> pair in tabla)
            {
                aux += $"Key = {pair.Key}, Linea = {pair.Value.linea}, Tipo = {pair.Value.tipo}" + Environment.NewLine;
            }

            return aux;
        }

        public static void LimpiarTabla()
        {
            tabla.Clear();
            tablaS.Clear();
            errores.Clear();
        }
    }
}
