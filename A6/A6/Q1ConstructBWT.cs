using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class Q1ConstructBWT : Processor
    {
        //private IEnumerable<object> _matrix;

        public Q1ConstructBWT(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<String, String>)Solve);

        public string Solve(string text)
        {
            // write your code here
            //List<string> answer = new List<string>();
            //for (int i = 0; i < text.Length; i++)
            //{
            //    answer.Add(text.Substring(i));
            //}
            //answer.Sort();
            //return answer[text.Length - 1];
            //int index = 0;
            //char[][] matrix = new char[text.Length][];
            //for (int i = 0; i < text.Length; i++)
            //{
            //    matrix[i] = new List<char>().ToArray();
            //    for (int j = 0; j < text.Length; j++)
            //    {
            //        matrix[i][j] = text[j];
            //    }
            //}
            //Sort(matrix, 0);
            //return "hello";
            StringBuilder result = new StringBuilder();
            StringBuilder textBuilder = new StringBuilder(text);
            SortedSet<string> tree = new SortedSet<string>();
            int last = text.Length - 1;
            for (int i = 0; i < text.Length; i++)
            {
                tree.Add(textBuilder.ToString());
                char first = textBuilder[0];
                textBuilder.Remove(0, 1);
                textBuilder.Append(first);
            }
            tree.Reverse();
           // int count = 0;
            while (tree.Count >0)
            {
                //result.Append(tree.Skip(text.Length - 1));//.ElementAt(last));
                //result.Append(tree.Reverse().ElementAt(0));
                //result.Append(tree.First());
                result.Append(tree.First().ElementAt(last));
                tree.Remove(tree.First());
                //count++;
            }
            ////tree.ToArray();
            //var m = tree.Select(row => row[text.Length]);

            return result.ToString();
        }

        //private static void Sort(char[][] data, int col)
        //{
        //    Comparer<char> comparer = Comparer<char>.Default;
        //    Array.Sort<char[]>(data, (x, y) => comparer.Compare(x[col], y[col]));
        //}
    }
}
