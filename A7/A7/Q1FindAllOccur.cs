using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A7
{
    public class Q1FindAllOccur : Processor
    {
        public Q1FindAllOccur(string testDataName) : base(testDataName)
        {
			this.VerifyResultWithoutOrder = true;
        }

        public override string Process(string inStr) =>
        TestTools.Process(inStr, (Func<String, String, long[]>)Solve,"\n");

        public long[] Solve(string text, string pattern)
        {
            // write your code here

            List<long> result = new List<long>();
            string str = pattern + "$" + text;
            long[] s = BorderCount(str);
            for (int i = pattern.Length; i < str.Length; i++)
            {
                if (s[i] == pattern.Length)
                    result.Add(i - pattern.Length * 2);
            }
            if (result.Count() == 0)
                result.Add(-1);

            return result.ToArray();

        }

        public long[] BorderCount(string text)
        {
            long[] result = new long[text.Length];
            long border = 0;
            for (int i = 1; i < text.Length; i++)
            {
                while (border > 0 && text[i] != text[(int)border])
                {
                    border = result[border - 1];
                }
                if (text[i] == text[(int)border])
                {
                    border++;
                }
                else
                {
                    border = 0;
                }
                result[i] = border;
            }
            return result;
        }
    }
}
