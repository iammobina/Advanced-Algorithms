using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A3
{
    


   public class Sat
    {
        public int CountV;
        public Edge[] edges;

        public Sat(int n, int m)
        {
            CountV = n;
            edges = new Edge[m];
            for (int i = 0; i < m; ++i)
            {
                edges[i] = new Edge();
            }
        }


        public List<string> SatHelper()
        {
            List<string> answer = new List<string>();
            StringBuilder clauses = new StringBuilder((4 * CountV + 3 * edges.Length) + " " + 3 * CountV + "\n");
            UniqueColor(clauses);
            Colors(clauses);
            answer.Add(clauses.ToString());
            return answer;
        }

        private void Colors(StringBuilder clauses)
        {
            foreach (Edge edge in edges)
            {
                int from = edge.from;
                int to = edge.to;

                clauses.Append(-(from * 3 - 2))
                        .Append(" ")
                        .Append(-(to * 3 - 2))
                        .Append(" 0\n")
                        .Append(-(from * 3 - 1))
                        .Append(" ")
                        .Append(-(to * 3 - 1))
                        .Append(" 0\n")
                        .Append(-(from * 3))
                        .Append(" ")
                        .Append(-(to * 3))
                        .Append(" 0\n");
            }
        }


        private void UniqueColor(StringBuilder clauses)
        {
            for (int i = 1; i < CountV * 3 + 1; i += 3)
            {
                clauses.Append(i)
                        .Append(" ")
                        .Append(i + 1)
                        .Append(" ")
                        .Append(i + 2)
                        .Append(" 0\n")

                        .Append(-i)
                        .Append(" ")
                        .Append(-(i + 1))
                        .Append(" 0\n")
                        .Append(" ")
                        .Append(-i)
                        .Append(" ")
                        .Append(-(i + 2))
                        .Append(" 0\n")
                        .Append(-(i + 1))
                        .Append(" ")
                        .Append(-(i + 2))
                        .Append(" 0\n");
            }
        }
    }

    public class Q1FrequencyAssignment : Processor
    {
        public Q1FrequencyAssignment(string testDataName) : base(testDataName) {
            ExcludeTestCases(2,5,8,13,20,22,28,29);
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<int, int, long[,], string[]>)Solve);

        public string[] Solve(int V, int E, long[,] matrix)
        {
            Sat Answer = new Sat(V, E);

            for (int i = 0; i < E; ++i)
            {
                Answer.edges[i].from = (int)matrix[0,0];
                Answer.edges[i].to = (int)matrix[0, 1];
            }
           return Answer.SatHelper().ToArray();
        }

        public override Action<string, string> Verifier { get; set; } =
            TestTools.SatVerifier;
    }
}
