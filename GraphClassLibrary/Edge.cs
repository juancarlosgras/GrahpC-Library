using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphClassLibrary
{
    /// <summary>
    /// Outgoing Edge
    /// </summary>
    public class Edge
    {
        /// <summary>
        /// Edge Information
        /// </summary>
        public Object Info { get; set; }

        /// <summary>
        /// Head Vertex
        /// </summary>
        public Vertex Vertex {get; set; }

        public Edge(Object info, Vertex vertex)
        {
            this.Vertex = vertex;
            this.Info = info;        
        }

    }
}
