using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A4
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> data;

        public PriorityQueue()
        {
            this.data = new List<T>();
        }

        public void Enqueue(T item)
        {
            data.Add(item);
            int ci = data.Count - 1; // child index; start at end
            while (ci > 0)
            {
                int pi = (ci - 1) / 2; // parent index
                if (data[ci].CompareTo(data[pi]) >= 0) break; // child item is larger than (or equal) parent so we're done
                T tmp = data[ci]; data[ci] = data[pi]; data[pi] = tmp;
                ci = pi;
            }
        }

        public T Dequeue()
        {
            // assumes pq is not empty; up to calling code
            int li = data.Count - 1; // last index (before removal)
            T frontItem = data[0];   // fetch the front
            data[0] = data[li];
            data.RemoveAt(li);

            --li; // last index (after removal)
            int pi = 0; // parent index. start at front of pq
            while (true)
            {
                int ci = pi * 2 + 1; // left child index of parent
                if (ci > li) break;  // no children so done
                int rc = ci + 1;     // right child
                if (rc <= li && data[rc].CompareTo(data[ci]) < 0) // if there is a rc (ci + 1), and it is smaller than left child, use the rc instead
                    ci = rc;
                if (data[pi].CompareTo(data[ci]) <= 0) break; // parent is smaller than (or equal to) smallest child so done
                T tmp = data[pi]; data[pi] = data[ci]; data[ci] = tmp; // swap parent and child
                pi = ci;
            }
            return frontItem;
        }

        public T Peek()
        {
            T frontItem = data[0];
            return frontItem;
        }

        public int Count()
        {
            return data.Count;
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < data.Count; ++i)
                s += data[i].ToString() + " ";
            s += "count = " + data.Count;
            return s;
        }

        public bool IsConsistent()
        {
            // is the heap property true for all data?
            if (data.Count == 0) return true;
            int li = data.Count - 1; // last index
            for (int pi = 0; pi < data.Count; ++pi) // each parent index
            {
                int lci = 2 * pi + 1; // left child index
                int rci = 2 * pi + 2; // right child index

                if (lci <= li && data[pi].CompareTo(data[lci]) > 0) return false; // if lc exists and it's greater than parent then bad.
                if (rci <= li && data[pi].CompareTo(data[rci]) > 0) return false; // check the right child too.
            }
            return true; // passed all checks
        } // IsConsistent
    }

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

    //public class Edge : Comparer<Edge>
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

    //    public override int Compare(Edge e1, Edge e2)
    //    {
    //        return e1.weight < e2.weight ? -1 : 1;
    //    }

    //}


public class Q2Clustering : Processor
    {
        public Q2Clustering(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long, double>)Solve);


        public double Solve(long pointCount, long[][] points, long clusterCount)
        {
            //Write Your Code Here
            //long[] x = Getx(pointCount, points);
            //long[] y = Gety(pointCount, points);
            //List<double> weight = new List<double>();
            //int n = x.Length;
            //Node[] nodes = new Node[n];
            //for (int i = 0; i < n; i++)
            //{
            //    MakeSet(i, nodes, x, y);
            //}

            // Queue<Edge> edges = new Queue<Edge>();


            //for (int i = 0; i < n; i++)
            //{
            //    for (int j = i + 1; j < n; j++)
            //    {
            //        edges.Enqueue(new Edge(i, j, Weight(x[i], y[i], x[j], y[j])));
            //    }
            //}
            Nodex[] point = new Nodex[pointCount];

            for (int i = 0; i < pointCount; i++)
            {
                //var a =
                point[i] = new Nodex(Getx(pointCount, points)[i], Gety(pointCount, points)[i]);//points[i][0], points[i][1]);
            }
            long result = pointCount;
            List<Edge> edges = CreateSortingOrder(pointCount, point);


            //while (edges.Count() != 0)
            //{
            //    Edge currentEdge = edges.Dequeue();
            //    long u = currentEdge.u;
            //    long v = currentEdge.v;
            //    
            //    {
            //        result += currentEdge.weight;
            //        Union(u, v, nodes);
            //    }
            //}

            foreach (Edge e in edges)
            {
               // if (Find(u, nodes) != Find(v, nodes))
                if (Find(e.points[0]) != Find(e.points[1]))
                {
                    if (clusterCount == result)
                        return Math.Round(e.weight, 6);
                                result--;
                    Union(e.points[0], e.points[1]);
                }
            }
            return 0;

        }

        private List<Edge> CreateSortingOrder(long pointCount, Nodex[] point)
        {
            
            List<double> weights = new List<double>();

            List<Edge> edge = new List<Edge>();
            for (int i = 0; i < pointCount; i++)
                for (int j = i + 1; j < pointCount; j++)
                {
                    double distances = Weight(point[i], point[j]);
                    weights.Add(distances);
                    edge.Add(new Edge(point[i], point[j], distances));
                }

            //list.Sort((first, second) =>
            //{
            //    if (first != null && second != null)
            //        return first.date.CompareTo(second.date);

            //    if (first == null && second == null)
            //        return 0;

            //    if (first != null)
            //        return -1;

            //    return 1;
            //});

            Edge[] cpnvert = edge.ToArray();
            Array.Sort(weights.ToArray(), cpnvert);
            //  Array.Sort(weights.ToArray(), edge.ToArray());
            return cpnvert.ToList();
            
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
        //public static void MakeSet(int i, Node[] nodes, long[] x, long[] y)
        //{
        //    nodes[i] = new Node(x[i], y[i], i);
        //}
        public long compare(Edge e1, Edge e2)
        {
            return e1.weight < e2.weight ? -1 : 1;
        }

        public static double Weight(Nodex one, Nodex two)
        {
            return Math.Sqrt(((one.xy[0] - two.xy[0]) * (one.xy[0] - two.xy[0])) + ((one.xy[1] - two.xy[1]) * (one.xy[1] - two.xy[1])));
        }

        //public static long Find(long i, Node[] nodes)
        //{
        //    if (i != nodes[i].parent)
        //    {
        //        nodes[i].parent = Find(nodes[i].parent, nodes);
        //    }
        //    return nodes[i].parent;
        //}

        //private static void Union(long u, long v, Node[] nodes)
        //{
        //    long r1 = Find(u, nodes);
        //    long r2 = Find(v, nodes);
        //    if (r1 != r2)
        //    {
        //        if (nodes[r1].rank > nodes[r2].rank)
        //        {
        //            nodes[r2].parent = r1;
        //        }
        //        else
        //        {
        //            nodes[r1].parent = r2;
        //            if (nodes[r1].rank == nodes[r2].rank)
        //            {
        //                nodes[r2].rank++;
        //            }
        //        }
        //    }
        //}
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

        private static void Union(Nodex a, Nodex b)//long u, long v, Nodex nodes)
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