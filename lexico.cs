using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCompiladores_IDE
{
    class lexico
    {
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
        public void tokens(String idToken, String lexema, int linea, int indice)
        {
            token nuevoToken = new token(idToken, lexema, indice, linea);
            listaTokens.Add(nuevoToken);
        }
        public void tokensE(String idToken, String lexema, int linea, int indice)
        {
            token nuevoToken = new token(idToken, lexema, indice, linea);
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
                tokenResultado += "[Lexema: " + actual.getLexema() + ",Token: " + actual.getIdToken() + ",Linea: " + actual.getLinea() + "]" + Environment.NewLine;
            }
        }
        public void obtenerTokens2E()
        {
            for (int i = 0; i < listaTokensErrores.Count; i++)
            {
                token actual = listaTokensErrores.ElementAt(i);
                tokenResultadoE += "[Lexema: " + actual.getLexema() + ",Token: " + actual.getIdToken() + ",Linea: " + actual.getLinea() + "]" + Environment.NewLine;
            }
        }
        public void Analizado_Lexico(String Cadena, int linea)
        {
            int estado = 0;
            string lexema = "";
            if (bandera)
            {
                lexema = auxiliar;
                estado = 25;
            }

            Char c;
            int indice = linea;
            //Boolean bandera = false;
            for (int i = 0; i < Cadena.Length; ++i)
            {
                c = Cadena[i];
                switch (estado)
                {
                    case 0:
                        if (c == '+')
                        {
                            lexema += c;
                            tokens("Suma", lexema, i + 1, indice);
                            lexema = "";
                        }
                        else if (c == '-')
                        {
                            lexema += c;
                            tokens("Resta", lexema, i + 1, indice);
                            lexema = "";
                        }
                        else if (c == '*')
                        {
                            lexema += c;
                            tokens("Multiplicacion", lexema, i + 1, indice);
                            lexema = "";
                        }
                        else if (c == '/')
                        {
                            lexema += c;
                            estado = 4;
                        }
                        else if (c == '^')
                        {
                            lexema += c;
                            tokens("Potencia", lexema, i + 1, indice);
                            lexema = "";
                        }
                        else if (c == '>')
                        {
                            lexema += c;
                            tokens("Mayor que", lexema, i + 1, indice);
                            estado = 6;
                        }
                        else if (c == '<')
                        {
                            lexema += c;
                            estado = 8;
                        }
                        else if (c == '=')
                        {
                            lexema += c;
                            estado = 10;
                        }
                        else if (c == '!')
                        {
                            lexema += c;
                            estado = 12;
                        }
                        else if (c == ';')
                        {
                            lexema += c;
                            tokens("Punto y coma", lexema, i + 1, indice);
                            lexema = "";
                        }
                        else if (c == ',')
                        {
                            lexema += c;
                            tokens("Coma", lexema, i + 1, indice);
                            lexema = "";
                        }
                        else if (c == '(')
                        {
                            lexema += c;
                            tokens("Par abre", lexema, i + 1, indice);
                            lexema = "";
                        }
                        else if (c == ')')
                        {
                            lexema += c;
                            tokens("Par cierra", lexema, i + 1, indice);
                            lexema = "";
                        }
                        else if (c == '{')
                        {
                            lexema += c;
                            tokens("Llave abre", lexema, i + 1, indice);
                            lexema = "";
                        }
                        else if (c == '}')
                        {
                            lexema += c;
                            tokens("Llave cierra", lexema, i + 1, indice);
                            lexema = "";
                        }
                        else if (Char.IsLetter(c))
                        {
                            lexema += c;
                            estado = 20;
                        }
                        else if (Char.IsDigit(c))
                        {
                            lexema += c;
                            estado = 22;
                        }
                        else if (c == ' ')
                        {
                            lexema = "";
                        }else if(c == '.'){
                            lexema += c;
                            estado = 30;
                        }
                        else
                        {
                            lexema += c;
                            tokensE("Error", lexema, i + 1, indice);
                            lexema = "";
                        }

                        break;
                    case 4:
                        if (c == '/')
                        {
                            lexema += c;
                            estado = 28;
                        }
                        else if (c == '*')
                        {
                            lexema += c;
                            bandera = true;
                            estado = 25;
                        }
                        else
                        {
                            tokens("Division", lexema, i + 1, indice);
                            lexema = "";
                            estado = 0;
                        }
                        break;
                    case 6:
                        if (c == '=')
                        {
                            lexema += c;
                            listaTokens.RemoveAt(listaTokens.Count - 1);
                            tokens("Mayor o I", lexema, i + 1, indice);
                            lexema = "";
                            estado = 0;
                        }
                        else
                        {
                            //tokens("Mayor que", lexema, i + 1, indice);
                            lexema = "";
                            estado = 0;
                            i--;
                        }
                        break;
                    case 8:
                        if (c == '=')
                        {
                            lexema += c;
                            tokens("Menor o I", lexema, i + 1, indice);
                            lexema = "";
                            estado = 0;
                        }
                        else
                        {
                            tokens("Menor que", lexema, i + 1, indice);
                            lexema = "";
                            estado = 0;
                            i--;
                        }
                        break;
                    case 10:
                        if (c != '=')
                        {
                            tokens("Asignacion", lexema, i + 1, indice);
                            lexema = "";
                            estado = 0;
                            i--;
                        }
                        else
                        {
                            lexema += c;
                            tokens("Igualdad", lexema, i + 1, indice);
                            lexema = "";
                            estado = 0;
                        }
                        break;
                    case 20:
                        if (Char.IsLetterOrDigit(c))
                        {
                            lexema += c;
                            estado = 20;
                        }
                        else
                        {
                            Boolean rese = false;
                            rese = Reservadas(lexema);
                            if (rese)
                            {
                                tokens("Palabra Reservada", lexema, i + 1, indice);
                            }
                            else
                            {
                                tokens("Identificador", lexema, i + 1, indice);
                            }
                            lexema = "";
                            estado = 0;
                            i--;
                        }
                        break;
                    case 22:
                        if (Char.IsDigit(c))
                        {
                            lexema += c;
                            estado = 22;
                        }
                        else if (c == '.')
                        {
                            lexema += c;
                            estado = 23;
                        }
                        else
                        {
                            tokens("Digito Entero", lexema.ToString(), i + 1, indice);
                            lexema = "";
                            i--;
                            estado = 0;
                        }
                        break;
                    case 23:
                        if (Char.IsDigit(c))
                        {
                            lexema += c;
                            estado = 24;
                        }
                        else
                        {
                            lexema += c;
                            tokensE("Error", lexema, i + 1, indice);
                            lexema = "";
                            estado = 0;
                        }
                        break;
                    case 24:
                        if (Char.IsDigit(c))
                        {
                            lexema += c;
                            estado = 24;
                        }
                        else
                        {
                            tokens("Digito Real", lexema, i + 1, indice);
                            lexema = "";
                            estado = 0;
                            i--;
                        }
                        break;
                    case 25:
                        if (bandera == true)
                        {
                            lexema += c;
                            auxiliar = lexema;
                            if (c == '*')
                            {
                                estado = 26;
                            }
                        }
                        break;
                    case 26:
                        if (c == '/')
                        {
                            lexema += c;
                            tokens("Comentario /**/", lexema, i + 1, indice);
                            lexema = "";
                            bandera = false;
                            estado = 0;
                        }
                        else
                        {
                            lexema += c;
                            estado = 25;
                        }
                        break;
                    case 28:
                        if (c != '/')
                        {

                            lexema += c;
                            listaTokens.RemoveAt(listaTokens.Count - 1);
                            tokens("Comentario", lexema, i + 1, indice);
                            estado = 28;
                        }
                        break;
                    case 30:
                        if (Char.IsDigit(c))
                        {
                            lexema += c;
                            estado = 30;
                        }
                        else
                        {
                            tokensE("Error", lexema, i + 1, indice);
                            lexema = "";
                            i--;
                            estado = 0;
                        }
                            break;
                }

            }
        }
        public Boolean Reservadas(String palabra)
        {
            Boolean bandera = false;
            var PReservadas = new List<string> { "program", "if", "else", "fi", "do", "until", "while", "read", "write", "float", "int", "bool", "and", "or", "not" };
            for (int i = 0; i < PReservadas.Count; ++i)
            {
                if (palabra.ToString() == PReservadas[i].ToString())
                {
                    return true;
                }
                else
                {
                    bandera = false;
                }
            }
            return bandera;
        }
    }
}
