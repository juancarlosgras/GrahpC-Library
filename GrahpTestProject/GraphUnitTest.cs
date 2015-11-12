using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphClassLibrary;

namespace GrahpTestProject
{
    [TestClass]
    public class GraphUnitTest
    {
        [TestMethod]
        public void TestVertex()
        {
            Graph myGraph = new Graph();
            myGraph.addVertex("001", 21);
            myGraph.addVertex("002", "string node");
            myGraph.addVertex("003", new Uri("http://github.com"));
            Assert.AreEqual(3, myGraph.VerticesList.Count);
        }

        [TestMethod]
        public void TestEdge()
        {
            Graph myGraph = new Graph();
            myGraph.addVertex("001", 21);
            myGraph.addVertex("002", "string node");
            myGraph.addVertex("003", new Uri("http://github.com"));

            myGraph.addEdge("Edge 1", "001", "003");
            myGraph.addEdge(2, "002", "003");
            myGraph.addEdge(new Random(), "003", "002");

            Assert.AreEqual(true, myGraph.deleteEdge(myGraph.getVertex("001"), myGraph.getVertex("003")));
        }

        [TestMethod]
        public void TestMethods()
        {
            Graph myGraph = new Graph();
            myGraph.addVertex("001", 21);
            myGraph.addVertex("002", "string node");
            myGraph.addVertex("003", new Uri("http://github.com"));

            myGraph.addEdge("Edge 1", "001", "003");
            myGraph.addEdge(2, "002", "003");
            myGraph.addEdge(new Random(), "003", "002");

            //Adjacent vertices?
            Assert.AreEqual(false, myGraph.areAdjacents(myGraph.getVertex("001"), myGraph.getVertex("002")));
            Assert.AreEqual(true, myGraph.areAdjacents(myGraph.getVertex("001"), myGraph.getVertex("003")));
            //Number of output edges
            Assert.AreEqual(1, myGraph.outDegree("003"));
            //Number of input edges
            Assert.AreEqual(2, myGraph.inDegree("003"));
        }
    }
}
