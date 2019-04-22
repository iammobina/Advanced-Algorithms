using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace Exam1
{
    public class Q1Betweenness : Processor
    {
            public class Node
            {
                public long Data;
                public Node left, right, root;
                public long min = long.MinValue;
                public long max = long.MaxValue;


                public Node(long data)
                {
                    Data = data;
                    root = left = right = null;
                }

            }

            public Q1Betweenness(string testDataName) : base(testDataName)
        {
            //this.ExcludeTestCaseRangeInclusive(2, 50);
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long[]>)Solve);


        public long[] Solve(long NodeCount, long[][] edges)
        {
            long[] distances = new long[NodeCount + 1];
            List<long>[] Graph = LoadGraph(NodeCount, edges);
            for(int i=0;i<distances.Length;i++)
            {
                distances[i] =long.MaxValue;
            }
//          long start = 0;
            long StartNode = edges[0][0];
            long EndNode = edges[NodeCount-1][0];
            distances[StartNode] = 0;
            Queue<long> queue = new Queue<long>();
            foreach (var vertex in edges)
            {
                queue.Enqueue(vertex[0]);
                while (queue.Count != 0)
                {
                    long u = queue.Dequeue();
                    for (int i = 0; i < Graph[u].Count(); i++)
                    {
                        long v = Graph[u][i];
                        if (distances[v] == long.MaxValue)
                        {
                            queue.Enqueue(v);
                            distances[v] = distances[u] + 1;
                        }
                    }
                }
            }
            //distances[0] = 0;
            //if (distances[EndNode] !=long.MaxValue )
            //{

            //}


            long[] Answer = new long[NodeCount];
            Array.Sort(distances);
            Array.Reverse(distances);
            Array.Copy(distances, Answer, NodeCount);
         
            //for(int j=1;j<NodeCount;j++)
            //{
            //    Answer[j]=
            //}
            
            

            return Answer;
        }
        //public Node[] CreateGraph(long nodecount,long[][] edges)
        //{

        //}
        //public long[] DFSSearch(long NodeCount, long[][] edges)
        //{
        //    for (int i = 0; i < edges.Count(); i++)
        //    {
        //        for (int j = 0; j < edges.Count(); j++)
        //        {
        //            if(i !=j)
        //        }
        //    }
        //}
        public long[] PreOrder(Node[] binaryTree)
        {
            Stack<Node> s = new Stack<Node>();
            List<long> Answer = new List<long>();
            Node root = binaryTree[0];
            s.Push(root);
            while (s.Count > 0)
            {
                Node current = s.Pop();
                Answer.Add(current.Data);
                if (current.right != null)
                    s.Push(current.right);
                if (current.left != null)
                    s.Push(current.left);
            }
            return Answer.ToArray();
        }
        //Create a directed Graph
        public List<long>[] LoadGraph(long nodeCount,long[][] edges)
        {
            List<long>[] Graph = new List<long>[nodeCount + 1];
            for (int i=0;i<Graph.Count();i++)
            {
                Graph[i] = new List<long>();
            }
            foreach(var vertex in edges)
            {
                Graph[vertex[0]].Add(vertex[1]);
            }
            return Graph;
        }

        //public long RandomStartNode(long nodeCount, long[][] edges)
        //{
        //    Random rand = new Random();
        //    for
        //}
    }

}
