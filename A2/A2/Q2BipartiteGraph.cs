using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A2
{
    public class Q2BipartiteGraph : Processor
    {
        public Q2BipartiteGraph(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long>)Solve);


        public long Solve(long NodeCount, long[][] edges)
        {
            //Write your code here
            long[] Colors = new long[NodeCount + 1];
            List<long>[] Graph = LoadGraph(NodeCount, edges);
            //Colors Hint:
            //0 ---> No Color
            //1 ---> First Color
            //2 ---> Second Color
            // and so on....
            for(int i=0;i<Colors.Length;i++)
            {
                Colors[i] = 0;
            }
            Colors[1] = 1;
            Queue<long> Q = new Queue<long>();
            Q.Enqueue(1);
            while(Q.Count !=0 )
            {
                long HasColor = Q.Dequeue();
                for(int i=0;i<Graph[HasColor].Count;i++)
                {
                    long CheckColor = Graph[HasColor][i];
                    if(Colors[CheckColor]==0)
                    {
                        Colors[CheckColor] = 1 - Colors[HasColor];
                        Q.Enqueue(CheckColor);
                    }
                    else if (Colors[CheckColor]==Colors[HasColor])
                    {
                        return 0;
                    }
                }
            } 
            return 1;
        }

        public static List<long>[] LoadGraph(long nodeCount, long[][] edges)
        {
            List<long>[] Connection = new List<long>[nodeCount + 1];
            for(int i=0;i<Connection.Length;i++)
            {
                Connection[i] = new List<long>();
            }
            foreach(var vertex in edges)
            {
                Connection[vertex[0]].Add(new list<long> { vertex[1] , 5});
                Connection[vertex[1]].Add(vertex[0]);
            }
            return Connection;
        }
    }

}
