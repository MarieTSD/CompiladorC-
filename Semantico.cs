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
                    n.hijos[0].setTipoDato(token.DataType.ERROR);
                    if (Symtab.BuscarVariable(n.hijos[0]))
                        Symtab.ActualizarVariable(n.hijos[0]);
                    else
                        Symtab.AñadirVariable(n.hijos[0]);
                }
                else
                {
                    if (Symtab.BuscarVariable(n.hijos[0]))
                        Symtab.ActualizarVariable(n.hijos[0]);
                    else
                        Symtab.AñadirVariable(n.hijos[0]);
                }
            }

            if(n.getTipoToken() == token.Type.SUMA || n.getTipoToken() == token.Type.RESTA || 
                n.getTipoToken() == token.Type.MULTIPLICACION || n.getTipoToken() == token.Type.DIVISION)
            {
                if(n.hijos[0].getTipoToken() == token.Type.NUM && n.hijos[1].getTipoToken() == token.Type.NUM)
                {
                    TypeError(n, "Operacion no valida");
                    n.setTipoDato(token.DataType.ERROR);
                }
                else if(n.hijos[0].getTipoDato() != n.hijos[1].getTipoDato())
                {
                    TypeError(n, "Tipos de dato no coinciden");
                    n.setTipoDato(token.DataType.ERROR);
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
                if (n.hijos[0].getTipoToken() == token.Type.NUM && n.hijos[1].getTipoToken() == token.Type.NUM)
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

        public static String GetErroresSemantico()
        {
            String aux = "";
            foreach(String err in errores)
            {
                aux += err + Environment.NewLine;
            }

            return aux;
        }
    }
}
