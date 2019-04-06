using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A4
{
    class Program
    {
        static void Main(string[] args)
        {
            Q2Clustering v2 = new Q2Clustering("55");
            v2.Solve(8, new long[][] 
            {new long[]{ 3, 1 },
            new long[]{ 1, 2 },
            new long[] { 4, 6 },
            new long[]{ 9, 8 },
            new long[] { 9, 9 },
            new long[]{ 8, 9 },
            new long[] { 3, 11 },
            new long[] { 4, 12 } }
            ,4);
        }

    }
}
