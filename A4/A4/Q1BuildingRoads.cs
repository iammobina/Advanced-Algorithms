using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C5;
using ConcurrentPriorityQueue;
using TestCommon;

namespace A4
{
    //public class PriorityQueue
    //{
    //    int MaxSize;

    //    public PriorityQueue(int Key, int Index)
    //    {

    //    }
    //}
    //public class Node
    //{
    //    long x;
    //    long y;
    //    public long parent;
    //    public long rank;

    //    public Node(long a, long b, long c)
    //    {
    //        x = a;
    //        y = b;
    //        parent = c;
    //        rank = 0;
    //    }
    //}

    //public class Edge
    //{
    //    public long u;
    //    public long v;
    //    public double weight;

    //    public Edge(long a, long b, double c)
    //    {
    //        u = a;
    //        v = b;
    //        weight = c;
    //    }
    //}


    public class Q1BuildingRoads : Processor
    {
        public Q1BuildingRoads(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
           TestTools.Process(inStr, (Func<long, long[][], double>)Solve);

        public double Solve(long pointCount, long[][] points)
        {
            //Write Your Code Here
            //long[] x = Getx(pointCount, points);
            //long[] y = Gety(pointCount, points);
            double result = 0;
          //  int n = x.Length;
           // Node[] nodes = new Node[n];
            //for (int i = 0; i < n; i++)
            //{
            //    MakeSet(i, nodes, x, y);
            //}

            Nodex[] point = new Nodex[pointCount];

            for (int i = 0; i < pointCount; i++)
            {
                //var a =
                point[i] = new Nodex(Getx(pointCount,points)[i],Gety(pointCount, points)[i]);//points[i][0], points[i][1]);
            }

            List<Edge> edges = CreateDesendingOrder(pointCount, point);

            //while (edges.Count() !=0) {
            //    Edge currentEdge = edges.poll();
            //    long u = currentEdge.u;
            //    long v = currentEdge.v;
            //    if (Find(u, nodes) != Find(v, nodes)) {
            //        result += currentEdge.weight;
            //        Union(u, v, nodes);
            //    }
            //}
            foreach (Edge e in edges)
            {
                if (Find(e.points[0]) != Find(e.points[1]))
                {
                    result += e.weight;
                    Union(e.points[0], e.points[1]);
                }
            }
            return Math.Round(result, 6);

            // Queue<Edge> edges = new Queue<Edge>();//(new Comparator<Edge>());

            //for (int i = 0; i < n; i++) {
            //    for (int j = i + 1; j < n; j++) {
            //        edges.offer(new Edge(i, j, Weight(x[i], y[i], x[j], y[j])));
            //    }
            //}

           // return result;
        }

        private long[] Gety(long count, long[][] points)
        {
            long[] GetY = new long[count + 1];
            for (int i = 0; i < points.Length; i++)
            {
                GetY[i] = points[i][1];
            }
            return GetY;
        }

        public static long[] Getx(long count, long[][] edges)
        {
            long[] GetX = new long[count + 1];
            for (int i = 0; i < edges.Length; i++)
            {
                GetX[i] = edges[i][0];
            }
            return GetX;
        }
        //public static long[] Gety(int k,long count, long[][] points)
        //{
        //    long GetY = 0;/*new long[count + 1];*/
        //    for (int i = k; i < points.Length; i++)
        //    {
        //        GetY = points[i][1];
        //    }
        //    return GetY;
        //}

        //public static long Getx(int k,long count, long[][] edges)
        //{
        //    long GetX = 0;//new long[count + 1];
        //    for (int i = k; i < edges.Length; i++)
        //    {
        //        GetX = edges[i][0];
        //    }
        //    return GetX;
        //}
        //public static void MakeSet(int i, Node[] nodes, long[] x, long[] y)
        //{
        //    nodes[i] = new Node(x[i], y[i], i);

        //}
        //public long compare(Edge e1, Edge e2)
        //{
        //    return e1.weight < e2.weight ? -1 : 1;
        //}


        private List<Edge> CreateDesendingOrder(long pointCount, Nodex[] point)
        {
            List<Edge> edge = new List<Edge>();
            for (int i = 0; i < pointCount; i++)
                for (int j = i + 1; j < pointCount; j++)
                {
                    double distances = Weight(point[i], point[j]);
                    edge.Add(new Edge(point[i], point[j], distances));
                }
            return edge.OrderBy(x => x.weight).ToList();
        }


        public static double Weight(Nodex one,Nodex two)
        {
          
           return Math.Sqrt(((one.xy[0] -two.xy[0])* (one.xy[0] - two.xy[0])) + ((one.xy[1] - two.xy[1]) * (one.xy[1] - two.xy[1])));
        }

        public static Nodex Find(Nodex nodes)//long i, Node[] nodes)
        {
            //   if (i != nodes[i].parent)
            //    {
            //        nodes[i].parent = Find(nodes[i].parent, nodes);
            //    }
            //    return nodes[i].parent;
            while (nodes != nodes.parent)
                nodes = nodes.parent;
            return nodes;
            //if (nodes != nodes.parent)
            //    nodes = nodes.parent;
            //return nodes;
        }

        private static void Union(Nodex a,Nodex b)//long u, long v, Nodex nodes)
        {
            //long r1 = Find(nodes);
            //long r2 = Find(nodes);
            //if (r1 != r2)
            //{
            //    if (nodes[r1].rank > nodes[r2].rank)
            //    {
            //        nodes[r2].parent = r1;
            //    }
            //    else
            //    {
            //        nodes[r1].parent = r2;
            //        if (nodes[r1].rank == nodes[r2].rank)
            //        {
            //            nodes[r2].rank++;
            //        }
            //    }
            //}
            Nodex r1 = Find(a);
            Nodex r2 = Find(b);
            if (r1.rank > r2.rank)
            {
                r2.parent = r1;
            }
               
            else if (r1.rank < r2.rank)
            {
                r1.parent = r2;
            }
                
            else
            {
                r2.parent = r1;
                r1.rank++;
            }
        }
    }
}
