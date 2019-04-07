using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;
namespace A3
{
    public class Q3ExchangingMoney:Processor
    {
        public Q3ExchangingMoney(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long, string[]>)Solve);


        public string[] Solve(long nodeCount, long[][] edges, long startNode)
        {
            //Write Your Code Here
            List<long>[] Graph = LoadGraph(nodeCount, edges);
            List<long>[] Weight = LoadWeight(nodeCount, edges);
            string[] Answer = new string[nodeCount+1];
            long[] Reachable = new long[nodeCount + 1];
            long[] Distance = new long[nodeCount + 1];
            long[] Shortest = new long[nodeCount + 1];
            for (int i = 0; i < Distance.Length; i++)
            {
                Reachable[i] = 0;
                Shortest[i] = 1;
                Distance[i] = 50000;
            }

            Distance[startNode] = 0;
            Reachable[startNode] = 1;

            Queue<long> Queue = new Queue<long>();
            for (int i = 0; i < Graph.Count(); i++)
            {
                for (int u = 0; u < Graph.Count(); u++)
                {
                    for (int k = 0; k < Graph[u].Count(); k++)
                    {
                        long v = Graph[u][k];
                        //int v_index = Graph[u].IndexOf(v);
                        if (Distance[u] != 50000 && Distance[v] > Distance[u] + Weight[u][k])
                        {
                            Distance[v] = Distance[u] + Weight[u][k];
                            Reachable[v] = 1;
                            if (i == Graph.Count() - 1)
                            {
                                Queue.Enqueue(v);
                            }
                        }
                    }
                }
            }

            long[] Visit = new long[Graph.Count()];
            while (Queue.Count != 0)
            {
                long u = Queue.Dequeue();
                Visit[u] = 1;
                if (u != startNode)
                {
                    Shortest[u] = 0;
                }
                for (int k = 0; k < Graph[u].Count(); k++)
                {
                    long v = Graph[u][k];
                    if (Visit[v] == 0)
                    {
                        Queue.Enqueue(v);
                        Visit[v] = 1;
                        Shortest[v] = 0;
                    }
                }
            }

           // Distance[startNode] = 0;
            //if(Distance[startNode]<0)
            //{
            //    Answer[(int)startNode] = "-";
            // }


            for (int i = 1; i < nodeCount+1 ; i++)
            {
                if (Reachable[i] == 0)
                {
                    Answer[i]="*";
                }
                else if (Shortest[i] == 0)
                {
                    Answer[i]="-";
                }
                else 
                {
                    if(Distance[i]<0 && i==startNode)
                    {
                        Answer[i] = "-";
                    }
                     else Answer[i] = Distance[i].ToString();
                }
               
            }

                 
                return Answer.ToArray();
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
