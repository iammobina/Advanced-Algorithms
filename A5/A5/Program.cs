using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Q1ConstructTrie nn = new Q1ConstructTrie("dd");
            //nn.Solve(1, new string[] { "ATA" });

            Q2MultiplePatternMatching bbb = new Q2MultiplePatternMatching("ss");
            bbb.Solve("AA", 1, new string[] { "ATA" });
        }
    }
}
