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
            //  Dictionary<char, int?> starts = new Dictionary<char, int?>();
            //Dictionary<char, int> starts = new Dictionary<char, int>();
            //Dictionary<char, int[]> Before = new Dictionary<char, int[]>();
            int[] ini = new int[text.Length];
            ini = PreprocessCounterBWT(text, ini);
            //int patternCount = text.Length;
            long[] result = new long[n];
            //for (int i = 0; i < patternCount; ++i)
            //{
            //    patternss[i] = text;
            //    result[i] = CountOccurrences(patternss[i], text, starts, Before,result);

            //}

            for (int i = 0; i < n; i++)
            {
                result[i] = CountOccurrences(text, ini, patterns[i]);
            }
            return result;
        }

        private int[] PreprocessCounterBWT(string bwt, int[] index)/*Dictionary<char, int> starts, Dictionary<char, int[]> before)*/
        {
            //StringBuilder result = new StringBuilder();
            //StringBuilder textBuilder = new StringBuilder(text);
            //SortedSet<string> tree = new SortedSet<string>();
            //int last = text.Length - 1;
            //for (int i = 0; i < text.Length; i++)
            //{
            //    tree.Add(textBuilder.ToString());
            //    char first = textBuilder[0];
            //    textBuilder.Remove(0, 1);
            //    textBuilder.Append(first);
            //}
            //tree.Reverse();
            //// int count = 0;
            //while (tree.Count > 0)
            //{
            //    //result.Append(tree.Skip(text.Length - 1));//.ElementAt(last));
            //    //result.Append(tree.Reverse().ElementAt(0));
            //    //result.Append(tree.First());
            //    result.Append(tree.First().ElementAt(last));
            //    tree.Remove(tree.First());
            //    //count++;
            //}
            //////tree.ToArray();
            ////var m = tree.Select(row => row[text.Length]);
            return new int[] { };
        }

        //public static int Countletter(char letter)
        //{
        //    int counta = 0;
        //    switch(letter)
        //    {
        //        case 'A':
        //            counta++;
        //            return counta;

                   

        //    }
        //}

        //private void PreprocessBWT(string bwt, Dictionary<char, int> starts, Dictionary<char, int[]> Before)
        //{
        //    char[] sortBwt = bwt.ToCharArray();
        //    Array.Sort(sortBwt);

        //    for (int i = 0; i < sortBwt.Length; i++)
        //    {
        //        if (!starts.ContainsKey(sortBwt[i]))
        //        {
        //            starts.Add(sortBwt[i], i);
        //        }
        //        //if (starts.Keys[sortBwt[i]] == null)
        //        //{
        //        //    starts.Add[sortBwt[i]] = i;
        //        //}
        //    }
        //    foreach (char character in starts.Keys)
        //    {
        //        Before[character] = new int[bwt.Length + 1];
        //    }
        //    for (int i = 1; i < bwt.Length + 1; i++)
        //    {
        //        char current = bwt[i - 1];
        //        foreach (KeyValuePair<char, int[]> characterEntry in Before)
        //        {
        //            characterEntry.Value[i] = characterEntry.Value[i - 1] + (characterEntry.Key == current ? 1 : 0);

        //        }
        //    }

        //    }



        //public int LetterToCount(char letter)
        //{
        //    switch(letter)
        //    {
        //        case 'A':
        //                        return 0;
        //                    case 'C':
        //                        return 1;
        //                    case 'G':
        //                        return 2;
        //                    case 'T':
        //                        return 3;
        //                    case '$':
        //                        return 4;
        //                    default:
        //                        return Node.NA;
        //    }
    //    }





        public int CountOccurrences(string bwt, int[] indexes, string pattern)//,/* Dictionary<char, int> starts, Dictionary<char, int[]> occ_counts_before,*/long[] index)
        {
            int first = 0;
            int last = bwt.Length - 1;


            for (int i = pattern.Length - 1; i > 0; i--)
            {
                char letter = pattern[i];
                while (bwt[first] != letter && first != last)
                {
                    first++;
                }
                while (bwt[last] != letter && first != last)
                {
                    last--;
                }
                if (first == last && bwt[first] != letter)
                {
                    return 0;
                }
                first = indexes[first];
                last = indexes[last];
            }
            int count = 0;
            for (int i = first; i <= last; i++)
            {
                if (bwt[i] == pattern[0])
                {
                    count++;
                }
            }
            return count;
        }
    }
}
//    int top = 0;
//    int bottom = bwt.Length - 1;
//    int patternLength = pattern.Length;
//    //while (top <= bottom)
//    //{
//    //    if (patternLength > 0)
//    //    {
//    //        patternLength--;
//    //        char letter = pattern[patternLength];
//    //        if (!occ_counts_before.ContainsKey(letter))
//    //        {
//    //            return 0;
//    //        }

//    //        int topOccurency = occ_counts_before[letter][top];
//    //        int bottomOccurency = occ_counts_before[letter][bottom + 1];
//    //        int start = (int)starts[letter];
//    //        if (bottomOccurency > topOccurency)
//    //        {
//    //            top = start + topOccurency;
//    //            bottom = start + bottomOccurency - 1;
//    //        }
//    //        else
//    //        {
//    //            return 0;
//    //        }
//    //    }
//    //    else
//    //    {
//    //        return (bottom - top + 1);
//    //    }
//    //}
//    //return 0;


