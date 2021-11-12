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

    }

    
}
