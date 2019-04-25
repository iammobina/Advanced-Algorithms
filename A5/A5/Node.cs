using System;
using System.Collections.Generic;

namespace A5
{
    public class Node
    {
        public int Letters = 6;
        public static int NA = -1;
        public bool patternEnd;
        public int[] next;
        public List<int> nextt;
        public int start;
        public int offset;
        public int generalStart;
        public int side = 1;
        public string suffix = "";
        public int id;
        public bool haveNeighbours;


        public Node()
        {
            next = new int[Letters];
            //List<long> a = new List<long>();
            //long[] array = new long[Letters];
            for (int i = 0; i < next.Length; i++)
            {
                next[i] = NA;
            }
            patternEnd = false;
        }

       public Node(int start, int offset, int id)
        {
            this.start = start;
            this.offset = offset;
            this.id = id;

        }

        public bool IsLeaf()
        {
            foreach (var i in  next)
            {
                if (i != NA) return false;
            }
            return true;
        }

        public bool isPatternEnd()
        {
            return patternEnd;
        }

        public void initNext()
        {
            for (int i = 0; i < next.Length; i++)
            {
                next[i] = NA;
            }
            haveNeighbours = false;
        }

        public List<int> getNeighbours()
        {
            List<int> result = new List<int>();
            foreach (int aNext in next)
            {
                if (aNext > 0) result.Add(aNext);
            }
            return result;
        }
    }
}