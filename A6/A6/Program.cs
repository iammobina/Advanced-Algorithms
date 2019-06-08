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

            Q2ReconstructStringFromBWT ffs = new Q2ReconstructStringFromBWT("dd");
            ffs.Solve("CG$TTGTC");

            Q3MatchingAgainCompressedString ff = new Q3MatchingAgainCompressedString("fdd");
            ff.Solve("CG$TTGTC", 2, new string[] { "TTG","GTG" });
            

            //Q4ConstructSuffixArray hh = new Q4ConstructSuffixArray("dd");
            //hh.Solve("GAC$");

        }
    }
}
