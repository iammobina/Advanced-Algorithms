using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A7
{
    //public class Suffixy : IComparable
    //{
    //    public Suffixy outeri;

    //    public string suffix;
    //    public int start;

    //    public Suffixy(Suffixy otherii, string suffix, int start)
    //    {
    //        this.outeri = otherii;
    //        this.suffix = suffix;
    //        this.start = start;
    //    }

    //    public int CompareTo(object o)
    //    {
    //        Suffix other = (Suffix)o;
    //        return suffix.CompareTo(other.suffix);
    //    }
    //}
    public class Q3PatternMatchingSuffixArray : Processor
    {
        public Q3PatternMatchingSuffixArray(string testDataName) : base(testDataName)
        {
            this.VerifyResultWithoutOrder = true;
        }

        public override string Process(string inStr) =>
        TestTools.Process(inStr, (Func<String, long, string[], long[]>)Solve, "\n");

        public long[] Solve(string text, long n, string[] patterns)
        {
            // write your code here
            //string Eachpattern = "";
            //for (int i = 0; i < patterns.Length; i++)
            //{
            //    Eachpattern = patterns[i];
            //}
            //long[] negative = new long[1];
            //negative[0] = -1;
            //List<long> occurance = new List<long>();
            //bool[] occurs = new bool[text.Length];
            //long[] result = new long[text.Length];
            //for (int i = 0; i < patterns.Length; i++)
            //{
            //    occurance = findOccurrences(text, patterns[i], occurs);
            // Array.Copy(findOccurrences(text, patterns[i], occurs).ToArray(), result, text.Length);
            //  }
            // List<long> aa = findOccurrences(text, Eachpattern, occurs);
            //long[] suffixArray = ComputeSuffixArray(text);
            //long patternCount = n;
            //for (int patternIndex = 0; patternIndex < patternCount; ++patternIndex)
            //{

            //     occurrences = findOccurrences(patterns[patternIndex], text, suffixArray);
            //    //foreach (int x in occurrences)
            //    //{
            //    //    occurs[x] = true;
            //    //}
            //}
            bool[] occurs = new bool[text.Length];
            List<long> occureation = new List<long>();
            foreach (string letter in patterns)
            {
                //findOccurrences(text, letter, occurs);
                string TotalString = letter + "$" + text;
                long border = 0;
                long[] result = new long[TotalString.Length];
                //int i = 1;
                //long Matcher =
                for (int i = 1; i < TotalString.Length; i++)
                {
                    while (border > 0 && TotalString[i] != TotalString[(int)border])
                    {
                        border = result[border - 1];
                    }
                    if (TotalString[i] == TotalString[(int)border])
                    {
                        border++;
                    }
                    else
                    {
                        border = 0;
                    }
                    result[i] = border;
                    //if (i >= letter.Length && result[i] == letter.Length)
                    if (i >= letter.Length && result[i] == letter.Length && !occurs[i - 2 * letter.Length])
                    {
                        occureation.Add(i - 2 * letter.Length);
                        occurs[i - 2 * letter.Length] = true;
                    }

                }
            }
            if (occureation.Count == 0)
                occureation.Add(-1);

            return occureation.ToArray();
        }


        //public long[] BorderCount(string text)
        //{
        //    long[] result = new long[text.Length];
        //    long border = 0;
        //    for (int i = 1; i < text.Length; i++)
        //    {
        //        while (border > 0 && text[i] != text[(int)border])
        //        {
        //            border = result[border - 1];
        //        }
        //        if (text[i] == text[(int)border])
        //        {
        //            border++;
        //        }
        //        else
        //        {
        //            border = 0;
        //        }
        //        result[i] = border;
        //if (i >= letter.Length && result[i] == letter.Length && !occurs[i - 2 * letter.Length])
        //            {
        //                occureation.Add(i - 2 * letter.Length);
        //                }
        ////    }
        //    return result;
        //}

        //public List<long> findOccurrences(string text, string pattern,bool[] occur)
        //{
        //    //string str = pattern + "$" + text;
        //   // long[] bordercalculation = BorderCount(text);
        //    List<long> occureation = new List<long>();
        //long[] result = new long[text.Length];
        //long border = 0;
        //    for (int i = 1; i<text.Length; i++)
        //    {
        //        while (border > 0 && text[i] != text[(int)border])
        //        {
        //            border = result[border - 1];
        //        }
        //        if (text[i] == text[(int)border])
        //        {
        //            border++;
        //        }
        //        else
        //        {
        //            border = 0;
        //        }
        //        result[i] = border;
        //    }
        //    return occureation;
        //}

        //private long[] ComputeSuffixArray(string text)
        //{

        //    char[] textArray = text.ToCharArray();
        //    long[] order = Sorting(textArray);
        //    long[] clazz = CharClasses(textArray, order);
        //    int l = 1;
        //    while (l < text.Length)
        //    {
        //        order = Sort(textArray, l, order, clazz);
        //        clazz = UpdateClasses(order, clazz, l);
        //        l *= 2;
        //    }
        //    return order;

        //}



        //private long[] UpdateClasses(long[] order, long[] clazz, int l)
        //{
        //    long n = order.Length;
        //    long[] newClass = new long[n];
        //    newClass[order[0]] = 0;
        //    for (int i = 1; i < n; i++)
        //    {
        //        long current = order[i];
        //        long prev = order[i - 1];
        //        long mid = current + l;
        //        long midPrev = (prev + l) % n;
        //        if ((clazz[current] != clazz[prev]) || clazz[mid] != clazz[midPrev])
        //        {
        //            newClass[current] = newClass[prev] + 1;
        //        }
        //        else
        //        {
        //            newClass[current] = newClass[prev];
        //        }
        //    }

        //    return newClass;
        //}

        //private long[] Sort(char[] text, int l, long[] order, long[] clazz)
        //{
        //    long[] newOrder = new long[text.Length];
        //    long[] count = new long[text.Length];
        //    for (int i = 0; i < text.Length; i++)
        //    {
        //        count[clazz[i]]++;
        //    }
        //    for (int i = 1; i < text.Length; i++)
        //    {
        //        count[i] += count[i - 1];
        //    }
        //    for (int i = text.Length - 1; i >= 0; i--)
        //    {
        //        long start = (order[i] - l + text.Length) % text.Length;
        //        long cl = clazz[start];
        //        count[cl]--;
        //        newOrder[count[cl]] = start;
        //    }
        //    return newOrder;
        //}

        //private long[] CharClasses(char[] text, long[] order)
        //{
        //    long[] classy = new long[text.Length];
        //    classy[order[0]] = 0;
        //    for (int i = 1; i < text.Length; i++)
        //    {
        //        if (text[order[i]] != text[order[i - 1]])
        //        {
        //            classy[order[i]] = classy[order[i - 1]] + 1;
        //        }
        //        else
        //        {
        //            classy[order[i]] = classy[order[i - 1]];
        //        }
        //    }
        //    return classy;
        //}

        //private long[] Sorting(char[] text)
        //{
        //    long[] order = new long[text.Length];
        //    long[] count = new long[6];
        //    for (int i = 0; i < order.Length; i++)
        //    {
        //        count[charToNum(text[i])]++;
        //    }
        //    for (int i = 1; i < count.Length; i++)
        //    {
        //        count[i] += count[i - 1];
        //    }

        //    for (int i = order.Length - 1; i >= 0; i--)
        //    {
        //        char c = text[i];
        //        count[charToNum(c)]--;
        //        order[count[charToNum(c)]] = i;
        //    }
        //    return order;
        //}

        //private int charToNum(char v)
        //{
        //    switch (v)
        //    {
        //        case '$':
        //            return 1;
        //        case 'A':
        //            return 2;
        //        case 'C':
        //            return 3;
        //        case 'G':
        //            return 4;
        //        case 'T':
        //            return 5;
        //        default:
        //            return -10;
        //    }
        //}
    }
}

