using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A2
{
    public class Q1ShortestPath : Processor
    {
        public Q1ShortestPath(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long,long[][], long, long, long>)Solve);
        

        public long Solve(long NodeCount, long[][] edges, long StartNode,  long EndNode)
        {
            //Write your code here
            long[] distance = new long[(int)NodeCount + 1];
            List<long>[] Graph = LoadGraph(NodeCount, edges);
            for (int i = 0; i < distance.Length; i++)
            {
                distance[i] = long.MaxValue;
            }

            distance[StartNode] = 0;
            Queue<long> Q = new Queue<long>();
            Q.Enqueue(StartNode);
            while (Q.Count != 0)
            {
                long u = Q.Dequeue();

                for (int i = 0; i < Graph[u].Count; i++)
                {
                    long v = Graph[u][i];
                    if (distance[v] == long.MaxValue)
                    {
                        Q.Enqueue(v);
                        distance[v] = distance[u] + 1;
                    }
                }
            }
            if (distance[EndNode] != long.MaxValue)
            {
                return distance[EndNode];
            }
            else
                return -1;
        }

        public static List<long>[] LoadGraph(long nodeCount, long[][] edges)
        {
            List<long>[] Connection = new List<long>[nodeCount + 1];
            for (int i = 0; i < Connection.Length; i++)
            {
                Connection[i] = new List<long>();
            }

            foreach (var vertex in edges)
            {
                Connection[vertex[0]].Add(vertex[1]);
                Connection[vertex[1]].Add(vertex[0]);
            }
            return Connection;
        }
    }
}
