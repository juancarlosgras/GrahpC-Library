# Grahp C# Library
The project contains libraries for the management of directed graphs. In graph theory, a directed graph (or digraph) is a graph, or set of vertices connected by edges, where the edges have a direction associated with them. In formal terms, a directed graph is an ordered pair G = (V, E) with. [*Wikipedia](https://en.wikipedia.org/wiki/Directed_graph)
# How to use
From NuGet: Install-Package graphlibrary

Creating the vertices of a graph.
```c#
using GraphClassLibrary;
········
Graph myGraph = new Graph();
myGraph.addVertex("001", 21);
myGraph.addVertex("002", "string node");
myGraph.addVertex("003", new Uri("http://github.com"));
```
![Vertexs](https://github.com/juancarlosgras/GrahpC-Library/blob/master/graph1.png)

Creating relations (edges) between vertexs.
```c#
myGraph.addEdge("Edge 1", "001", "003");
myGraph.addEdge(2, "002", "003");
myGraph.addEdge(new Random(), "003", "002");
```
![Vertexs](https://github.com/juancarlosgras/GrahpC-Library/blob/master/graph2.png)
