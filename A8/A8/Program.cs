using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A8
{
    class Program
    {
        static void Main(string[] args)
        {
            //Q2Airlines q2 = new Q2Airlines("dd");
            //q2.Solve(3, 4, new long[][] {new long[] {1, 1, 0, 1 },
            //new long[] {0 ,1, 0, 0 },
            //new long[] {0 ,0, 0, 0 } });

            Q1Evaquating q1 = new Q1Evaquating("fffff");
            // q1.Solve(2, 0,new long[][] { });
            q1.Solve(2, 1, new long[][] { new long[] { 1 ,2 ,5 } });
//            q1.Solve(4, 5, new long[][]
//            { new long[] { 1, 2 ,9437 },
//                new long[] { 2, 4 ,9505 },
//            new long[] { 1, 3 ,9040 },
//new long[] {3, 4 ,9572 },
//new long[] {2, 3, 1} }

//);


            //Q2Airlines q2 = new Q2Airlines("dd");
            //q2.Solve(4, 2, new long[][] { new long[] { 0,0 }, new long[] { 0, 1}, new long[] { 0, 0 }, new long[] { 0, 1 } });

            //Q3Stocks q3 = new Q3Stocks("dddddd");
            //q3.Solve(2, 1, new long[][] { new long[] { 0, 1001 } });

        }
    }
}
