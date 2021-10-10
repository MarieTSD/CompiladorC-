using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCompiladores_IDE
{
    class Sintactico
    {
        static private List<token> listaTokens;
        static private List<token> errores;
        private token tokenActual;
        private Nodo raiz = null;
        private String tokenResultado;
        private String nodosArbol;
        private int i = 0;
        public Sintactico(List<token> lista)
        {
            listaTokens = lista;
            errores = new List<token> ();
        }
        
        public Nodo arbolSintactico()
        {
            tokenActual = listaTokens.ElementAt(i);
            raiz = programa();
            return raiz;
        }
        public String erroresSintacticos()
        {
            for (int i = 0; i < errores.Count; i++)
            {
                token actual = errores.ElementAt(i);
                tokenResultado += "[Lexema: " + actual.getLexema() + ",Token: " + actual.getTipoToken() + ",Linea: " + actual.getLinea() + " (Sintactico)]" + Environment.NewLine;
            }
            return tokenResultado;
        }

        public String getNodosArbol(Nodo arbol)
        {
            ImprimirArbol(arbol);
            return nodosArbol;
        }

        public void comprobar(token.Type tipoToken)
        {
            if (tipoToken == tokenActual.getTipoToken())
            {
                i++;
                if(i<listaTokens.Count)
                    tokenActual = listaTokens.ElementAt(i);
                while(tokenActual.getTipoToken() == token.Type.COMENTARIO)
                {
                    i++;
                    if (i < listaTokens.Count)
                        tokenActual = listaTokens.ElementAt(i);
                }

            }
            else
            {
                //Hubo un error
                errores.Add(tokenActual);
            }
        }
        
        public void comprobarTipo(token.DataType tipoDato)
        {
            if (tipoDato == tokenActual.getTipoDato())
            {
                i++;
                if(i<listaTokens.Count)
                    tokenActual = listaTokens.ElementAt(i);
                while(tokenActual.getTipoToken() == token.Type.COMENTARIO)
                {
                    i++;
                    if (i < listaTokens.Count)
                        tokenActual = listaTokens.ElementAt(i);
                }

            }
            else
            {
                //Hubo un error
                errores.Add(tokenActual);
            }
        }

        public Nodo programa()
        {
            Nodo temp = new Nodo(tokenActual);
            comprobar(token.Type.PROGRAM);
            comprobar(token.Type.L_LLAVE);
            temp.hijos[0] = listaDeclaracion();
            temp.hijos[1] = listaSentencia();
            comprobar(token.Type.R_LLAVE);
            return temp;
        }

        public Nodo listaDeclaracion()
        {
            Nodo inicio = null;
            Nodo sig = null;
            while (tokenActual.getTipoToken() == token.Type.DATATYPE)
            {
                if(inicio == null)
                {
                    inicio = declaracion();
                    sig = inicio;
                }
                else
                {
                    Nodo nuevo = declaracion();
                    sig.hermano = nuevo;
                    sig = nuevo;
                }
            }
            return inicio;
        }

        public Nodo declaracion()
        {
            Nodo temp = tipo();
            temp.hijos[0] = listaId(temp.getTipoDato());
            return temp;
        }

        public Nodo tipo()
        {
            Nodo temp = new Nodo(tokenActual);
            switch (tokenActual.getTipoDato())
            {
                case token.DataType.INTEGER:
                    comprobarTipo(token.DataType.INTEGER);
                    break;
                case token.DataType.REAL:
                    comprobarTipo(token.DataType.REAL);
                    break;
                case token.DataType.BOOLEAN:
                    comprobarTipo(token.DataType.BOOLEAN);
                    break;
                default:
                    //error
                    errores.Add(tokenActual);
                    break;
            }
            return temp;
        }

        public Nodo listaId(token.DataType tipo)
        {
            Nodo inicio = new Nodo(tokenActual);
            inicio.setTipoDato(tipo);

            Symtab.AñadirVariable(inicio);

            Nodo sig = inicio;
            comprobar(token.Type.ID);
            while (tokenActual.getTipoToken() == token.Type.COMA)
            {
                comprobar(token.Type.COMA);
                Nodo nuevo = new Nodo(tokenActual);
                nuevo.setTipoDato(tipo);

                Symtab.AñadirVariable(nuevo);

                comprobar(token.Type.ID);
                
                sig.hermano = nuevo;
                sig = nuevo;
            }
            comprobar(token.Type.SEMI);
         
            return inicio;
        }

        public Nodo listaSentencia()
        {
            Nodo inicio = null;
            Nodo sig = null;
            while(tokenActual.getTipoToken() == token.Type.IF ||  tokenActual.getTipoToken()  == token.Type.WHILE ||   
                  tokenActual.getTipoToken() == token.Type.DO || tokenActual.getTipoToken() == token.Type.READ ||
                  tokenActual.getTipoToken() == token.Type.WRITE || tokenActual.getTipoToken() == token.Type.L_LLAVE ||
                  tokenActual.getTipoToken() == token.Type.ID
                  )
            {
                if(inicio == null)
                {
                    inicio = sentencia();
                    sig = inicio;
                }
                else
                {
                    Nodo nuevo = sentencia();
                    sig.hermano = nuevo;
                    sig = nuevo;
                }
            }
            return inicio;
        }

        public Nodo sentencia()
        {
            Nodo temp = null;
            switch (tokenActual.getTipoToken())
            {
                case token.Type.IF:
                    temp = seleccion();
                    break;
                case token.Type.WHILE:
                    temp = iteracion();
                    break;
                case token.Type.DO:
                    temp = repeticion();
                    break;
                case token.Type.READ:
                    temp = sentRead();
                    break;
                case token.Type.WRITE:
                    temp = sentWrite();
                    break;
                case token.Type.L_LLAVE:
                    temp = bloque();
                    break;
                case token.Type.ID:
                    temp = asignacion();
                    break;
                default:
                    errores.Add(tokenActual);
                    break;
            }

            return temp;
        }

        public Nodo seleccion()
        {
            Nodo temp = new Nodo(tokenActual);
            comprobar(token.Type.IF);
            comprobar(token.Type.LPAREN);
            temp.hijos[0] = bexpresion();
            comprobar(token.Type.RPAREN);
            comprobar(token.Type.THEN);
            temp.hijos[1] = bloque();
            if (tokenActual.getTipoToken() == token.Type.ELSE)
            {
                comprobar(token.Type.ELSE);
                temp.hijos[2] = bloque();
            }
            comprobar(token.Type.FI);
            return temp;
        }

        public Nodo iteracion()
        {
            Nodo  temp = new Nodo(tokenActual);
            comprobar(token.Type.WHILE);
            comprobar(token.Type.LPAREN);
            temp.hijos[0] = bexpresion();
            comprobar(token.Type.RPAREN);
            temp.hijos[1] = bloque();
            return temp;
        }

        public Nodo repeticion()
        {
            Nodo temp = new Nodo(tokenActual);
            comprobar(token.Type.DO);
            temp.hijos[0] = bloque();
            comprobar(token.Type.UNTIL);
            comprobar(token.Type.LPAREN);
            temp.hijos[1] = bexpresion();
            comprobar(token.Type.RPAREN);
            comprobar(token.Type.SEMI);
            return temp;
        }

        public Nodo sentRead()
        {
            Nodo temp = new Nodo(tokenActual);
            comprobar(token.Type.READ);
            temp.hijos[0] = new Nodo(tokenActual);
            comprobar(token.Type.ID);
            comprobar(token.Type.SEMI);
            return temp;
        }

        public Nodo sentWrite()
        {
            Nodo temp = new Nodo(tokenActual);
            comprobar(token.Type.WRITE);
            temp.hijos[0] = bexpresion();
            comprobar(token.Type.SEMI);
            return temp;
        }

        public Nodo bloque()
        {
            comprobar(token.Type.L_LLAVE);
            Nodo temp = listaSentencia();
            comprobar(token.Type.R_LLAVE);
            return temp;
        }

        public Nodo asignacion()
        {
            Nodo temp = new Nodo();
            temp.setLexema("Asignacion");
            temp.setLinea(tokenActual.getLinea());
            temp.hijos[0] = new Nodo(tokenActual);
            temp.setTipoToken(token.Type.ASIGNACION);

            comprobar(token.Type.ID);
            comprobar(token.Type.ASIGNACION);
            temp.hijos[1] = bexpresion();
            comprobar(token.Type.SEMI);
            return temp;
        }
       
        public Nodo bexpresion()
        {
            Nodo temp = bterm();
            while (tokenActual.getTipoToken() == token.Type.OR)
            {
                Nodo nuevo = new Nodo(tokenActual);
                comprobar(token.Type.OR);
                nuevo.hijos[0] = temp;
                nuevo.hijos[1] = bterm();
                temp = nuevo;
            }
            return temp;
        }

        public Nodo bterm()
        {
            Nodo temp = notfactor();
            while (tokenActual.getTipoToken() == token.Type.AND)
            {
                Nodo nuevo = new Nodo(tokenActual);
                comprobar(token.Type.AND);
                nuevo.hijos[0] = temp;
                nuevo.hijos[1] = notfactor();
                temp = nuevo;
            }
            return temp;
        }

        public Nodo notfactor()
        {
            Nodo temp = null;
            if(tokenActual.getTipoToken() == token.Type.NOT)
            {
                temp = new Nodo(tokenActual);
                comprobar(token.Type.NOT);
                temp.hijos[0] = bfactor();
            }
            else
            {
                temp = bfactor();
            }
            return temp;
        }

        public Nodo bfactor()
        {
            Nodo temp = null;
            if(tokenActual.getTipoToken() == token.Type.TRUE || tokenActual.getTipoToken() == token.Type.FALSE)
            {
                temp = new Nodo(tokenActual);
                if(tokenActual.getTipoToken() == token.Type.TRUE)
                {
                    comprobar(token.Type.TRUE);
                }
                else
                {
                    comprobar(token.Type.FALSE);
                }
            }
            else
            {
                temp = relacion();
            }
            return temp;
        }

        public Nodo relacion()
        {
            Nodo temp = expresion();
            if(tokenActual.getTipoToken() == token.Type.MENOR_IGUAL || tokenActual.getTipoToken() == token.Type.MENOR_QUE ||
               tokenActual.getTipoToken() == token.Type.MAYOR_IGUAL || tokenActual.getTipoToken() == token.Type.MAYOR_QUE ||
               tokenActual.getTipoToken() == token.Type.IGUALDAD || tokenActual.getTipoToken() == token.Type.DESIGUALDAD
              )
            {
                Nodo nuevo = relOp();
                nuevo.hijos[0] = temp;
                nuevo.hijos[1] = expresion();
                temp = nuevo;
            }
            return temp;
        }

        public Nodo relOp()
        {
            Nodo temp = new Nodo(tokenActual);
            switch (tokenActual.getTipoToken())
            {
                case token.Type.MENOR_IGUAL:
                    comprobar(token.Type.MENOR_IGUAL);
                    break;
                case token.Type.MENOR_QUE:
                    comprobar(token.Type.MENOR_QUE);
                    break;
                case token.Type.MAYOR_IGUAL:
                    comprobar(token.Type.MAYOR_IGUAL);
                    break;
                case token.Type.MAYOR_QUE:
                    comprobar(token.Type.MAYOR_QUE);
                    break;
                case token.Type.IGUALDAD:
                    comprobar(token.Type.IGUALDAD);
                    break;
                case token.Type.DESIGUALDAD:
                    comprobar(token.Type.DESIGUALDAD);
                    break;
                default:
                    //Marcar error
                    errores.Add(tokenActual);
                    break;
            }
            return temp;
        }

        public Nodo expresion()
        {
            Nodo temp = termino();
            while (tokenActual.getTipoToken() == token.Type.SUMA || tokenActual.getTipoToken() == token.Type.RESTA)
            {
                Nodo nuevo = sumaOp();
                nuevo.hijos[0] = temp;
                nuevo.hijos[1] = termino();
                temp = nuevo;
            }
            return temp;
        }

        public Nodo sumaOp()
        {
            Nodo temp = new Nodo(tokenActual);
            switch (tokenActual.getTipoToken())
            {
                case token.Type.SUMA:
                    comprobar(token.Type.SUMA);
                    break;
                case token.Type.RESTA:
                    comprobar(token.Type.RESTA);
                    break;
                default:
                    //error
                    errores.Add(tokenActual);
                    break;
            }
            return temp;
        }

        public Nodo termino()
        {
            Nodo temp = signoFactor();
            while (tokenActual.getTipoToken() == token.Type.MULTIPLICACION || tokenActual.getTipoToken() == token.Type.DIVISION)
            {
                Nodo nuevo = multOp();
                nuevo.hijos[0] = temp;
                nuevo.hijos[1] = signoFactor();
                temp = nuevo;
            }
            return temp;
        }

        public Nodo multOp()
        {
            Nodo temp = new Nodo(tokenActual);
            switch (tokenActual.getTipoToken())
            {
                case token.Type.MULTIPLICACION:
                    comprobar(token.Type.MULTIPLICACION);
                    break;
                case token.Type.DIVISION:
                    comprobar(token.Type.DIVISION);
                    break;
                default:
                    //error
                    errores.Add(tokenActual);
                    break;
            }
            return temp;
        }

        public Nodo signoFactor()
        {
            Nodo temp = null;
            if (tokenActual.getTipoToken() == token.Type.SUMA || tokenActual.getTipoToken() == token.Type.RESTA)
            {
                temp = sumaOp();
                temp.hijos[0] = factor();
            }
            else
            {
                temp = factor();
            }
            return temp;
        }

        public Nodo factor()
        {
            Nodo temp = new Nodo();
          
            switch (tokenActual.getTipoToken())
            {
                case token.Type.LPAREN:
                    comprobar(token.Type.LPAREN);
                    temp = bexpresion();
                    comprobar(token.Type.RPAREN);
                    break;
                case token.Type.ID:
                    temp = new Nodo(tokenActual);
                    comprobar(token.Type.ID);
                    break;
                case token.Type.NUM:
                    temp = new Nodo(tokenActual);
                    comprobar(token.Type.NUM);
                    break;
                default:
                    errores.Add(tokenActual);
                    break;
            }
            return temp;
        }

        private void ImprimirArbol(Nodo nodo)
        {
            if(nodo != null)
            {
                nodosArbol += $"Linea:{nodo.getLinea()}, Lexema:{nodo.getLexema()}, Token:{nodo.getTipoToken()}, Tipo:{nodo.getTipoDato()}" + Environment.NewLine; ;
                ImprimirArbol(nodo.hijos[0]);
                ImprimirArbol(nodo.hijos[1]);
                ImprimirArbol(nodo.hijos[2]);
                ImprimirArbol(nodo.hermano);
            }
        }
    }
}
