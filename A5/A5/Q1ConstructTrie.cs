using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A5
{
    public class Q1ConstructTrie : Processor
    {
        public Q1ConstructTrie(string testDataName) : base(testDataName)
        {
            this.VerifyResultWithoutOrder = true;
        }

        public override string Process(string inStr) =>
        TestTools.Process(inStr, (Func<long, String[], String[]>)Solve);

        public string[] Solve(long n, string[] patterns)
        {
            // write your code here
            List<Dictionary<char, int>> trie = new List<Dictionary<char, int>>();
            Dictionary<char, int> root = new Dictionary<char, int>();
            List<string> answer = new List<string>();
            trie.Add(root);
            foreach (string pattern in patterns)
            {
                Dictionary<char, int> currentNode = root;
                for (int i = 0; i < pattern.Count(); i++)
                {
                    char currentSymbol = pattern[i];
                    List<char> neighbours = currentNode.Keys.ToList();
                    if (neighbours != null && neighbours.Contains(currentSymbol))
                    {
                        currentNode = trie[currentNode[currentSymbol]];
                    }
                    else
                    {
                        Dictionary<char, int> newNode = new Dictionary<char, int>();
                        trie.Add(newNode);
                        currentNode.Add(currentSymbol, trie.Count() - 1);
                        currentNode = newNode;
                    }
                }
            }
            for (int i = 0; i < trie.Count(); ++i)
            {
                Dictionary<char, int> node = trie[i];
                foreach (KeyValuePair<char, int> entry in node)
                {
                    answer.Add(i + "->" + entry.Value + ":" + entry.Key);
                }
            }
            return answer.ToArray();
        }
    }
}
    
