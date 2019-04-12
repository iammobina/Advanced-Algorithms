using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A5
{
    public class Q4SuffixTree : Processor
    {
        public Q4SuffixTree(string testDataName) : base(testDataName)
        {
            this.VerifyResultWithoutOrder = true;
        }

        public override string Process(string inStr) =>
        TestTools.Process(inStr, (Func<String, String[]>)Solve);

        public string[] Solve(string text)
        {
            // write your code here            
            List<string> result = new List<string>();
            List<Node> tree = textToTree(text);
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);
            while (queue.Count() !=0)
            {
                Node currentNode = tree[queue.Dequeue()];
                if (currentNode.offset != -1)
                {
                    result.Add(text.Substring(currentNode.start, currentNode.start + currentNode.offset + 1));
                }
                for (int i = 0; i < 5; i++)
                {
                    if (currentNode.nextt[i] > 0) queue.Enqueue(currentNode.nextt[i]);
                }
            }
            return result.ToArray();
        }

        public int letterToIndex(char letter)
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
                default:
                    return Node.NA;
            }
        }

        List<Node> textToTree(string text)
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
                while (currentNode.nextt[letterToIndex(text[(initialStart)])] > 0)
                {
                    currentNode = tree[(currentNode.nextt[letterToIndex(text[(initialStart)])])];
                    int currentStart = currentNode.start;
                    int currentOffset = currentNode.offset;
                    int removeIndex = 1;
                    for (int i = 1; i < currentOffset + 1; i++)
                    {
                        if (text[(currentStart + i)] != text[(initialStart + i)])
                        {
                            break;
                        }
                        removeIndex++;
                    }

                    if (currentOffset + 1 - removeIndex > 0)
                    {
                        Node newNodex = new Node(currentStart + removeIndex, currentOffset - removeIndex, count++);
                        currentNode.start = initialStart;
                        currentNode.offset = removeIndex - 1;
                        tree.Add(newNodex);
                        if (currentNode.haveNeighbours)
                        {
                            //Array.Copy(currentNode.nextt, newNodex.nextt, currentNode.nextt.Count());
                            newNodex.nextt = new List<int>();
                            newNodex.nextt.CopyTo(currentNode.next, currentNode.next.Count());
                            newNodex.haveNeighbours = true;
                            currentNode.initNext();
                        }
                        currentNode.nextt[letterToIndex(text[(newNodex.start)])] = newNodex.id;
                        currentNode.haveNeighbours = true;
                    }
                    initialStart += removeIndex;
                    initialOffset -= removeIndex;
                }
                Node newNode = new Node(initialStart, initialOffset, count++);
                tree.Add(newNode);
                currentNode.nextt[letterToIndex(text[(initialStart)])] = newNode.id;
                currentNode.haveNeighbours = true;
            }
            return tree;
        }
    }
}
