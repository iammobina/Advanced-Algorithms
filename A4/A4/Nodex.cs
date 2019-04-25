namespace A4
{
    public class Nodex
    {
        public long v1;
        public long v2;
        public double[] xy = new double[2];
        public Nodex parent;
        public int rank;

        public Nodex(long v1, long v2)
        {
            xy = new double[] { v1, v2 };
            parent = this;
            rank = 1;
        }
    }
}