using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class Suffix : IComparable
    {
        private readonly Q4ConstructSuffixArray outerInstance;

        internal string suffix;
        internal int start;

        internal Suffix(Q4ConstructSuffixArray outerInstance, string suffix, int start)
        {
            this.outerInstance = outerInstance;
            this.suffix = suffix;
            this.start = start;
        }

        public  int CompareTo(object o)
        {
            Suffix other = (Suffix)o;
            return suffix.CompareTo(other.suffix);
        }
    }
    public class Q4ConstructSuffixArray : Processor
    {
        public Q4ConstructSuffixArray(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<String, long[]>)Solve);

        public long[] Solve(string text)
        {
            // write your code here
            List<long> Result = new List<long>();
            //  List<Node> tree = textToTree(text);
            //SortedDictionary<string, long> sortSuffix = new SortedDictionary<string, long>();
            ////LinkedList<int> queue = new LinkedList<int>();
            //Queue<List<int>> queue = new Queue<List<int>>();
            //queue.Enqueue(queue.ElementAt(0));
            //while (queue.Count > 0)
            //{
            //    Node currentNode = tree.Last();/*[queue.Enqueue(queue.ElementAt(queue.Last()))];*/
            //    if (currentNode.haveNeighbours)
            //    {
            //        for (int i = 0; i < text.Length; i++)
            //        {
            //           
            //        }
            //    }
            //    else
            //    {
            //        sortSuffix[text.Substring(currentNode.generalStart, (currentNode.start + currentNode.offset + 1) - currentNode.generalStart)] = currentNode.generalStart;
            //    }
            //}
            //long[] result = new long[sortSuffix.Count];
            //for (int i = 0; i < result.Length; i++)
            //{
            //    result[i] = sortSuffix.ElementAt(i).Value;
            //}
            //return result;


            //Dictionary<string, string> dic = new Dictionary<string, string>();
            Tuple<long, string>[] SizeStr = new Tuple<long, string>[text.Length];

                for (int i = 0; i < SizeStr.Length; i++)
                {
                    string Substr1 = text.Substring(i);
                    SizeStr[i] = new Tuple<long, string>
                    (i , Substr1);
                }

           // SizeStr.OrderByDescending(x => x.Item2);
           SizeStr= SizeStr.OrderBy(x => x.Item2).ToArray();
            
            for (int i = 0; i < text.Length; i++)
            {
                Result.Add(SizeStr[i].Item1);
                    //Tuple[i].Item1.Count());
            }

            return Result.ToArray();
        }


        //public static int letterToIndex(char letter)
        //{
        //    switch (letter)
        //    {
        //        case 'A':
        //            return 0;
        //        case 'C':
        //            return 1;
        //        case 'G':
        //            return 2;
        //        case 'T':
        //            return 3;
        //        case '$':
        //            return 4;
        //        default:
        //            return Node.NA;
        //    }
        //}

        }
    }

