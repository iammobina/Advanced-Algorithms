using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A6
{
    class Program
    {
        static void Main(string[] args)
        {
            //compute runs
            //Q1ConstructBWT nb = new Q1ConstructBWT("ss");
            //nb.Solve("panamabananas$");

            Q3MatchingAgainCompressedString ff = new Q3MatchingAgainCompressedString("fdd");
            ff.Solve("AGGGAA$", 1, new string[] { "GA" });

        }
    }
}
