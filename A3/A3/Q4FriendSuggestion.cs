using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A3
{
    public class Q4FriendSuggestion : Processor
    {
        public static List<long> Answer = new List<long>();
        public Q4FriendSuggestion(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long[][], long, long[][], long[]>)Solve);

        public long[] Solve(long NodeCount, long EdgeCount,
                              long[][] edges, long QueriesCount,
                              long[][] Queries)
        {
            List<long>[] Graph = LoadGraph(NodeCount, edges);
            List<long>[] Weight = LoadWeight(NodeCount, edges);
            List<long>[] ReverseGraph = LoadReverseGraph(NodeCount, edges);
            long[] Distance = new long[NodeCount + 1];
            long[] ReverseDistance = new long[NodeCount + 1];
            for (int i = 0; i < Distance.Length; i++)
            {
                Distance[i] = 60000;
                ReverseDistance[i] = 60000;
            }
            Distance[0] = 0;
            ReverseDistance[0] = 0;


            return Answer.ToArray();
        }



        public static List<long>[] ProccessQuery(long quercount, long[][] queryE)
        {
            List<long>[] query = new List<long>[quercount + 1];
            for (int i = 0; i < query.Length; i++)
            {
                query[i] = new List<long>();
            }
            foreach (var vertex in queryE)
            {
                //vertex 0 mishe node s
                //vertex 1 mishe target
                query[vertex[0]].Add(vertex[1]);
            }
            return query;
        }

        public static List<long>[] LoadGraph(long nodeCount, long[][] edges)
        {
            List<long>[] Graph = new List<long>[nodeCount + 1];
            for (int i = 0; i < Graph.Length; i++)
            {
                Graph[i] = new List<long>();
            }
            foreach (var vertex in edges)
            {
                Graph[vertex[0]].Add(vertex[1]);
            }
            return Graph;
        }

        public static List<long>[] LoadWeight(long nodeCount, long[][] edges)
        {
            List<long>[] Weight = new List<long>[nodeCount + 1];
            for (int i = 0; i < Weight.Length; i++)
            {
                Weight[i] = new List<long>();
            }
            foreach (var vertex in edges)
            {
                Weight[vertex[0]].Add(vertex[2]);

            }
            return Weight;
        }

        public static List<long>[] LoadReverseGraph(long nodeCount, long[][] edges)
        {
            List<long>[] ReverseGraph = new List<long>[nodeCount + 1];
            for (int i = 0; i < ReverseGraph.Length; i++)
            {
                ReverseGraph[i] = new List<long>();
            }
            foreach (var vertex in edges)
            {
                ReverseGraph[vertex[1]].Add(vertex[0]);
            }
            return ReverseGraph;
        }
    } 
}
