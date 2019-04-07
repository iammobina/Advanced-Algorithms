namespace A4
{
    public class Edge
    {
        public double weight;
        public Nodex[] points;
        public Edge(Nodex x,Nodex y, double weight)
        {

            points = new Nodex[] { x, y };
            this.weight = weight;
            
        }
    }
}