using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProyectoCompiladores_IDE
{
    class token
    {
        public enum Type
        {
            PROGRAM, ERROR,
            ID, DATATYPE, NUM, COMENTARIO,
            ASIGNACION, DECLARACION, SUMA, RESTA, MULTIPLICACION, DIVISION, POTENCIA, 
            MAYOR_QUE, MENOR_QUE, MAYOR_IGUAL, MENOR_IGUAL, IGUALDAD, DESIGUALDAD,
            LPAREN, RPAREN, L_LLAVE, R_LLAVE, SEMI, COMA,
            AND, OR, NOT, IF, THEN, ELSE, FI, WHILE, DO, UNTIL, READ, WRITE, 
            TRUE,FALSE, CONDICION
        }

        public enum DataType
        {
            INTEGER, REAL, BOOLEAN, ERROR, NONE
        }

        private static readonly Regex reservadas = new Regex(@"program|int|float|bool|and|or|not|true|false|if|then|else|fi|do|until|while|read|write|#.*");

        private Type tipoToken;
        private DataType tipoDato;
        private String lexema;
        private int indice;
        private int linea;


        public token()
        {
            tipoToken = token.Type.ERROR;
            tipoDato = token.DataType.NONE;
            lexema = "";
            linea = 0;
            indice = 0;
        }

        public token(Type tipoToken, DataType tipoDato, String lexema, int linea, int indice)
        {
            this.tipoToken = tipoToken;
            this.tipoDato = tipoDato;
            this.lexema = lexema;
            this.indice = indice;
            this.linea = linea;
        }

        public token(token token)
        {
            this.tipoToken = token.tipoToken;
            this.tipoDato = token.tipoDato;
            this.lexema = token.lexema;
            this.indice = token.indice;
            this.linea = token.linea;
        }

        public static Type BuscarReservada(string lexema)
        {
            string reservada = reservadas.Match(lexema).Success ? reservadas.Match(lexema).Value : null;

            switch (reservada)
            {
                case "program": return Type.PROGRAM;
                case "int": return Type.DATATYPE;
                case "float": return Type.DATATYPE;
                case "bool": return Type.DATATYPE;
                case "and": return Type.AND;
                case "or": return Type.OR;
                case "not": return Type.NOT;
                case "true": return Type.TRUE;
                case "false": return Type.FALSE;
                case "if": return Type.IF;
                case "then": return Type.THEN;
                case "else": return Type.ELSE;
                case "fi": return Type.FI;
                case "do": return Type.DO;
                case "until": return Type.UNTIL;
                case "while": return Type.WHILE;
                case "read": return Type.READ;
                case "write": return Type.WRITE;
                default: return Type.ID;
            }
        }

        public static DataType AsignarTipoDato(string tipo)
        {
            switch (tipo)
            {
                case "int": return DataType.INTEGER;
                case "float": return DataType.REAL;
                case "bool": return DataType.BOOLEAN;
                case "true": return DataType.BOOLEAN;
                case "false": return DataType.BOOLEAN;
                default: return DataType.NONE;
            };
        }

        public int getIndice() { return this.indice; }
        public String getLexema() { return this.lexema; }
        public Type getTipoToken() { return this.tipoToken; }
        public DataType getTipoDato() { return this.tipoDato; }
        public int getLinea() { return this.linea; }

        public void setLexema(String lexema) { this.lexema = lexema;  }
        public void setLinea(int linea) { this.linea = linea; }
        public void setTipoToken(Type tipo) { this.tipoToken = tipo; }
        public void setTipoDato(DataType tipo) { this.tipoDato = tipo; }
    }
}
