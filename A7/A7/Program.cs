using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A7
{
    class Program
    {
        static void Main(string[] args)
        {
            //Q2CunstructSuffixArray dd = new Q2CunstructSuffixArray("ddd");
            //dd.
            Q3PatternMatchingSuffixArray dd = new Q3PatternMatchingSuffixArray("ddd");
            dd.Solve("AAA", 1, new string[] { "A"});
        }
    }
}
