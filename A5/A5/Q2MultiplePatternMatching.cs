using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestCommon;

namespace A5
{

    public class Q2MultiplePatternMatching : Processor
    {
        public Q2MultiplePatternMatching(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
        TestTools.Process(inStr, (Func<String, long, String[], long[]>)Solve);

        public long[] Solve(string text, long n, string[] patterns)
        {
            // write your code here
            List<long> result = new List<long>();
            List<Node> trie = patternsToTrie(patterns);
            int count = 0;
            int kp = 0;
            while (text.Count() != 0)
            {
                kp++;
                int match = prefixTrieMatching(count++, text, trie);
                if (match != -1)
                {
                    result.Add(match);
                }
                text = text.Substring(1);
            }
           if (result.Count ==0)
            {
                result.Add(-1);
            }
            return result.ToArray();
        }

        private int prefixTrieMatching(int rem, string text, List<Node> trie)
        {
            char currentSymbol = text[0];
            Node currentNode = trie[0];
            int indexCurrentChar = 0;
            while (true)
            {
                if (currentNode.IsLeaf())
                {
                    return rem;
                }
                else if (currentNode.next[letterToIndex(currentSymbol)] != Node.NA)
                {
                    currentNode = trie[currentNode.next[letterToIndex(currentSymbol)]];
                    if (indexCurrentChar + 1 < text.Length)
                    {
                        currentSymbol = text[++indexCurrentChar];
                    }
                    else
                    {
                        if (currentNode.IsLeaf())
                        {
                            return rem;
                        }
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            return -1;
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
                    return -1;
            }
        }

        private List<Node> patternsToTrie(string[] patterns)
        {
            List<Node> trie = new List<Node>();
            trie.Add(new Node());

            foreach (string pattern in patterns)
            {
                Node currentNode = trie[0];
                for (int i = 0; i < pattern.Length; i++)
                {
                    char currentSymbol = pattern[i];
                    int index = currentNode.next[letterToIndex(currentSymbol)];

                    if (index != Node.NA)
                    {
                        currentNode = trie[index];
                    }
                    else
                    {
                        Node newNode = new Node();
                        trie.Add(newNode);
                        currentNode.next[letterToIndex(currentSymbol)] = trie.Count() - 1;
                        currentNode = newNode;
                    }

                }
            }
            return trie;
        }
    }
}
