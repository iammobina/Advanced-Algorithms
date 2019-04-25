using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A5
{
    public class Q5ShortestNonSharedSubstring : Processor
    {
        public Q5ShortestNonSharedSubstring(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) =>
        TestTools.Process(inStr, (Func<String, String, String>)Solve);

        private string Solve(string text1, string text2)
        {
            // write your code here            
            string text = text1+ "#" + text2 + "$";
            List<Node> tree = textToTree(text);
            List<string> sortSuffix = new List<string>();
            setSide(tree, sortSuffix, "", tree[0], text, text1.Length);
            return sortSuffix[0];
        }

        public int setSide(List<Node> tree, List<string> suffixes, string suffix, Node root, String text, int half)
        {
            if (!root.haveNeighbours)
            {
                root.side = root.start < half + 1 ? 1 : 0;
            }
            else
            {
                foreach (int neighbour in root.getNeighbours())
                {
                    root.side *= setSide(tree, suffixes, suffix + text.Substring(root.start, root.start + root.offset + 1), tree[neighbour], text, half);
                }
            }
            if (root.side == 1)
            {
                root.suffix = suffix;
                if (root.start < half)
                {
                    root.suffix += text[root.start];
                    if (suffixes.Count()==0 || suffixes[0].Length > root.suffix.Length)
                        suffixes.Add("0");
                    suffixes.Add(root.suffix);
                }
            }
            return root.side;
        }


        int LetterToIndex(char letter)
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
                case '#':
                    return 5;
                default:
                    return Node.NA;
            }
        }

        List<Node> textToTree(String text)
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
                while (currentNode.next[LetterToIndex(text[initialStart])] > 0)
                {
                    currentNode = tree[currentNode.next[LetterToIndex(text[initialStart])]];
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
                        Node newNodes = new Node(currentStart + removeIndex, currentOffset - removeIndex, count++);
                        newNodes.generalStart = currentNode.generalStart;
                        currentNode.start = initialStart;
                        currentNode.offset = removeIndex - 1;
                        tree.Add(newNodes);
                        if (currentNode.haveNeighbours)
                        {
                            Array.Copy(currentNode.next, newNodes.next, currentNode.next.Length);
                            newNodes.haveNeighbours = true;
                            currentNode.initNext();
                        }
                        currentNode.next[LetterToIndex(text[(newNodes.start)])] = newNodes.id;
                        currentNode.haveNeighbours = true;
                    }
                    initialStart += removeIndex;
                    initialOffset -= removeIndex;
                }
                Node newNode = new Node(initialStart, initialOffset, count++);
                newNode.generalStart = length - 1 - j;
                tree.Add(newNode);
                currentNode.next[LetterToIndex(text[initialStart])] = newNode.id;
                currentNode.haveNeighbours = true;
            }
            return tree;
        }
    }
}
