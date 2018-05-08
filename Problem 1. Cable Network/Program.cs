using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_1._Cable_Network
{
    class Program
    {
        private static int budget;
        private static int nodes;
        private static int edges;
        private static int[,] fullGraph;
        private static int[,] halfGraph;
        private static List<int> singleNodes;
        static void Main(string[] args)
        {
            ParseInput();
            var data = FindMinEdge();
            Print(fullGraph);
            Console.WriteLine("***********************************");
            Print(halfGraph);
        }

        private static void ParseInput()
        {
            budget = int.Parse(Console.ReadLine().Split().Last());
            nodes = int.Parse(Console.ReadLine().Split().Last());
            edges = int.Parse(Console.ReadLine().Split().Last());
            fullGraph = new int[nodes, nodes];
            halfGraph = new int[nodes, nodes];
            singleNodes = new List<int>();
            for (int edge = 0; edge < edges; edge++)
            {
                var tokens = Console.ReadLine().Split();
                var startNode = int.Parse(tokens[0]);
                var endNode = int.Parse(tokens[1]);
                var weight = int.Parse(tokens[2]);
                if(tokens.Length > 3)
                {
                    halfGraph[startNode, endNode] = weight;
                    singleNodes.Add(endNode);
                }
                fullGraph[startNode, endNode] = weight;
            }
        }
        private static int[] FindMinEdge()
        {
            int[] data = new int[4];
            data[0] = int.MaxValue;
            foreach (var startNode in singleNodes)
            {
                for (int i = 0; i < nodes; i++)
                {
                    if(fullGraph[startNode, i] != 0 
                        && halfGraph[startNode, i] == 0 
                        && fullGraph[startNode, i] < data[0])
                    {
                        data[0] = fullGraph[startNode, i];
                        data[1] = startNode;
                        data[2] = i;
                        data[3] = startNode;
                    }
                }
            }
            return data;
        }
        private static void Print(int[,] graph)
        {
            for (int i = 0; i < nodes; i++)
            {
                for (int j = 0; j < nodes; j++)
                {
                    Console.Write(graph[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
