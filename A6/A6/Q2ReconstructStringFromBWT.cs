using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class Q2ReconstructStringFromBWT : Processor
    {
        public Q2ReconstructStringFromBWT(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) =>
        TestTools.Process(inStr, (Func<String, String>)Solve);

        public string Solve(string bwt)
        {
            // write your code here
            //StringBuilder result = new StringBuilder();
            //List<String> matrix = new List<string>();
            //List<int> indexes = new List<int>();
            //for (int i = 0; i < bwt.Length; i++)
            //{
            //    matrix.Add("" + bwt[i]);
            //    indexes.Add(i);
            //}
            //ICollection.sort(indexes, (o1, o2)->matrix.get(o1).compareTo(matrix.get(o2)));
            //int current = indexes.get(0);
            //for (int i = 0; i < bwt.length() - 1; i++)
            //{
            //    int index = indexes.indexOf(current);
            //    String next = String.valueOf(bwt.charAt(index));
            //    result.append(next);
            //    current = index;
            //}
            StringBuilder result = new StringBuilder();
            List<string> matrix = new List<string>();
            //string Answer = "";
            List<int> indexes = new List<int>();
            for (int i = 0; i < bwt.Length; i++)
            {
                matrix.Add("" + bwt[i]);
                indexes.Add(i);
            }
            indexes.Sort((o1, o2) => matrix[o1].CompareTo(matrix[o2]));
            int current = indexes[0];
            for (int i = 0; i < bwt.Length - 1; i++)
           // for (int i = bwt.Length - 1; i > 0; i--)
            {
                int index = indexes.IndexOf(current);
                string next = bwt[index].ToString();
                result.Append(next);
               // Answer+=String.Join("", next);
                current = index;
            }
            //for (int i = result.Length - 1; i >= 0; i--)
            //{
            //    Answer += result[i];
            //}

            //var answer = result.ToStrvar ing();
            //answer.Reverse();

            //char[] charArray = result.ToString().ToCharArray();
            //Array.Reverse(charArray);
            //string answer = new string(charArray);
            //  charArray += '$';

            //var m=Answer.Reverse();
            //m += "$";
            //// return result.ToString().Reverse() + "$";
            //return m.ToString();
            char[] arr = result.ToString().ToCharArray();
            Array.Reverse(arr);
            return new string(arr) + "$";
            // return answer + "$";
        }
//        public static void (this StringBuilder sb)
//{
//            char t;
//            int end = sb.Length - 1;
//            int start = 0;

//            while (end - start > 0)
//            {
//                t = sb[end];
//                sb[end] = sb[start];
//                sb[start] = t;
//                start++;
//                end--;
//            }
//        }
        }
}
