using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SolverFoundation.Solvers;
using TestCommon;

namespace A11
{
    public class Edge
    {
        int u, v;
        public Edge(int u, int v)
        {
            this.u = u;
            this.v = v;
        }
    }

    public class Q4RescheduleExam : Processor
    {
        public Q4RescheduleExam(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, char[], long[][], char[]>)Solve);

        public static readonly char[] colors_3 = new char[] { 'R', 'G', 'B' };

        public override Action<string, string> Verifier =>
            TestTools.GraphColorVerifier;


        public virtual char[] Solve(long nodeCount, char[] colors, long[][] edges)
        {
            List<string> answer = new List<string>();
            Edge[] edge = new Edge[nodeCount];
            for (int i = 0; i < nodeCount; i++)
            {
                for (int j = 0; j < nodeCount; j++)
                {
                    edge[i] = new Edge(i, j);
                }
            }

            char[] newColors = assignNewColors(nodeCount, edge, colors);

            if (newColors == null)
            {
                answer.Add("Impossible");
            }
            else
            {
                //foreach (var i in newColors)
                 answer.Add(new string (newColors));
            }
            List<char> answeer = new List<char> ();
            foreach(var k in answer)
            {
                foreach (var letter in k)
                {
                    answeer.Add(letter);
                }
            }
            //return new string(answer.ToArray()).ToCharArray(); 
            return answeer.ToArray();
        }
        public char[] assignNewColors(long n, Edge[] edges, char[] colors)
        {
            if (n % 3 == 0)
            {
                char[] newColors = colors;
                for (int i = 0; i < n; i++)
                {
                    newColors[i] = colors_3.ElementAt(i % 3);
                }
                return newColors;
            }
            else
            {
                return null;
            }
        }
    }
}
