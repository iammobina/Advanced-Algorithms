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
    public class PriorityQueue
    {
        int MaxSize;

        public PriorityQueue(int Key, int Index)
        {

        }
    }
    public class Node
    {
        long x;
        long y;
        public long parent;
        public long rank;

        public Node(long a, long b, long c)
        {
            x = a;
            y = b;
            parent = c;
            rank = 0;
        }
    }

    public class Edge
    {
        public long u;
        public long v;
       public double weight;

        public Edge(long a, long b, double c)
        {
            u = a;
            v = b;
            weight = c;
        }
    }


    public class Q1BuildingRoads : Processor
    {
        public Q1BuildingRoads(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
           TestTools.Process(inStr, (Func<long, long[][], double>)Solve);

        public double Solve(long pointCount, long[][] points)
        {
            //Write Your Code Here
            long[] x = Getx(pointCount, points);
            long[] y = Gety(pointCount, points);
            double result = 0.0;
            int n = x.Length;
            Node[] nodes = new Node[n];
            for (int i = 0; i < n; i++)
            {
                MakeSet(i, nodes, x, y);
            }
            PriorityQueue<Edge> edges = new PriorityQueue<>(new Comparator<Edge>());

            for (int i = 0; i < n; i++) {
                for (int j = i + 1; j < n; j++) {
                    edges.offer(new Edge(i, j, Weight(x[i], y[i], x[j], y[j])));
                }
            }
            while (!edges.isEmpty()) {
                Edge currentEdge = edges.poll();
                long u = currentEdge.u;
                long v = currentEdge.v;
                if (Find(u, nodes) != Find(v, nodes)) {
                    result += currentEdge.weight;
                    Union(u, v, nodes);
                }
            }
            return result;
        }

        private long[] Gety(long pointCount, long[][] points)
        {
            long[] GetY = new long[count + 1];
            for (int i = 0; i < count; i++)
            {
                GetY[i] = edges[0][i];
            }
            return GetY;
        }

        public static long[] Getx(long count, long[][] edges)
        {
            long[] GetX = new long[count + 1];
            for (int i = 0; i < count; i++)
            {
                GetX[i] = edges[0][i];
            }
            return GetX;
        }

        public static void MakeSet(int i, Node[] nodes, long[] x, long[] y)
        {
            nodes[i] = new Node(x[i], y[i], i);
        }
        public long compare(Edge e1, Edge e2)
        {
            return e1.weight < e2.weight ? -1 : 1;
        }

        public static double Weight(long x1, long y1, long x2, long y2)
        {
            return Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }

        public static long Find(long i, Node[] nodes)
        {
            if (i != nodes[i].parent)
            {
                nodes[i].parent = Find(nodes[i].parent, nodes);
            }
            return nodes[i].parent;
        }

        private static void Union(long u, long v, Node[] nodes)
        {
            long r1 = Find(u, nodes);
            long r2 = Find(v, nodes);
            if (r1 != r2)
            {
                if (nodes[r1].rank > nodes[r2].rank)
                {
                    nodes[r2].parent = r1;
                }
                else
                {
                    nodes[r1].parent = r2;
                    if (nodes[r1].rank == nodes[r2].rank)
                    {
                        nodes[r2].rank++;
                    }
                }
            }
        }
    }
}
