using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A8
{
    public class Q2Airlines : Processor
    {
        public Q2Airlines(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long[][], long[]>)Solve);

        public static bool[,] adjMatrix;

        public virtual long[] Solve(long flightCount, long crewCount, long[][] info)
        {
             bool[,] bipartiteGraph = readData( flightCount, crewCount, info);
             long[] matching = findMatching(bipartiteGraph);
            return writeResponse(matching).ToArray();
            //return new long[] {0};
        }


        public static bool[,] readData(long fcount,long ccount,long[][] info)
        {
            long numLeft = fcount;
            long numRight = ccount;
            
            adjMatrix = new bool[fcount, ccount];

            //for (int i = 0; i < numLeft; ++i)
            //    for (int j = 0; j < numRight; ++j)
            //        adjMatrix[i][j] = Convert.ToBoolean(info[i][j]);
            //return adjMatrix;


            for (int i = 0; i < numLeft; ++i)
            {
                for (int j = 0; j < numRight; ++j)
                {
                    if(info[i][j]==1)
                    {
                        adjMatrix[i,j] = true;
                    }
                    else if (info[i][j] == 0)
                    {
                        adjMatrix[i,j] = false;
                    }
                }  
            }
            return adjMatrix;
        }

        public List<long> writeResponse(long[] matching)
        {
            List<long> answer = new List<long>();
            for (int i = 0; i < matching.Length; i++)
            {
                //if (i > 0)
                //{
                //    answer.Add(0);
                //}
                if (matching[i] == -1)
                {
                    //if (answer.Contains(Math.Abs(-1)))
                    //    return answer;

                    answer.Add(-1);
                }
                else
                {
                    answer.Add(matching[i] + 1);
                }
            }
            return answer;
        }

        public static bool Dfs(long left, bool[] visited, long[] matchingLeft, long[] matchingRight, bool[,] graph)
        {
            if (left == -1)
            {
                return true;
            }
            if (visited[left])
            {
                return false;
            }
            visited[left] = true;
            for (int right = 0; right < matchingRight.Length-1; right++)
            {
                if (graph[left,right] && Dfs(matchingRight[right], visited, matchingLeft, matchingRight, graph))
                {
                    matchingLeft[left] = right;
                    matchingRight[right] = left;
                    return true;
                }
            }
            return false;
        }

        public long[] findMatching(bool[,] bipartiteGraph)
        {
            long numLeft = bipartiteGraph.Length;
            long numRight = bipartiteGraph.GetLength(0);

            long[] matchingLeft = new long[numLeft];
            long[] matchingRight = new long[numRight];

            for (int i = 0; i < numLeft; i++)
            {
                matchingLeft[i] = -1;
            }
            for (int i = 0; i < numRight; i++)
            {
                matchingRight[i] = -1;
            }

            for (int left = 0; left < numLeft; left++)
            {
                Dfs(left, new bool[numLeft], matchingLeft, matchingRight, bipartiteGraph);
            }

            return matchingLeft;
        }

    }
}
