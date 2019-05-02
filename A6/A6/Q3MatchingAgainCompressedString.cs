using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class Q3MatchingAgainCompressedString : Processor
    {
        public Q3MatchingAgainCompressedString(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) => 
        TestTools.Process(inStr, (Func<String, long, String[], long[]>)Solve);

        public long[] Solve(string text, long n, string[] patterns)
        {
            Dictionary<char, int?> starts = new Dictionary<char, int?>();
            Dictionary<char, int[]> occ_counts_before = new Dictionary<char, int[]>();
            PreprocessBWT(text, starts, occ_counts_before);
            int patternCount = text.Length;
            string[] patternss = new string[patternCount];
            long[] result = new long[patternCount];
            for (int i = 0; i < patternCount; ++i)
            {
                patternss[i] = text;
                result[i] = CountOccurrences(patternss[i], text, starts, occ_counts_before);

            }
            return result;
        }
            private void PreprocessBWT(string bwt, Dictionary<char, int?> starts, Dictionary<char, int[]> occ_counts_before)
        {
            char[] sortBwt = bwt.ToCharArray();
            Array.Sort(sortBwt);

            for (int i = 0; i < sortBwt.Length; i++)
            {
                if (starts[sortBwt[i]] != null)
                {
                    starts[sortBwt[i]] = i;
                }
            }
            foreach (char character in starts.Keys)
            {
                occ_counts_before[character] = new int[bwt.Length + 1];
            }
            for (int i = 1; i < bwt.Length + 1; i++)
            {
                char current = bwt[i - 1];
                foreach (KeyValuePair<char, int[]> characterEntry in occ_counts_before)
                {
                    characterEntry.Value[i] = characterEntry.Value[i - 1] + (characterEntry.Key == current ? 1 : 0);

                }
            }

        }
        public int CountOccurrences(string pattern, string bwt, Dictionary<char, int?> starts, Dictionary<char, int[]> occ_counts_before)
        {
            int top = 0;
            int bottom = bwt.Length - 1;
            int patternLength = pattern.Length;
            while (top <= bottom)
            {
                if (patternLength > 0)
                {
                    patternLength--;
                    char letter = pattern[patternLength];
                    if (occ_counts_before[letter] == null)
                    {
                        return 0;
                    }

                    int topOccurency = occ_counts_before[letter][top];
                    int bottomOccurency = occ_counts_before[letter][bottom + 1];
                    int start = (int)starts[letter];
                    if (bottomOccurency > topOccurency)
                    {
                        top = start + topOccurency;
                        bottom = start + bottomOccurency - 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return (bottom - top + 1);
                }
            }
            return 0;
        }

    }
}
