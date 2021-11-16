using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCompiladores_IDE
{
    class CodigoIntermedio
    {
        private List<String> resultado = new List<String>();
        public int contador = 0;
        private int contadorVar = 1;
        private int contadorLabel = 1;


        public void CrearCodigoInter(TreeNode padre, TreeNode treeNode, Nodo nodo)
        {
            
            for (int i = 0; i < 3; i++)
            {
                if (nodo.hijos[i] != null)
                {
                    string nameHijo = $"{nodo.hijos[i].getLexema()} : {nodo.hijos[i].getTipoDato()}";
                    TreeNode aux = treeNode.Nodes.Add(nameHijo);
                    switch (nodo.hijos[i].getLexema())
                    {
                        case "int":
                            declaraciones(treeNode, aux, nodo.hijos[i]);
                            break;
                        case "real":
                            declaraciones(treeNode, aux, nodo.hijos[i]);
                            break;
                        case "bool":
                            declaraciones(treeNode, aux, nodo.hijos[i]);
                            break;
                        case "read":
                            opcionread(treeNode, aux, nodo.hijos[i]);
                            break;
                        default:
                            //error
                            //errores.Add(tokenActual);
                            break;
                    }
                    
                    CrearCodigoInter(treeNode, aux, nodo.hijos[i]);
                }
                else
                    break;
            }

            if (nodo.hermano != null)
            {
                string nameHermano = $"{nodo.hermano.getLexema()} : {nodo.hermano.getTipoDato()}";
                TreeNode aux = padre.Nodes.Add(nameHermano);
                switch (nodo.hermano.getLexema())
                {
                    case "int":
                        declaraciones(padre, aux, nodo.hermano);
                        break;
                    case "real":
                        declaraciones(padre, aux, nodo.hermano);
                        break;
                    case "bool":
                        declaraciones(padre, aux, nodo.hermano);
                        break;
                    case "read":
                        opcionread(padre, aux, nodo.hermano);
                        break;
                    case "Asignacion":
                        opcionAsignar(padre, aux, nodo.hermano);
                        break;
                    default:
                        //error
                        //errores.Add(tokenActual);
                        break;
                }
                resultado.Add("");
                CrearCodigoInter(padre, aux, nodo.hermano);
            }
        }

        public List<String> extraerResultados()
        {
            return resultado;
        }

        public void declaraciones(TreeNode padre, TreeNode treeNode, Nodo nodo)
        {
            for (int i = 0; i < 3; i++)
            {
                if (nodo.hijos[i] != null)
                {
                    if(nodo.hijos[i].getLexema() != "float" && nodo.hijos[i].getLexema() !="int" &&
                        nodo.hijos[i].getLexema() != "bool")
                    {
                        resultado.Add(nodo.hijos[i].getTipoDato() + " " + nodo.hijos[i].getLexema());
                    }
                    string nameHijo = $"{nodo.hijos[i].getLexema()} : {nodo.hijos[i].getTipoDato()}";
                    TreeNode aux = treeNode.Nodes.Add(nameHijo);
                    declaraciones(treeNode, aux, nodo.hijos[i]);
                }
                else
                    break;
            }

            if (nodo.hermano != null)
            {
                if(nodo.hermano.getLexema() !="float" && nodo.hermano.getLexema()!="int" &&
                    nodo.hermano.getLexema() != "bool")
                {
                    resultado.Add(nodo.hermano.getTipoDato() + " " + nodo.hermano.getLexema());
                }
                string nameHermano = $"{nodo.hermano.getLexema()} : {nodo.hermano.getTipoDato()}";
                TreeNode aux = padre.Nodes.Add(nameHermano);
                declaraciones(padre, aux, nodo.hermano);
            }
        }

        public void opcionread(TreeNode padre, TreeNode treeNode, Nodo nodo)
        {
            for (int i = 0; i < 3; i++)
            {
                if (nodo.hijos[i] != null)
                {
                    if (nodo.hijos[i].getLexema() != "read")
                    {
                        resultado.Add("READ " + nodo.hijos[i].getLexema());
                    }
                    string nameHijo = $"{nodo.hijos[i].getLexema()} : {nodo.hijos[i].getTipoDato()}";
                    TreeNode aux = treeNode.Nodes.Add(nameHijo);
                    opcionread(treeNode, aux, nodo.hijos[i]);
                }
                else
                    break;
            }
            /*if (nodo.hermano != null)
            {
                
                    resultado.Add( "READ " + nodo.hermano.getLexema());
                    string nameHermano = $"{nodo.hermano.getLexema()} : {nodo.hermano.getTipoDato()}";
                    TreeNode aux = padre.Nodes.Add(nameHermano);
                    
                

            }*/
        }

        public void opcionAsignar(TreeNode padre, TreeNode treeNode, Nodo nodo)
        {
            for (int i = 0; i < 3; i++)
            {
                if (nodo.hijos[i] != null)
                {
                 
                    resultado.Add(nodo.hijos[i].getTipoDato()+ " " +nodo.hijos[i].getLexema());
                    string nameHijo = $"{nodo.hijos[i].getLexema()} : {nodo.hijos[i].getTipoDato()}";
                    TreeNode aux = treeNode.Nodes.Add(nameHijo);
                    opcionAsignar(treeNode, aux, nodo.hijos[i]);
                }
                else
                    break;
            }
            /*if (nodo.hermano != null)
            {
                if(nodo.hermano.getTipoToken() == token.Type.ASIGNACION)
                {
                    resultado.Add(nodo.hermano.getTipoDato() + " " + nodo.hermano.getLexema());
                    string nameHermano = $"{nodo.hermano.getLexema()} : {nodo.hermano.getTipoDato()}";
                    TreeNode aux = padre.Nodes.Add(nameHermano);
                    declaraciones(padre, aux, nodo.hermano);
                }
                
            }*/
        }


        /*--------------------------------------------------------------------------------*/
        private string TempVarGen() { return $"T{contadorVar++}"; }
        private string TempLabelGen() { return $"L{contadorLabel++}"; }

        public void CodeGen(Nodo n, Nodo padre)
        {
            if(n.getTipoToken() == token.Type.IF)
            {
                string ifLable = TempLabelGen();

                if (n.hijos[0] != null) CodeGen(n.hijos[0], n);
                resultado.Add($"if_false {n.hijos[0].label} goto {ifLable}");
                if (n.hijos[1] != null) CodeGen(n.hijos[1], n);
                resultado.Add($"label {ifLable}");
                if (n.hijos[2] != null) CodeGen(n.hijos[2], n);
            }
            else if(n.getTipoToken() == token.Type.WHILE)
            {
                string whileLable1 = TempLabelGen();
                string whileLable2 = TempLabelGen();

                resultado.Add($"label {whileLable1}");
                if (n.hijos[0] != null) CodeGen(n.hijos[0], n);
                resultado.Add($"if_false {n.hijos[0].label} goto {whileLable2}");
                if (n.hijos[1] != null) CodeGen(n.hijos[1], n);
                resultado.Add($"goto {whileLable1}");
                resultado.Add($"label {whileLable2}");
            }
            else if(n.getTipoToken() == token.Type.DO)
            {
                string doLable = TempLabelGen();

                resultado.Add($"label {doLable}");
                if (n.hijos[0] != null) CodeGen(n.hijos[0], n);
                if (n.hijos[1] != null) CodeGen(n.hijos[1], n);
                resultado.Add($"if_false {n.hijos[1].label} goto {doLable}");
            }
            else
            {
                if (n.hijos[0] != null) CodeGen(n.hijos[0], n);
                if (n.hijos[1] != null) CodeGen(n.hijos[1], n);
                if (n.hijos[2] != null) CodeGen(n.hijos[2], n);

                if (n.getTipoToken() == token.Type.ID || n.getTipoToken() == token.Type.NUM)
                {
                    n.label = n.getLexema();
                }

                if(n.getTipoToken() == token.Type.CONDICION)
                {
                    n.label = n.hijos[0].label;
                }

                if (padre != null && padre.getTipoToken() == token.Type.DATATYPE)
                {
                    resultado.Add($"{padre.getTipoDato()} {n.getLexema()}");
                }

                if (n.getTipoToken() == token.Type.SUMA || n.getTipoToken() == token.Type.RESTA ||
                    n.getTipoToken() == token.Type.MULTIPLICACION || n.getTipoToken() == token.Type.DIVISION ||
                    n.getTipoToken() == token.Type.MAYOR_IGUAL || n.getTipoToken() == token.Type.MAYOR_QUE ||
                    n.getTipoToken() == token.Type.MENOR_IGUAL || n.getTipoToken() == token.Type.MENOR_QUE ||
                    n.getTipoToken() == token.Type.IGUALDAD || n.getTipoToken() == token.Type.DESIGUALDAD)
                {
                    n.label = TempVarGen();
                    resultado.Add($"{n.label} = {n.hijos[0].label} {n.getLexema()} {n.hijos[1].label}");
                }

                if (n.getTipoToken() == token.Type.ASIGNACION)
                {
                    resultado.Add($"{n.hijos[0].label} = {n.hijos[1].label}");
                }

                if(n.getTipoToken() == token.Type.READ || n.getTipoToken() == token.Type.WRITE)
                {
                    resultado.Add($"{n.getTipoToken()} {n.hijos[0].label}");
                }
            }
            
            if (n.hermano != null) CodeGen(n.hermano, padre);
        }

    }

    
}
