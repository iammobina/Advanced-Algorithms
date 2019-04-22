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
        //class Node
        //{
        //    public Node

        //}
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
//            long start = 0;
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
        //public long[] BFSSearch(long NodeCount, long[][] edges)
        //{
        //    for(int i=0;i<edges.Count();i++)
        //    {
        //        for(int j=0;j<edges.Count();j++)
        //        {

        //        }
        //    }
        //}
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
