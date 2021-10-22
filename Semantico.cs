using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCompiladores_IDE
{
    class Semantico
    {
        private static List<string> errores = new List<string>();
        private static List<string> tablaSin = new List<string>();
        static private List<String> listaIntFloat = new List<string>();
        static private List<String> temporal = new List<string>();
        public static Boolean bandera = false;
        private static void TypeError(Nodo n, string msg)
        {
            errores.Add($"Error de tipo en linea {n.getLinea()}: {msg}");
        }

        public static void InsertarId(Nodo n)
        {
            if(n.getTipoToken() == token.Type.ID)
            {
                if (!Symtab.BuscarVariable(n))
                    Symtab.AñadirVariable(n);
                else
                {
                    Symtab.Variable dato = Symtab.GetVariable(n);
                    n.setTipoDato(dato.tipo);
                    Symtab.ActualizarVariable(n);
                }
            }

            if (n.hijos[0] != null) InsertarId(n.hijos[0]);
            if (n.hijos[1] != null) InsertarId(n.hijos[1]);
            if (n.hijos[2] != null) InsertarId(n.hijos[2]);
            if (n.hermano != null) InsertarId(n.hermano);
        }

        public static void TypeCheck(Nodo n)
        {
            if (n.getTipoToken() == token.Type.ID) n = ActualizarNodo(n);
            if (n.hijos[0] != null) TypeCheck(n.hijos[0]);
            if (n.hijos[1] != null) TypeCheck(n.hijos[1]);
            if (n.hijos[2] != null) TypeCheck(n.hijos[2]);

            if(n.getTipoToken() == token.Type.ASIGNACION)
            {
                if (n.hijos[0].getTipoToken() != token.Type.ID)
                    TypeError(n, "Asignacion no valida");
                else if (n.hijos[0].getTipoDato() != n.hijos[1].getTipoDato())
                {
                    TypeError(n, "Tipos de dato no coinciden");
                    n.setTipoDato(token.DataType.ERROR);
                    n.hijos[0].setTipoDato(token.DataType.ERROR);
                    if (Symtab.BuscarVariable(n.hijos[0]))
                        Symtab.ActualizarVariable(n.hijos[0]);
                    else
                        Symtab.AñadirVariable(n.hijos[0]);
                }
                else
                {
                    n.setTipoDato(n.hijos[0].getTipoDato());
                    if (Symtab.BuscarVariable(n.hijos[0]))
                        Symtab.ActualizarVariable(n.hijos[0]);
                    else
                        Symtab.AñadirVariable(n.hijos[0]);
                }
            }

            if (n.getTipoToken() == token.Type.WRITE)
            {
                //n.setTipoDato(n.hijos[0].getTipoDato());
                bandera = true;
                temporal.Clear();
                Recursivo(n);
                if (temporal.Contains("REAL") || temporal.Contains("/"))
                {
                    n.setTipoDato(token.DataType.REAL);
                }
                else
                {
                    n.setTipoDato(token.DataType.INTEGER);
                }
                if (n.hijos[0].getTipoToken() == token.Type.ID)
                {
                    if (Symtab.BuscarVariable(n.hijos[0]))
                        Symtab.ActualizarVariable(n.hijos[0]);
                    else
                        Symtab.AñadirVariable(n.hijos[0]);
                }
            }

            if (n.getTipoToken() == token.Type.SUMA || n.getTipoToken() == token.Type.RESTA || 
                n.getTipoToken() == token.Type.MULTIPLICACION || n.getTipoToken() == token.Type.DIVISION)
            {
                if (!(n.hijos[0].getTipoDato() == token.DataType.INTEGER || n.hijos[0].getTipoDato() == token.DataType.REAL &&
                      n.hijos[1].getTipoDato() == token.DataType.INTEGER || n.hijos[1].getTipoDato() == token.DataType.REAL))
                {
                    TypeError(n, "Operacion no valida");
                    n.setTipoDato(token.DataType.ERROR);
                }
                else if(n.hijos[0].getTipoDato() != n.hijos[1].getTipoDato())
                {
                    TypeError(n, "Tipos de dato no coinciden");
                    n.setTipoDato(token.DataType.REAL);
                    //n.setTipoDato(token.DataType.ERROR);
                }
                else
                {
                    n.setTipoDato(n.hijos[0].getTipoDato());
                }
            }

            if (n.getTipoToken() == token.Type.MAYOR_IGUAL || n.getTipoToken() == token.Type.MAYOR_QUE ||
                n.getTipoToken() == token.Type.MENOR_IGUAL || n.getTipoToken() == token.Type.MENOR_QUE ||
                n.getTipoToken() == token.Type.IGUALDAD || n.getTipoToken() == token.Type.DESIGUALDAD)
            {
                if (!(n.hijos[0].getTipoDato() == token.DataType.INTEGER || n.hijos[0].getTipoDato() == token.DataType.REAL &&
                      n.hijos[1].getTipoDato() == token.DataType.INTEGER || n.hijos[1].getTipoDato() == token.DataType.REAL))
                {
                    TypeError(n, "Operacion no valida");
                    n.setTipoDato(token.DataType.ERROR);
                }
                else if (n.hijos[0].getTipoDato() != n.hijos[1].getTipoDato())
                {
                    TypeError(n, "Tipos de dato no coinciden");
                    n.setTipoDato(token.DataType.ERROR);
                }
                else
                {
                    n.setTipoDato(token.DataType.BOOLEAN);
                }
            }

            if (n.hermano != null) TypeCheck(n.hermano);
        }

        private static Nodo ActualizarNodo(Nodo n)
        {
            Symtab.Variable aux = Symtab.GetVariable(n);
            n.setTipoDato(aux.tipo);
            return n;
        }
        public static List<string> tablaSi()
        {
            tablaSin = Symtab.tablaSi();
            return tablaSin;
        }

        public static String GetErroresSemantico()
        {
            String aux = "";
            foreach (String err in Symtab.errores)
            {
                aux += err + Environment.NewLine;
            }
            foreach (String err in errores)
            {
                aux += err + Environment.NewLine;
            }

            return aux;
        }
        public static void Recursivo(Nodo nodo)
        {
            for (int i = 0; i < 3; i++)
            {
                if (nodo.hijos[i] != null)
                {
                    if (nodo.hijos[i].getTipoDato() == token.DataType.REAL || (nodo.hijos[i].getTipoDato() == token.DataType.INTEGER) ||
                        (nodo.hijos[i].getLexema() == "/"))
                    {
                        temporal.Add(nodo.hijos[i].getTipoDato().ToString());
                        //Console.WriteLine( "hermano: "+nodo.hijos[i].getTipoDato().ToString() +" val" + nodo.hijos[i].getLexema());
                    }

                    Recursivo(nodo.hijos[i]);
                }
                else
                    break;
            }
        }
    }
}
