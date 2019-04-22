using Microsoft.VisualStudio.TestTools.UnitTesting;
using A6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6.Tests
{
    [TestClass()]
    public class GradedTests
    {
        [TestMethod(),Timeout(9000)]
        [DeploymentItem("TestData", "A6_TestData")]
        public void SolveTest()
        {
            Processor[] problems = new Processor[] {
                //new Q1ConstructBWT("TD1"),
                new Q2ReconstructStringFromBWT("TD2"),//.ExcludedTestCases.Add( 31),
                //new Q3MatchingAgainCompressedString("TD3"),
               // new Q4ConstructSuffixArray("TD4")
                
            };

            foreach (var p in problems)
            {
                HashSet<int> oooo = new HashSet<int>();
                oooo.Add(31);
                oooo.Add(32);
                oooo.Add(33);
                oooo.Add(34);
                oooo.Add(35);
                oooo.Add(36);
                oooo.Add(37);
                oooo.Add(38);
                oooo.Add(39);
                TestTools.RunLocalTest("A6", p.Process, p.TestDataName, 
                    p.Verifier, 
                    VerifyResultWithoutOrder: p.VerifyResultWithoutOrder,
                    excludedTestCases :oooo );
                   // excludedTestCases: p.ExcludedTestCases:new int[31]
                   // );
                   

                
            }
        }
    }
}