using System.Collections.Generic;

namespace A6
{
    public class Node
    {

        public static  int Letters = 5;
        public static int NA = -1;
        public int[] next;
        public int start;
        public int offset;
        public int generalStart;
        public int id;
        public bool haveNeighbours;

        public Node()
        {
            next = new int[Letters];
            //Arrays.fill(next, NA);
            for (int i=0;i<Letters;i++)
            {
                next[i] = NA;
            }
        }


        public Node(int start, int offset, int id)
        {
           
            this.start = start;
            this.offset = offset;
            this.id = id;
        }

        public void initNext()
        {
            //Arrays.fill(next, NA);
            for (int i = 0; i < Letters; i++)
            {
                next[i] = NA;
            }
            haveNeighbours = false;
        }

        public List<int> getNeighbours(int m)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < next.Length; i++)
            {
                if (next[i] > 0) result.Add(next[i]);
            }
            return result;
        }
    }
}
