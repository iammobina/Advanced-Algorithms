using System;
using System.Collections.Generic;

namespace A5
{
    public class Node
    {
        public int Letters = 4;
        public static int NA = -1;
        public int[] next;

        public Node()
        {
            next = new int[Letters];
            //List<long> a = new List<long>();
            //long[] array = new long[Letters];
            for (int i = 0; i < next.Length; i++)
            {
                next[i] = NA;
            }
        }

        public bool IsLeaf()
        {
            foreach (var i in  next)
            {
                if (i != NA) return false;
            }
            return true;
        }
    }
}