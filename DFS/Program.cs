using System;
using System.Collections.Generic;
using System.Linq;

namespace DFS
{
    public class Node
    {
        public int Id { get; set; }
        public List<int> Children { get; set; }

        public Node(int id, List<int> children)
        {
            Id = id;
            Children = children;
        }
    }
    class Program
    {
        static List<int>[] graph1 = new List<int>[]
        {
                new List<int>(){2},         //1
                new List<int>(){1, 3, 6},   //2
                new List<int>(){2},         //3
                new List<int>(){5, 7},      //4
                new List<int>(){4, 6, 8},   //5
                new List<int>(){2, 5},      //6
                new List<int>(){4},         //7
                new List<int>(){5},         //8
        };
        private static bool[] visited;
        //    static List<int>[] graph = new List<int>[]
        //    {
        //        new List<int>(){5, 6, 7},         //1
        //        new List<int>(){},                   //2
        //        new List<int>(){},                   //3
        //        new List<int>(){1},                //4
        //        new List<int>(){2, 8},            //5
        //        new List<int>(){3, 4, 7, 9},      //6
        //        new List<int>(){5},         //7
        //        new List<int>(){7},         //8
        //        new List<int>(){7},         //9
        //    };
        static Node[] graph = new Node[]
        {
            new Node(1, new List<int>{19, 21, 14}),
            new Node(19, new List<int>{7, 12, 31, 21}),
            new Node(21, new List<int>{14}),
            new Node(14, new List<int>{23, 6}),
            new Node(7, new List<int>{1}),
            new Node(12, new List<int>{}),
            new Node(31, new List<int>{21}),
            new Node(23, new List<int>{21}),
            new Node(6, new List<int>{}),
        };
        static List<int> visitedID = new List<int>();
        static void Main(string[] args)
        {
            visited = new bool[graph1.Length];
            for (int i = 0; i < graph1.Length; i++)
            {
                BFS(i);
            }

            //for (int i = 0; i < graph.Length; i++)
            //{
            //    DFS(graph[i].Id);
            //}
        }

        private static void BFS(int i)
        {
            if (visited[i])
            {
                return;
            }
            visited[i] = true;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(i);
            while(queue.Count != 0)
            {
                var currNode = queue.Dequeue();
                
                Console.Write(currNode + 1 + " ");
                foreach (var node in graph1[currNode])
                {
                    if (visited[node-1])
                    {
                        continue;
                    }
                    visited[node-1] = true;
                    queue.Enqueue(node - 1);
                }

            }

        }

        private static void DFS(int i)
        {
            if (visitedID.Contains(i))
            {
                return;
            }
            visitedID.Add(i);
            var currChildren = graph.First(x => x.Id == i);
            foreach (var child in currChildren.Children)
            {
                DFS(child);
            }
            Console.Write(i + " ");
        }
    }
}
