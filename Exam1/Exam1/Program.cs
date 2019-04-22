using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1
{
    class Program
    {
        static void Main(string[] args)
        {
            Q1Betweenness we = new Q1Betweenness("ff");
            we.Solve(4, new long[][] { new long[] {1,2 }, new long[] {4,1 }, new long[] {2,3 },new long[] {3,1 } });
        }
    }
}
