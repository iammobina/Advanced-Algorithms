using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2
{
    class Program
    {
        static void Main(string[] args)
        {
            Q1LatinSquareSAT nn = new Q1LatinSquareSAT("dddd");
            nn.Solve(3, new int?[,] { { 2, 0, 1 }, { 1, 2, 0 }, { 0, 1, 2 } });
        }
    }
}
