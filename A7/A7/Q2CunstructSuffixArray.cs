using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A7
{
    public  class Suffix : IComparable
    {
        public Suffix outerInstance;

        public string suffix;
        public int start;

        public Suffix(Suffix outerInstance, string suffix, int start)
        {
            this.outerInstance = outerInstance;
            this.suffix = suffix;
            this.start = start;
        }

        public int CompareTo(object o)
        {
            Suffix other = (Suffix)o;
            return suffix.CompareTo(other.suffix);
        }
    }

    public class Q2CunstructSuffixArray : Processor
    {
        public Q2CunstructSuffixArray(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) =>
        TestTools.Process(inStr, (Func<String, long[]>)Solve);

        private long[] Solve(string text)
        {
            // write your code here    
            char[] ArrayOfText = text.ToCharArray();
            long[] order = Sorting(ArrayOfText);
            long[] classes = CharClasses(ArrayOfText, order);
            int l = 1;
            while (l < text.Length)
            {
                order = Sort(ArrayOfText, l, order, classes);
                classes = UpdateClasses(order, classes, l);
                l *= 2;
            }
            return order;
        }

        private long[] UpdateClasses(long[] order, long[] classes, int l)
        {
            long[] newClass = new long[order.Length];
            newClass[order[0]] = 0;
            for (int i = 1; i < order.Length; i++)
            {
                long current = order[i];
                long prev = order[i - 1];
                long mid = current + l;
                long midPrev = (prev + l) % order.Length;
                if ((classes[current] != classes[prev]) || classes[mid] != classes[midPrev])
                {
                    newClass[current] = newClass[prev] + 1;
                }
                else
                {
                    newClass[current] = newClass[prev];
                }
            }

            return newClass;
        }

        private long[] Sort(char[] text, int l, long[] order, long[] classes)
        {
            long[] newOrder = new long[text.Length];
            long[] count = new long[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                count[classes[i]]++;
            }
            for (int i = 1; i < text.Length; i++)
            {
                count[i] += count[i - 1];
            }
            for (int i = text.Length - 1; i >= 0; i--)
            {
                long start = (order[i] - l + text.Length) % text.Length;
                long cl = classes[start];
                count[cl]--;
                newOrder[count[cl]] = start;
            }
            return newOrder;
        }

        private long[] CharClasses(char[] text, long[] order)
        {
            long[] classy = new long[text.Length];
            classy[order[0]] = 0;
            for (int i = 1; i < text.Length; i++)
            {
                if (text[order[i]] != text[order[i - 1]])
                {
                    classy[order[i]] = classy[order[i - 1]] + 1;
                }
                else
                {
                    classy[order[i]] = classy[order[i - 1]];
                }
            }
            return classy;
        }

        private long[] Sorting(char[] text)
        {
            long[] order = new long[text.Length];
            long[] count = new long[6];
            for (int i = 0; i < order.Length; i++)
            {
                count[charToNum(text[i])]++;
            }
            for (int i = 1; i < count.Length; i++)
            {
                count[i] += count[i - 1];
            }

            for (int i = order.Length - 1; i >= 0; i--)
            {
                char c = text[i];
                count[charToNum(c)]--;
                order[count[charToNum(c)]] = i;
            }
            return order;

        }

        private int charToNum(char v)
        {
            switch (v)
            {
                case '$':
                    return 1;
                case 'A':
                    return 2;
                case 'C':
                    return 3;
                case 'G':
                    return 4;
                case 'T':
                    return 5;
                default:
                    return -10;
            }
        }
    }
}
