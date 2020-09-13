using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Interview
{
    public class Edge
    {
        public int Source { get; set; }
        public int Destination { get; set; }

        public Edge(int src, int dest)
        {
            this.Source = src;
            this.Destination = dest;
        }
    }
    public class Graph
    {
        // A List of Lists to represent an adjacency list
        List<List<int>> adjList = null;
        
        public Graph(List<Edge> edges, int N)
        {
            adjList = new List<List<int>>();
            

            //for (int i = 0; i < N; i++)
            //{
            //    adjList.Add(new List<int>());
            //}

            // add edges to the undirected graph
            foreach(Edge edge in edges)
            {
                List<int> lst = new List<int>();
                lst.Add(edge.Source);
                lst.Add(edge.Destination);
                adjList.Add(lst);
            }
        }

        // Function to perform DFS Traversal
        public void DFS(Graph graph, int v, bool[] discovered)
        {
            // mark current node as discovered
            discovered[v] = true;

            // print current node
            Console.Write(v + " ");

            // do for every edge (v -> u)
            foreach (var a in graph.adjList)
            {
                // u is not discovered
                if (!discovered[a[0]])
                {
                    DFS(graph, a[0], discovered);
                }
            }
        }

        // Perform iterative DFS on graph g starting from vertex v
       public void iterativeDFS(Graph graph, int v, bool[] discovered)
        {
            // create a stack used to do iterative DFS
            Stack<int> stack = new Stack<int>();
            // push the source node into stack
            stack.Push(v);

            while(stack.Count > 0)
            {
                v = stack.Pop();
                if (!discovered[v])
                {
                    discovered[v] = true;
                    Console.Write(v + " ");
                }
            }

        }
	
    }
}
