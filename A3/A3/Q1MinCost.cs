using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A3
{
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

    //public class PriorityQueue
    //{
    //    public long Parent(long i)
    //    {
    //        return i / 2;
    //    }

    //    public long LeftChild(long i)
    //    {
    //        return 2*i;
    //    }

    //    public long RightChild(long i)
    //    {
    //        return (2*i + 1);
    //    }


    //    public ChangePriorityQueue(long i,long p)
    //    {

    //    }
    //}
    public class Q1MinCost : Processor
    {
        public Q1MinCost(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long, long, long>)Solve);



        public long Solve(long nodeCount, long[][] edges, long startNode, long endNode)
        {
            //Write Your Code Here
            List<long>[] Graph = LoadGraph(nodeCount, edges);
            List<long>[] weightedgraph = AddWeight(nodeCount, edges);
            //return distance(Graph,WeightedGraph,startNode,endNode);
            // List<Tuple<long, long>>[] weightedLoadGraph = WeightedGraph(nodeCount, edges);
            long[] Distance = new long[nodeCount+1];
            for (int i = 0; i < Distance.Length; i++)
            {
                Distance[i] = long.MaxValue;
            }
            Distance[startNode] = 0;
            Queue<Node> Queue = new Queue<Node>();
            Queue.Enqueue(new Node(startNode, Distance[startNode]));
            while (Queue.Count != 0)
            {
                    Node u = Queue.Dequeue();
                    int u_index = (int)u.index;
                    for (int i = 0; i < Graph[u_index].Count; i++)
                    {
                        long v = Graph[u_index][i];
                        int v_index = Graph[u_index].IndexOf(v);
                        if (Distance[v] > Distance[u_index] + weightedgraph[u_index][i])
                        {
                            Distance[v] = Distance[u_index] + weightedgraph[u_index][i];
                            Queue.Enqueue(new Node(v, Distance[v]));
                        }
                    }
                
            }
                if (Distance[endNode] == long.MaxValue)
                    return -1;
                return Distance[endNode];
            
        }

        public static List<Tuple<long,long>>[] WeightedGraph(long NodeCount,long[][] edges)
        {
            List<Tuple<long, long>>[] Weightedgraph = new List<Tuple<long, long>>[NodeCount + 1];
            for(int i=0; i<Weightedgraph.Length;i++)
            {
                Weightedgraph[i] = new List<Tuple<long, long>>();
            }
            foreach(var vertex in edges)
            {
                Weightedgraph[vertex[0]].Add(Tuple.Create<long,long>(vertex[1],vertex[2]));
            }
            return Weightedgraph;
        }

        public static List<long>[] LoadGraph(long nodeCount, long[][] edges)
        {
            List<long>[] Connection = new List<long>[nodeCount + 1];
            for (int i = 0; i < Connection.Length; i++)
            {
                Connection[i] = new List<long>();
                //   Weight[i] = new List<long>();
            }
            foreach (var vertex in edges)
            {
                Connection[vertex[0]].Add(vertex[1]);
                //Connection[vertex[0]].Add(vertex[2]);

                //  Connection[vertex[0]].Add(new List<long>[] Weight[vertex[1]].Add(vertex[2]);
                //  Weight[vertex[0]].Add(vertex[2]);

            }
            return Connection;

        }

        public static List<long>[] AddWeight(long nodeCount, long[][] edges)
        {
            List<long>[] Weight = new List<long>[nodeCount + 1];
            for (int i = 0; i < Weight.Length; i++)
            {
                Weight[i] = new List<long>();
            }
            foreach (var vertex in edges)
            {
                //Connection[vertex[0]].Add(vertex[1]);
                //Connection[vertex[0]].Add(vertex[2]);

                //Connection[vertex[0]].Add(Weight[vertex[1]].Add(vertex[2]);
                Weight[vertex[0]].Add(vertex[2]);
            }
            return Weight;
        }
    }
}