using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCompiladores_IDE
{
    class lexico
    {
        private enum Estado 
        { 
            START, INID, INNUM, INPOINT, INFLOAT, INFLOAT2,
            INDIAG, INMAYOR, INMENOR, INASSIGN, INDIFERENTE,   
            INCOMENTARIO, INCOMENTARIO2, INCOMENTARIO3, DONE
        }
        static private List<token> listaTokens;
        static private List<token> listaTokensErrores;
        private String tokenResultado;
        private String tokenResultadoE;
        private Boolean bandera;
        private String auxiliar;

        public lexico()
        {
            listaTokens = new List<token>();
            listaTokensErrores = new List<token>();
            bandera = false;
            auxiliar = "";
        }

        public void tokens(token.Type tipoToken, token.DataType tipoDato, String lexema, int linea, int indice)
        {
            token nuevoToken = new token(tipoToken, tipoDato, lexema, indice, linea);
            listaTokens.Add(nuevoToken);
        }

        public void tokensE(token.Type tipoToken, token.DataType tipoDato, String lexema, int linea, int indice)
        {
            token nuevoToken = new token(tipoToken, tipoDato, lexema, indice, linea);
            listaTokensErrores.Add(nuevoToken);
        }

        public List<token> obtenerTokens()
        {
            return listaTokens;
        }

        public List<token> obtenerTokensE()
        {
            return listaTokensErrores;
        }

        public String tokensResultados()
        {
            return tokenResultado;
        }
        public String tokensResultadosE()
        {
            return tokenResultadoE;
        }
        public void obtenerTokens2()
        {
            for (int i = 0; i < listaTokens.Count; i++)
            {
                token actual = listaTokens.ElementAt(i);
                tokenResultado += "[Lexema: " + actual.getLexema() + ",Token: " + actual.getTipoToken() + ",Linea: " + actual.getLinea() + "]" + Environment.NewLine;
            }
        }
        public void obtenerTokens2E()
        {
            for (int i = 0; i < listaTokensErrores.Count; i++)
            {
                token actual = listaTokensErrores.ElementAt(i);
                tokenResultadoE += "[Lexema: " + actual.getLexema() + ",Token: " + actual.getTipoToken() + ",Linea: " + actual.getLinea() + " (Lexico)]" + Environment.NewLine;
            }
        }
        public void Analizado_Lexico(String Cadena, int linea)
        {
            Estado estado = Estado.START;
            string lexema = "";
            if (bandera)
            {
                lexema = auxiliar;
                estado = Estado.INCOMENTARIO2;
            }

            Char c;
            int indice = linea;
            //Boolean bandera = false;
            for (int i = 0; i < Cadena.Length; ++i)
            {
                c = Cadena[i];
                switch (estado)
                {
                    case Estado.START:
                        if (c == '+')
                        {
                            lexema += c;
                            tokens(token.Type.SUMA, token.DataType.NONE, lexema, i + 1, indice);
                            lexema = "";
                        }
                        else if (c == '-')
                        {
                            lexema += c;
                            tokens(token.Type.RESTA, token.DataType.NONE, lexema, i + 1, indice);
                            lexema = "";
                        }
                        else if (c == '*')
                        {
                            lexema += c;
                            tokens(token.Type.MULTIPLICACION, token.DataType.NONE, lexema, i + 1, indice);
                            lexema = "";
                        }
                        else if (c == '/')
                        {
                            lexema += c;
                            estado = Estado.INDIAG;
                        }
                        else if (c == '^')
                        {
                            lexema += c;
                            tokens(token.Type.POTENCIA, token.DataType.NONE, lexema, i + 1, indice);
                            lexema = "";
                        }
                        else if (c == '>')
                        {
                            lexema += c;
                            tokens(token.Type.MAYOR_QUE, token.DataType.NONE, lexema, i + 1, indice);
                            estado = Estado.INMAYOR;
                        }
                        else if (c == '<')
                        {
                            lexema += c;
                            estado = Estado.INMENOR;
                        }
                        else if (c == '=')
                        {
                            lexema += c;
                            estado = Estado.INASSIGN;
                        }
                        else if (c == '!')
                        {
                            lexema += c;
                            estado = Estado.INDIFERENTE;
                        }
                        else if (c == ';')
                        {
                            lexema += c;
                            tokens(token.Type.SEMI, token.DataType.NONE, lexema, i + 1, indice);
                            lexema = "";
                        }
                        else if (c == ',')
                        {
                            lexema += c;
                            tokens(token.Type.COMA, token.DataType.NONE, lexema, i + 1, indice);
                            lexema = "";
                        }
                        else if (c == '(')
                        {
                            lexema += c;
                            tokens(token.Type.LPAREN, token.DataType.NONE, lexema, i + 1, indice);
                            lexema = "";
                        }
                        else if (c == ')')
                        {
                            lexema += c;
                            tokens(token.Type.RPAREN, token.DataType.NONE, lexema, i + 1, indice);
                            lexema = "";
                        }
                        else if (c == '{')
                        {
                            lexema += c;
                            tokens(token.Type.L_LLAVE, token.DataType.NONE, lexema, i + 1, indice);
                            lexema = "";
                        }
                        else if (c == '}')
                        {
                            lexema += c;
                            tokens(token.Type.R_LLAVE, token.DataType.NONE, lexema, i + 1, indice);
                            lexema = "";
                        }
                        else if (Char.IsLetter(c))
                        {
                            lexema += c;
                            estado = Estado.INID;
                        }
                        else if (Char.IsDigit(c))
                        {
                            lexema += c;
                            estado = Estado.INNUM;
                        }
                        else if (Char.IsSeparator(c))
                        {
                            lexema = "";
                        }else if(c == '.'){
                            lexema += c;
                            estado = Estado.INPOINT;
                        }
                        else
                        {
                            lexema += c;
                            tokens(token.Type.ERROR, token.DataType.NONE, lexema, i + 1, indice);
                            lexema = "";
                        }

                        break;
                    case Estado.INDIAG:
                        if (c == '/')
                        {
                            lexema += c;
                            tokens(token.Type.COMENTARIO, token.DataType.NONE, lexema, i + 1, indice);
                            estado = Estado.INCOMENTARIO;
                        }
                        else if (c == '*')
                        {
                            lexema += c;
                            bandera = true;
                            estado = Estado.INCOMENTARIO2;
                        }
                        else
                        {
                            tokens(token.Type.DIVISION, token.DataType.NONE, lexema, i + 1, indice);
                            lexema = "";
                            estado = Estado.START;
                        }
                        break;
                    case Estado.INMAYOR:
                        if (c == '=')
                        {
                            lexema += c;
                            listaTokens.RemoveAt(listaTokens.Count - 1);
                            tokens(token.Type.MAYOR_IGUAL, token.DataType.NONE, lexema, i + 1, indice);
                            lexema = "";
                            estado = Estado.START;
                        }
                        else
                        {
                            lexema = "";
                            estado = Estado.START;
                            i--;
                        }
                        break;
                    case Estado.INMENOR:
                        if (c == '=')
                        {
                            lexema += c;
                            tokens(token.Type.MENOR_IGUAL, token.DataType.NONE, lexema, i + 1, indice);
                            lexema = "";
                            estado = Estado.START;
                        }
                        else
                        {
                            tokens(token.Type.MENOR_QUE, token.DataType.NONE, lexema, i + 1, indice);
                            lexema = "";
                            estado = Estado.START;
                            i--;
                        }
                        break;
                    case Estado.INASSIGN:
                        if (c != '=')
                        {
                            tokens(token.Type.ASIGNACION, token.DataType.NONE, lexema, i + 1, indice);
                            lexema = "";
                            estado = Estado.START;
                            i--;
                        }
                        else
                        {
                            lexema += c;
                            tokens(token.Type.IGUALDAD, token.DataType.NONE, lexema, i + 1, indice);
                            lexema = "";
                            estado = Estado.START;
                        }
                        break;
                    case Estado.INDIFERENTE:
                        if ( c == '=')
                        {
                            lexema += c;
                            tokens(token.Type.DESIGUALDAD, token.DataType.NONE, lexema, i + 1, indice);
                            lexema = "";
                            estado = Estado.START;
                        }
                        else
                        {
                            lexema += c;
                            tokens(token.Type.ERROR, token.DataType.NONE, lexema, i + 1, indice);
                            lexema = "";
                            estado = Estado.START;
                        }
                        break;
                    case Estado.INID:
                        if (Char.IsLetterOrDigit(c))
                        {
                            lexema += c; 
                            estado = Estado.INID;
                        }
                        else
                        {
                            token.Type tipoToken = token.BuscarReservada(lexema);
                            token.DataType tipoDato = token.AsignarTipoDato(lexema);
                            tokens(tipoToken, tipoDato, lexema, i + 1, indice);
                            lexema = "";
                            estado = Estado.START;
                            i--;
                        }
                        break;
                    case Estado.INNUM:
                        if (Char.IsDigit(c))
                        {
                            lexema += c;
                            estado = Estado.INNUM;
                        }
                        else if (c == '.')
                        {
                            lexema += c;
                            estado = Estado.INFLOAT;
                        }
                        else
                        {
                            tokens(token.Type.NUM, token.DataType.INTEGER, lexema, i + 1, indice);
                            lexema = "";
                            i--;
                            estado = Estado.START;
                        }
                        break;
                    case Estado.INFLOAT:
                        if (Char.IsDigit(c))
                        {
                            lexema += c;
                            estado = Estado.INFLOAT2;
                        }
                        else
                        {
                            lexema += c;
                            tokens(token.Type.ERROR, token.DataType.NONE, lexema, i + 1, indice);
                            lexema = "";
                            estado = Estado.START;
                        }
                        break;
                    case Estado.INFLOAT2:
                        if (Char.IsDigit(c))
                        {
                            lexema += c;
                            estado = Estado.INFLOAT2;
                        }
                        else
                        {
                            tokens(token.Type.NUM, token.DataType.REAL, lexema, i + 1, indice);
                            lexema = "";
                            estado = 0;
                            i--;
                        }
                        break;
                    case Estado.INCOMENTARIO2:
                        if (bandera == true)
                        {
                            lexema += c;
                            auxiliar = lexema;
                            if (c == '*')
                            {
                                estado = Estado.INCOMENTARIO3;
                            }
                        }
                        break;
                    case Estado.INCOMENTARIO3:
                        if (c == '/')
                        {
                            lexema += c;
                            tokens(token.Type.COMENTARIO, token.DataType.NONE, lexema, i + 1, indice);
                            lexema = "";
                            bandera = false;
                            estado = Estado.START;
                        }
                        else
                        {
                            lexema += c;
                            estado = Estado.INCOMENTARIO2;
                        }
                        break;
                    case Estado.INCOMENTARIO:
                        if (c != '/')
                        {

                            lexema += c;
                            listaTokens.RemoveAt(listaTokens.Count - 1);
                            tokens(token.Type.COMENTARIO, token.DataType.NONE, lexema, i + 1, indice);
                            estado = Estado.INCOMENTARIO;
                        }
                        break;
                    case Estado.INPOINT:
                        if (Char.IsDigit(c))
                        {
                            lexema += c;
                            estado = Estado.INPOINT;
                        }
                        else
                        {
                            tokens(token.Type.ERROR, token.DataType.NONE, lexema, i + 1, indice);
                            lexema = "";
                            i--;
                            estado = 0;
                        }
                            break;
                }

            }

            if(lexema.Length != 0 && estado != Estado.INCOMENTARIO)
            {
                token.Type tempToken = token.BuscarReservada(lexema);
                token.DataType tempDato = token.AsignarTipoDato(lexema);
                tokens(tempToken, tempDato, lexema, Cadena.Length, indice);
            }            
        }
    }
}
