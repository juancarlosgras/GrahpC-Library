using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//************************
//by Juan Carlos Grass
//Lista adjasencia
//************************

namespace GraphClassLibrary
{
    /// <summary>
    /// Graph Management
    /// </summary>
    public class Graph
    {
        //Fields and Properties

        private List<Vertex> verticesList;

        public List<Vertex> VerticesList { get { return verticesList; } }

        //Methods

        public Graph()
            {
                verticesList = new List<Vertex>();
            }

	    public bool isEmpty()
             {
                 return (this.VerticesList.Count == 0 ? true : false);
             }

        public Vertex getVertex(String pVertexKey) 
        {
            foreach (Vertex theVertex in this.VerticesList)
            {
                if (theVertex.Key == pVertexKey)
                    return theVertex;
            }

            return null;
        }

        /// <summary>
        /// Adiciona un vertice al grafo
        /// </summary>
        /// <param name="pVertexKey"> Llave del vértice</param>
        /// <param name="pInfo"> Objeto que contiene la información del vértice</param>
        public void addVertex(String pVertexKey, Object pInfo)
        {
            Vertex vert = new Vertex(pVertexKey, pInfo);
            this.verticesList.Add(vert);
        }

        /// <summary>
        /// Adiciona un arco entre dos vértices
        /// </summary>
        /// <param name="pEdgeInfo"> Objeto que contiene la información del arco</param>
        /// <param name="ptailVertex"> Vértice de donde sale el arco</param>
        /// <param name="pheadVertex"> Vértice de donde termina el arco</param>
        public bool addEdge(Object pEdgeInfo, Vertex ptailVertex, Vertex pheadVertex)
        {
            return ptailVertex.insertEdge(pEdgeInfo, pheadVertex);
        }

        /// <summary>
        /// Adiciona un arco entre dos vértices
        /// </summary>
        /// <param name="pEdgeInfo"> Objeto que contiene la información del arco</param>
        /// <param name="ptailVertexKey"> Llave del vértice de donde sale el arco</param>
        /// <param name="pheadVertexKey"> Llave del vértice de donde termina el arco</param>
        public bool addEdge(Object pEdgeInfo, String ptailVertexKey, String pheadVertexKey)
        {
            return this.getVertex(ptailVertexKey).insertEdge(pEdgeInfo, this.getVertex(pheadVertexKey));
        }
        
        public bool areAdjacents(Vertex ptailVertex, Vertex pheadVertex)
            {
                return ptailVertex.isAdjacent(pheadVertex);
            }

        public bool areAdjacents(String ptailVertexKey, String pheadVertexKey)
        {
            return this.getVertex(ptailVertexKey).isAdjacent(this.getVertex(pheadVertexKey));
        }

        public List<Vertex> getAdjacentsVertexs(Vertex pVertex)
        {
            List<Vertex> adjList = new List<Vertex>();
            foreach (Edge adjEdge in pVertex.EdgeList)
                adjList.Add(adjEdge.Vertex);

            return adjList;
        }

        public List<Vertex> getAdjacentsVertexs(String pVertexKey)
        {
            List<Vertex> adjList = new List<Vertex>();
            foreach (Edge adjEdge in this.getVertex(pVertexKey).EdgeList)
                adjList.Add(adjEdge.Vertex);

            return adjList;
        }

        public List<Vertex> getInAdjacentsVertexs(Vertex pVertex)
        {
            List<Vertex> adjList = new List<Vertex>();

            foreach (Vertex theVertex in this.VerticesList)
            {
                if (theVertex.isAdjacent(pVertex))
                    adjList.Add(theVertex);
            }

            return adjList; 
        }

        public List<Edge> getInAdjacentsEdges(Vertex pVertex)
        {
            List<Edge> adjList = new List<Edge>();

            foreach (Vertex theVertex in this.VerticesList)
            {
                if (theVertex.isAdjacent(pVertex))
                    adjList.Add(theVertex.EdgeList.Where(e => e.Vertex.Key == pVertex.Key).FirstOrDefault());
            }

            return adjList;
        }

        public List<Vertex> getInAdjacentsVertexs(String pVertexKey)
        {
            List<Vertex> adjList = new List<Vertex>();

            foreach (Vertex theVertex in this.VerticesList)
            {
                if (theVertex.isAdjacent(this.getVertex(pVertexKey)))
                    adjList.Add(theVertex);
            }

            return adjList; 
        }

        public int outDegree(Vertex pVertex)
        {
            return pVertex.EdgeList.Count;
        }

        public int outDegree(String pVertexKey)
        {
            return this.getVertex(pVertexKey).EdgeList.Count;
        }

        public int inDegree(Vertex pVertex)
        {
            int inDegree = 0;
            foreach (Vertex theVertex in VerticesList)
            {
                if (theVertex.isAdjacent(pVertex))
                    inDegree++;
            }

            return inDegree;
        }

        public int inDegree(String pVertexKey)
        {
            int inDegree = 0;
            foreach (Vertex theVertex in this.VerticesList)
            {
                if (theVertex.isAdjacent(this.getVertex(pVertexKey)))
                    inDegree++;
            }

            return inDegree;
        }

        public int degree(Vertex pVertex)
        {
            return inDegree(pVertex) + outDegree(pVertex);
        }

        public int degree(String pVertexKey)
        {
            return inDegree(pVertexKey) + outDegree(pVertexKey);
        }

        public bool deleteEdge(Vertex ptailVertex, Vertex pheadVertex)
        {
            return ptailVertex.deleteEdge(pheadVertex);
        }

        public bool deleteVertex(Vertex pVertex)
        {
            foreach (Vertex delVertex in this.VerticesList)
            {
                if (delVertex.Equals(pVertex))
                {
                    pVertex.deleteAllEdges();
                    this.VerticesList.Remove(pVertex);
                    return true;
                }
            }

            return false;
        }

        public bool deleteVertex(String pVertexKey)
        {
            foreach (Vertex delVertex in this.VerticesList)
            {
                if (delVertex.Key == pVertexKey)
                {
                    Vertex pVertex = this.getVertex(pVertexKey);
                    pVertex.deleteAllEdges();
                    this.VerticesList.Remove(pVertex);
                    return true;
                }
            }

            return false;
        }

        public bool deleteVertexWithEdges(Vertex pVertex)
        {
            foreach (Vertex delVertex in this.VerticesList)
            {
                if (delVertex.isAdjacent(pVertex))
                    delVertex.deleteEdge(pVertex);
            }

            return true;
        }

        public bool deleteVertexWithEdges(String pVertexKey)
        {
            Vertex pVertex = this.getVertex(pVertexKey);

            foreach (Vertex delVertex in this.VerticesList)
            {
                if (delVertex.isAdjacent(pVertex))
                    delVertex.deleteEdge(pVertex);
            }

            return true;
        }

    }
}
