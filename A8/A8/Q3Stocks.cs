using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A8
{
    public class Q3Stocks : Processor
    {
        public Q3Stocks(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
        TestTools.Process(inStr, (Func<long, long, long[][], long>)Solve);

        public virtual long Solve(long stockCount, long pointCount, long[][] matrix)
        {
            long result = minCharts(matrix,stockCount,pointCount);
            return result;
        }



        private long minCharts(long[][] stockData,long sockcount,long pointcount)
        {
            long numStocks = sockcount;
            long numPoint = pointcount;
            bool[,] compareStocks = new bool[numStocks+1,numStocks+1];

            for (int i = 0; i < numStocks; i++)
            {
                for (int j = 0; j < numStocks; j++)
                {
                    if (i == j)
                        continue;

                    compareStocks[i,j] = true;

                    for (int k = 0; k < numPoint; k++)
                    {
                        compareStocks[i,j] &= stockData[i][k] < stockData[j][k];
                        if (!compareStocks[i,j])
                            break;
                    }
                }
            }

            long[,] bipartiteMatching = new long[2,numStocks];
            int[] arr = new int[bipartiteMatching.Length];
            for (int i = 0; i < bipartiteMatching.Length; i++)
            {
                arr[i] = -1;
            }


            int path = 0;
            for (int i = 0; i < numStocks; ++i)
                if (dfs(i, new bool[numStocks], bipartiteMatching, compareStocks))
                    ++path;

            return numStocks - path;
        }

        private bool dfs(int i, bool[] visited, long[,] bipartiteMatching, bool[,] compareStocks)
        {
            if (i == -1)
            {
                return true;
            }
            if (visited[i])
            {
                return false;
            }
            visited[i] = true;
            for (int j = 0; j < compareStocks.Length; ++j)
            {
                if (compareStocks[i,j] && dfs((int)bipartiteMatching[1,j], visited, bipartiteMatching, compareStocks))
                {
                    bipartiteMatching[0,i] = j;
                    bipartiteMatching[1,j] = i;
                    return true;
                }
            }
            return false;
        }


    }
}
