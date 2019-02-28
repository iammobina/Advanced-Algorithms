using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Q1ShortestPath sh = new Q1ShortestPath("aa");
            //sh.Solve(4, new long[][] { new long[] {1,2 }, new long[] {4,1 }, new long[] {2,3 }, new long[] {3,1 } },2, 4);

            Q2BipartiteGraph bg = new Q2BipartiteGraph("aa");
            bg.Solve(4, new long[][] { new long[] { 1, 2 }, new long[] { 4, 1 }, new long[] { 2, 3 }, new long[] { 3, 1 } });
        }
    }
}
