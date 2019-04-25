using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCommon
{
    public abstract class Processor
    {
        public abstract string Process(string inStr);
        public string TestDataName { get; private set; }

        public virtual Action<string, string> Verifier { get; set; } = null;

<<<<<<< HEAD
        public HashSet<int> ExcludedTestCases { get; protected set; } = 
=======
        public HashSet<int> ExcludedTestCases { get; protected set; } =
>>>>>>> master
            new HashSet<int>();

        protected void ExcludeTestCases(params int[] testCases)
        {
<<<<<<< HEAD
            foreach(var t in testCases)
=======
            foreach (var t in testCases)
>>>>>>> master
                ExcludedTestCases.Add(t);
        }

        protected void ExcludeTestCaseRangeInclusive(int l, int u)
        {
            for (int i = l; i <= u; i++)
                ExcludedTestCases.Add(i);
        }

        public bool VerifyResultWithoutOrder { get; protected set; } = false;

        public Processor(string testDataName)
        {
            this.TestDataName = testDataName;
        }
    }
}
