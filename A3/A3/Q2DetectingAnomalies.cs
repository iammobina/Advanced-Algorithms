using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;
namespace A3
{
    public class Q2DetectingAnomalies:Processor
    {
        public class WeightedGraph
        {
            public long V;
            public long E;
            Edge[] edge;
            public WeightedGraph(long v, long e)
            {
                V = v;
                E = e;
                edge = new Edge[e];
                for (int i = 0; i < e; ++i)
                    edge[i] = new Edge();
            }

            public class Edge
            {
                public int src, dest, weight;
                public Edge()
                {
                    src = dest = weight = 0;
                }
            }
        }
        public class Node
        {
            public long index;
            public long distance;

            public Node(long Index, long Distance)
            {
                this.index = Index;
                this.distance = Distance;
            }
        }
        public Q2DetectingAnomalies(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long>)Solve);


        public long Solve(long nodeCount, long[][] edges)
        {
            List<long>[] Graph = LoadGraph(nodeCount, edges);
            List<long>[] Weight = LoadWeight(nodeCount, edges);
            long[] Distance = new long[nodeCount+1];
            for(int i=0;i<Distance.Length;i++)
            {
                Distance[i] = 500000;
            }
            Distance[0] = 0;
            for (int i = 0; i < Graph.Count(); i++)
            {
                for (int u = 0; u < Graph.Count(); u++)
                {
                    for (int k = 0; k < Graph[u].Count(); k++)
                    {
                        long v = Graph[u][k];
                        int v_index = Graph[u].IndexOf(v);
                        if (Distance[v] > Distance[u] + Weight[u][v_index])
                        {
                            Distance[v] = Distance[u] + Weight[u][v_index];
                            if (i == Graph.Count() - 1)
                                return 1;
                        }
                    }
                }
            }
            return 0;//Array.Exists(Distance, x => x < 0) ? 1 : 0;
        }
        public static List<long>[] LoadGraph(long nodeCount,long[][] edges)
        {
            List<long>[] Graph = new List<long>[nodeCount + 1];
            for(int i=0;i<Graph.Length;i++)
            {
                Graph[i] = new List<long>();
            }
            foreach(var vertex in edges)
            {
                Graph[vertex[0]].Add(vertex[1]);
            }
            return Graph;
        }
        public static List<long>[] LoadWeight(long nodeCount,long[][] edges)
        {
            List<long>[] Weight = new List<long>[nodeCount + 1];
            for(int i=0;i<Weight.Length;i++)
            {
                Weight[i] = new List<long>();
            }
            foreach(var vertex in edges)
            {
                Weight[vertex[0]].Add(vertex[2]);
            }
            return Weight;
        }
    }
}
