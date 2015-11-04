using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphClassLibrary
{
    /// <summary>
    /// Vertex of the Graph
    /// </summary>
    public class Vertex
    {
        //Fields and Properties
        /// <summary>
        /// Vertex Information
        /// </summary>
        public Object Info { get ; set ; }

        
        /// <summary>
        /// Vertex Key Identification
        /// </summary>
        public String Key { get; set ; }

        private List<Edge> edgeList; //arcos que salen del vertice

        /// <summary>
        /// Edges leaving the vertex
        /// </summary>
        public List<Edge> EdgeList { get { return edgeList; } }

        //Methods

        public Vertex(String key, Object info)
        {
            this.Info = info;
            this.Key = key;
            this.edgeList = new List<Edge>();
        }

        public bool isAdjacent(Vertex vertex)
        {
            foreach (Edge found in this.EdgeList)
            {
                if (found.Vertex != null)// por si este arco no apunta a ningun vertice
                {
                    if (found.Vertex.Equals(vertex))
                        return true;
                }
            }
            return false;
        }

        public bool insertEdge(Object edgeInfo, Vertex vertexPtr) {

            if (!this.isAdjacent(vertexPtr))
            {
                Edge edge = new Edge(edgeInfo, vertexPtr);
                EdgeList.Add(edge);
                return true;
            }
            return false; 
        }

        public bool deleteEdge(Vertex vertex) //vertex es el vertice a que apunta el arco que se quiere eliminar
        {
            foreach (Edge theEdge in EdgeList)
            {
                if (theEdge.Vertex.Equals(vertex))
                {
                    EdgeList.Remove(theEdge);
                    return true;
                }
            }
            return false;
        }

        public void deleteAllEdges() //elimina todos los arcos que salen de este vertice
        {
            this.EdgeList.Clear();
        } 
    }
}
