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

            Q2ReconstructStringFromBWT ff= new Q2ReconstructStringFromBWT("fdd");
            ff.Solve("AGGGAA$");

        }
    }
}
