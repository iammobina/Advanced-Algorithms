using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;
using Microsoft.SolverFoundation.Solvers;

namespace A11
{
    public class Clause
    {
        public long firstVar;
        public long secondVar;
    }
    public class TwoSatisfiability
    {
        public long numVars;
        public Clause[] clauses;
        public List<HashSet<long>> sccs = new List<HashSet<long>>();

        public TwoSatisfiability(long n, long m)
        {
            numVars = n;
            clauses = new Clause[m];
            for (int i = 0; i < m; ++i)
            {
                clauses[i] = new Clause();
            }

        }

        internal virtual void setup()
        {
            List<long>[] adj = new List<long>[2 * numVars];
            List<long>[] adjR = new List<long>[2 * numVars];
            for (int i = 0; i < 2 * numVars; i++)
            {
                adj[i] = new List<long>();
                adjR[i] = new List<long>();
            }
            constructImplicationGraph(adj, adjR);
            List<long> order = new List<long>();
            bool[] visited = new bool[2 * numVars];
            for (int i = 0; i < 2 * numVars; i++)
            {
                if (!visited[i])
                {
                    visited[i] = true;
                    dfs1(adjR, visited, i, order);
                    order.Add(i);
                }
            }
            order.Reverse();
            for (int i = 0; i < adj.Length; i++)
            {
                visited[i] = false;
            }

            foreach (int x in order)
            {
                if (!visited[x])
                {
                    HashSet<long> scc = new HashSet<long>();
                    visited[x] = true;
                    dfs2(adj, visited, x, scc);
                    sccs.Add(scc);
                }
            }
        }

        public virtual bool isSatisfiable(long[] result)
        {
            foreach (HashSet<long> scc in sccs)
            {
                foreach (int x in scc)
                {
                    if (scc.Contains(x + numVars) || scc.Contains(x - numVars))
                    {
                        return false;
                    }
                }
            }
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = -1;
            }
            foreach (HashSet<long> scc in sccs)
            {
                foreach (int i in scc)
                {
                    long x;
                    bool isNegative;
                    if (i >= numVars)
                    {
                        x = i - numVars;
                        isNegative = true;
                    }
                    else
                    {
                        x = i;
                        isNegative = false;
                    }
                    if (result[x] == -1)
                    {
                        if (isNegative)
                        {
                            result[x] = 1;
                        }
                        else
                        {
                            result[x] = 0;
                        }
                    }
                }
            }
            return true;
        }

        public void constructImplicationGraph(List<long>[] adj, List<long>[] adjR)
        {

            foreach (Clause clause in clauses)
            {
                long x, y, notX, notY;

                if (clause.firstVar > 0)
                {
                    x = clause.firstVar - 1;
                    notX = x + numVars;
                }
                else
                {
                    x = -clause.firstVar - 1 + numVars;
                    notX = x - numVars;
                }

                if (clause.secondVar > 0)
                {
                    y = clause.secondVar - 1;
                    notY = y + numVars;
                }
                else
                {
                    y = -clause.secondVar - 1 + numVars;
                    notY = y - numVars;
                }

                adj[notX].Add(y);
                adj[notY].Add(x);
                adjR[y].Add(notX);
                adjR[x].Add(notY);
            }
        }



        void dfs1(List<long>[] adj, bool[] visited, int x, List<long> order)
        {

            foreach (int nextX in adj[x])
            {
                if (!visited[nextX])
                {
                    visited[nextX] = true;
                    dfs1(adj, visited, nextX, order);
                    order.Add(nextX);
                }
            }
        }


        void dfs2(List<long>[] adj, bool[] visited, int x, HashSet<long> scc)
        {
            scc.Add(x);
            foreach (int nextX in adj[x])
            {
                if (!visited[nextX])
                {
                    visited[nextX] = true;
                    dfs2(adj, visited, nextX, scc);
                }
            }
        }
    }
    public class Q1CircuitDesign : Processor
    {
        public Q1CircuitDesign(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long[][], Tuple<bool, long[]>>)Solve);

        public override Action<string, string> Verifier =>
            TestTools.SatAssignmentVerifier;

        public virtual Tuple<bool, long[]> Solve(long v, long c, long[][] cnf)
        {
            TwoSatisfiability twoSat = new TwoSatisfiability(v, c);
            for (int i = 0; i < c; ++i)
            {
                twoSat.clauses[i].firstVar = cnf[1][0];
                twoSat.clauses[i].secondVar = cnf[0][1];
            }
            twoSat.setup();

            long[] result = new long[v];
            Tuple<bool, long[]> answer;
            if (twoSat.isSatisfiable(result))
            {
                Tuple.Create("SATISFIABLE\n");
                for (int i = 1; i <= v; ++i)
                {
                    if (result[i - 1] == 1)
                    {
                        //answer = new Tuple<bool, long[]>("hell", -i);
                        Tuple.Create("%d", -i);
                    }
                    else
                    {
                        Tuple.Create("%d", i);
                    }
                    if (i < v)
                    {
                        Tuple.Create(" ");
                    }
                    else
                    {
                        Tuple.Create("\n");
                    }
                }
            }
            else
            {
                Tuple.Create("UNSATISFIABLE\n");

            }

            throw new NotImplementedException();
        }
    }
}