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
            List<Node> tree = textToTree(text);
            SortedDictionary<string, long> sortSuffix = new SortedDictionary<string, long>();
            //LinkedList<int> queue = new LinkedList<int>();
            Queue<List<int>> queue = new Queue<List<int>>();
            queue.Enqueue(queue.ElementAt(0));
            while (queue.Count > 0)
            {
                Node currentNode = tree.Last();/*[queue.Enqueue(queue.ElementAt(queue.Last()))];*/
                if (currentNode.haveNeighbours)
                {
                    for (int i = 0; i < text.Length; i++)
                    {
                        queue.Enqueue(currentNode.getNeighbours(i));
                    }
                }
                else
                {
                    sortSuffix[text.Substring(currentNode.generalStart, (currentNode.start + currentNode.offset + 1) - currentNode.generalStart)] = currentNode.generalStart;
                }
            }
            long[] result = new long[sortSuffix.Count];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = sortSuffix.ElementAt(i).Value;
            }
            return result;
        }


        public static int letterToIndex(char letter)
        {
            switch (letter)
            {
                case 'A':
                    return 0;
                case 'C':
                    return 1;
                case 'G':
                    return 2;
                case 'T':
                    return 3;
                case '$':
                    return 4;
                default:
                    return Node.NA;
            }
        }

        public static List<Node> textToTree(string text)
        {
            List<Node> tree = new List<Node>();
            int count = 0;
            tree.Add(new Node(0, -1, count++));
            int length = text.Length;

            for (int j = 0; j < length; j++)
            {
                int initialStart = length - 1 - j;
                int initialOffset = j;
                Node currentNode = tree[0];
                while (currentNode.next[letterToIndex(text[initialStart])] > 0)
                {
                    currentNode = tree[currentNode.next[letterToIndex(text[initialStart])]];
                    int currentStart = currentNode.start;
                    int currentOffset = currentNode.offset;
                    int removeIndex = 1;
                    for (int i = 1; i < currentOffset + 1; i++)
                    {
                        if (text[currentStart + i] != text[initialStart + i])
                        {
                            break;
                        }
                        removeIndex++;
                    }

                    if (currentOffset + 1 - removeIndex > 0)
                    {
                        Node newNodex = new Node(currentStart + removeIndex, currentOffset - removeIndex, count++);
                        newNodex.generalStart = currentNode.generalStart;
                        currentNode.start = initialStart;
                        currentNode.offset = removeIndex - 1;
                        tree.Add(newNodex);
                        if (currentNode.haveNeighbours)
                        {
                            Array.Copy(currentNode.next, newNodex.next, currentNode.next.Length);
                            newNodex.haveNeighbours = true;
                            currentNode.initNext();
                        }
                        currentNode.next[letterToIndex(text[newNodex.start])] = newNodex.id;
                        currentNode.haveNeighbours = true;
                    }
                    initialStart += removeIndex;
                    initialOffset -= removeIndex;
                }
                Node newNode = new Node(initialStart, initialOffset, count++);
                newNode.generalStart = length - 1 - j;
                tree.Add(newNode);
                currentNode.next[letterToIndex(text[initialStart])] = newNode.id;
                currentNode.haveNeighbours = true;
            }
            return tree;
        }
           // return new long[] { };
        }
    }

