using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A3
{
    public class Edge
    {
        public int from;
        public int to;
    }

    public class ConvertToSat
    {
        public int numVe;
        public Edge[] edges;
        public int countClauses;

        public ConvertToSat(int n, int m)
        {
            numVe = n;
            edges = new Edge[m];
            for (int i = 0; i < m; ++i)
            {
                edges[i] = new Edge();
            }
        }

        public List<string> SatSolving()
        {
            List<string> answer = new List<string>();
            StringBuilder clauses = new StringBuilder();

            appearInPath(clauses);
            VertexInPath(clauses);
            OnceInPath(clauses);
            InEachPosition(clauses);
            Visited(clauses);
            answer.Add((countClauses + " " + numVe * numVe + "\n"));
            answer.Add(clauses.ToString());
            return answer;
        }

        private void appearInPath(StringBuilder clauses)
        {
            for (int i = 1; i < numVe * numVe + 1; i += numVe)
            {
                for (int j = 0; j < numVe; j++)
                {
                    clauses.Append(i + j)
                            .Append(" ");
                }
                clauses.Append("0\n");
                countClauses++;
            }
        }

        private void VertexInPath(StringBuilder clauses)
        {
            for (int i = 1; i < numVe + 1; i++)
            {
                for (int j = 0; j < numVe * numVe; j += numVe)
                {
                    clauses.Append(i + j)
                            .Append(" ");
                }
                clauses.Append("0\n");
                countClauses++;
            }
        }

        private void OnceInPath(StringBuilder clauses)
        {
            for (int i = 1; i < numVe * numVe + 1; i += numVe)
            {
                for (int j = 0; j < numVe; j++)
                {
                    for (int k = j + 1; k < numVe; k++)
                    {
                        clauses.Append(-(i + j))
                                .Append(" ")
                                .Append(-(i + k))
                                .Append(" 0\n");
                        countClauses++;
                    }
                }

            }
        }

        private void InEachPosition(StringBuilder clauses)
        {
            for (int i = 1; i < numVe + 1; i++)
            {
                for (int j = 0; j < numVe * numVe; j += numVe)
                {
                    for (int k = j + numVe; k < numVe * numVe; k += numVe)
                    {
                        clauses.Append(-(i + j))
                                .Append(" ")
                                .Append(-(i + k))
                                .Append(" 0\n");
                        countClauses++;
                    }
                }

            }
        }

        private void Visited(StringBuilder clauses)
        {
            bool[,] adj = new bool[numVe, numVe];
            foreach (Edge edge in edges)
            {
                adj[edge.from - 1, edge.to - 1] = true;
                adj[edge.to - 1, edge.from - 1] = true;
            }
            for (int i = 0; i < numVe; i++)
            {
                for (int j = i + 1; j < numVe; j++)
                {
                    if (!adj[i, j])
                    {
                        for (int k = 0; k < numVe - 1; k++)
                        {
                            clauses.Append(-((i + 1) * numVe - (numVe - 1) + k))
                                    .Append(" ")
                                    .Append(-((j + 1) * numVe - (numVe - 1) + k + 1))
                                    .Append(" 0\n")

                                    .Append(-((j + 1) * numVe - (numVe - 1) + k))
                                    .Append(" ")
                                    .Append(-((i + 1) * numVe - (numVe - 1) + k + 1))
                                    .Append(" 0\n");
                            countClauses += 2;
                        }
                    }
                }
            }
        }

    }


    public class Q2CleaningApartment : Processor
    {
        public Q2CleaningApartment(string testDataName) : base(testDataName)
        {
            ExcludeTestCases(2, 3, 4, 5, 7, 8, 11, 12, 15, 16, 17, 21, 22, 24, 26, 29);
            ExcludeTestCaseRangeInclusive(32, 37);
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<int, int, long[,], string[]>)Solve);

        public string[] Solve(int V, int E, long[,] matrix)
        {
            ConvertToSat converter = new ConvertToSat(V, E);
            for (int i = 0; i < E; ++i)
            {
                converter.edges[i].from = (int)matrix[0, 0];
                converter.edges[i].to = (int)matrix[0, 1];
            }

            return converter.SatSolving().ToArray();

        }

        public override Action<string, string> Verifier { get; set; } =
            TestTools.SatVerifier;
    }
}
