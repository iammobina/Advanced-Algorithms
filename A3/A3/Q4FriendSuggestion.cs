using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A3
{
    //public class Node : IComparable<Node> 
    //{
    //    public double distances;
    //    public int x;
    //    public int y;

    //    public Node(double distance, int x, int y)
    //    {
    //        this.distances = distance;
    //        this.x = x;
    //        this.y = y;
    //    }

    //    public double getDistance()
    //    {
    //        return distances;
    //    }

    //    public int getX()
    //    {
    //        return x;
    //    }

    //    public int getY()
    //    {
    //        return y;
    //    }

    //    public int CompareTo(Node other)
    //    {
    //        if (this.getDistance() > other.getDistance()) return 1;
    //        else if (this.getDistance() < other.getDistance()) return -1;
    //        else return 0;
    //    }
    //}

    //}

    public class PriorityQueue
    {
        public void swap(Vertex[] graph, int[] priorityQ, int index1, int index2)
        {
            int temp = priorityQ[index1];

            priorityQ[index1] = priorityQ[index2];
            graph[priorityQ[index2]].queuePos = index1;

            priorityQ[index2] = temp;
            graph[temp].queuePos = index2;
        }
        public void makeQueue(Vertex[] graph, int[] forwpriorityQ, int source, int target)
        {
            swap(graph, forwpriorityQ, 0, source);
        }
        public int extractMin(Vertex[] graph, int[] priorityQ, int extractNum)
        {
            int vertex = priorityQ[0];
            int size = priorityQ.Length - 1 - extractNum;
            swap(graph, priorityQ, 0, size);
            siftDown(0, graph, priorityQ, size);
            return vertex;
        }
        public void siftDown(int index, Vertex[] graph, int[] priorityQ, int size)
        {
            int min = index;
            if (2 * index + 1 < size && graph[priorityQ[index]].dist > graph[priorityQ[2 * index + 1]].dist)
            {
                min = 2 * index + 1;
            }
            if (2 * index + 2 < size && graph[priorityQ[min]].dist > graph[priorityQ[2 * index + 2]].dist)
            {
                min = 2 * index + 2;
            }
            if (min != index)
            {
                swap(graph, priorityQ, min, index);
                siftDown(min, graph, priorityQ, size);
            }
        }
        public void changePriority(Vertex[] graph, int[] priorityQ, int index)
        {
            if ((index - 1) / 2 > -1 && graph[priorityQ[index]].dist < graph[priorityQ[(index - 1) / 2]].dist)
            {
                swap(graph, priorityQ, index, (index - 1) / 2);
                changePriority(graph, priorityQ, (index - 1) / 2);
            }
        }
    }

    public class Vertex
    {
        public int vertexNum;
        public List<long> adjList;
        public List<long> costList;

        public int queuePos;
        public long dist;
        public bool processed;

        public Vertex()
        {
        }


        //Vertex Constructor.
        public Vertex(int vertexNum)
        {
            this.vertexNum = vertexNum;
            this.adjList = new List<long>();
            this.costList = new List<long>();
        }

        internal void createGraph(Vertex[] graph, Vertex[] reverseGraph, int[] forwPriorityQ, int[] revPriorityQ)
        {
            for (int i = 0; i < graph.Length; i++)
            {
                graph[i].queuePos = i;
                graph[i].processed = false;
                graph[i].dist = int.MaxValue;

                reverseGraph[i].queuePos = i;
                reverseGraph[i].processed = false;
                reverseGraph[i].dist = int.MaxValue;

                forwPriorityQ[i] = i;
                revPriorityQ[i] = i;
            }
        }
    }
    public class Q4FriendSuggestion : Processor
    {
        public static List<long> Answer = new List<long>();
        public Q4FriendSuggestion(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long[][], long, long[][], long[]>)Solve);

        public long[] Solve(long NodeCount, long EdgeCount,
                              long[][] edges, long QueriesCount,
                              long[][] Queries)
        {
            List<long>[] Graph = LoadGraph(NodeCount, edges);
            List<long>[] Weight = LoadWeight(NodeCount, edges);
            List<long>[] ReverseGraph = LoadReverseGraph(NodeCount, edges);
            long[] Distance = new long[NodeCount + 1];
            long[] ReverseDistance = new long[NodeCount + 1];
            for (int i = 0; i < Distance.Length; i++)
            {
                Distance[i] = 60000;
                ReverseDistance[i] = 60000;
            }
            Distance[0] = 0;
            ReverseDistance[0] = 0;
            //  PriorityQueue<Node> q = new PriorityQueue<>();


        }



        public static List<long>[] ProccessQuery(long quercount, long[][] queryE)
        {
            List<long>[] query = new List<long>[quercount + 1];
            for (int i = 0; i < query.Length; i++)
            {
                query[i] = new List<long>();
            }
            foreach (var vertex in queryE)
            {
                //vertex 0 mishe node s
                //vertex 1 mishe target
                query[vertex[0]].Add(vertex[1]);
            }
            return query;
        }

        public static List<long>[] LoadGraph(long nodeCount, long[][] edges)
        {
            List<long>[] Graph = new List<long>[nodeCount + 1];
            for (int i = 0; i < Graph.Length; i++)
            {
                Graph[i] = new List<long>();
            }
            foreach (var vertex in edges)
            {
                Graph[vertex[0]].Add(vertex[1]);
            }
            return Graph;
        }

        public static List<long>[] LoadWeight(long nodeCount, long[][] edges)
        {
            List<long>[] Weight = new List<long>[nodeCount + 1];
            for (int i = 0; i < Weight.Length; i++)
            {
                Weight[i] = new List<long>();
            }
            foreach (var vertex in edges)
            {
                Weight[vertex[0]].Add(vertex[2]);

            }
            return Weight;
        }

        public static List<long>[] LoadReverseGraph(long nodeCount, long[][] edges)
        {
            List<long>[] ReverseGraph = new List<long>[nodeCount + 1];
            for (int i = 0; i < ReverseGraph.Length; i++)
            {
                ReverseGraph[i] = new List<long>();
            }
            foreach (var vertex in edges)
            {
                ReverseGraph[vertex[1]].Add(vertex[0]);
            }
            return ReverseGraph;
        }

        public static double Computedistance(int[] x, int[] y)
        {
            return Math.Sqrt(Math.Pow(x[1] - x[0], 2) + Math.Pow(y[1] - y[0], 2));
        }

       

        private static void relaxEdges(Vertex[] graph, int vertex, int[] priorityQ, PriorityQueue queue, int queryId)
        {
            List<long> vertexList = graph[vertex].adjList;
            List<long> costList = graph[vertex].costList;
            graph[vertex].processed = true;

            for (int i = 0; i < vertexList.Count(); i++)
            {
                long temp = vertexList[i];
                long cost = costList[i];

                if (graph[temp].dist > graph[vertex].dist + cost)
                {
                    graph[temp].dist = graph[vertex].dist + cost;
                    queue.changePriority(graph, priorityQ, graph[temp].queuePos);
                }
            }
        }

        public static long computeDistance(Vertex[] graph, Vertex[] reverseGraph, int s, int t, int queryId)
        {
            //List<long> answer = new List<long>();

            //create two PriorityQueues forwQ for forward graph and revQ for reverse graph. 
            PriorityQueue queue = new PriorityQueue();
            int[] forwPriorityQ = new int[graph.Length];  //for forward propagation.
            int[] revPriorityQ = new int[graph.Length];   //for reverse propagation.

            //create graph.
            Vertex vertex = new Vertex();
            vertex.createGraph(graph, reverseGraph, forwPriorityQ, revPriorityQ);

            //dist of s from s is 0.
            //in rev graph dist of t from t is 0.
            graph[s].dist = 0;
            reverseGraph[t].dist = 0;
            queue.makeQueue(graph, forwPriorityQ, s, t);
            queue.makeQueue(reverseGraph, revPriorityQ, t, s);

            //store the processed vertices while traversing.
            List<int> forgraphprocessedVertices = new List<int>();  //for forward propagation.
            List<int> revgraphprocessedVertices = new List<int>();  //for reverse propagation.


            for (int i = 0; i < graph.Length; i++)
            {

                //extract the vertex with min dist from forwQ.
                int vertex1 = queue.extractMin(graph, forwPriorityQ, i);
                if (graph[vertex1].dist == int.MaxValue)
                {
                    continue;
                }

                //relax the edges of the extracted vertex.
                relaxEdges(graph, vertex1, forwPriorityQ, queue, queryId);

                //store into the processed vertices list.
                forgraphprocessedVertices.Add(vertex1);

                //check if extratced vertex also processed in the reverse graph. If yes find the shortest distance.
                if (reverseGraph[vertex1].processed)
                {
                    return shortestPath(graph, reverseGraph, forgraphprocessedVertices, revgraphprocessedVertices, queryId);
                }


                //extract the vertex with min dist from revQ.
                int revVertex = queue.extractMin(reverseGraph, revPriorityQ, i);
                if (reverseGraph[revVertex].dist == int.MaxValue)
                {
                    continue;
                }

                //relax the edges of the extracted vertex.
                relaxEdges(reverseGraph, revVertex, revPriorityQ, queue, queryId);

                //store in the processed vertices list of reverse graph.
                revgraphprocessedVertices.Add(revVertex);

                //check if extracted vertex is also processed in the forward graph. If yes find the shortest distance.
                if (graph[revVertex].processed)
                {
                    return shortestPath(graph, reverseGraph, forgraphprocessedVertices, revgraphprocessedVertices, queryId);
                }

            }

            //if no path between s and t.
            return -1;
        }
        private static long shortestPath(Vertex[] graph, Vertex[] reverseGraph, List<int> forgraphprocessedVertices, List<int> revgraphprocessedVertices, int queryId)
        {
            long distance = int.MaxValue;

            //process the forward list.
            for (int i = 0; i < forgraphprocessedVertices.Count(); i++)
            {
                int vertex = forgraphprocessedVertices[i];
                if (reverseGraph[vertex].dist + graph[vertex].dist >= int.MaxValue)
                {
                    continue;
                }
                long tempdist = graph[vertex].dist + reverseGraph[vertex].dist;
                if (distance > tempdist)
                {
                    distance = tempdist;
                }
            }

            //process the reverse list.
            for (int i = 0; i < revgraphprocessedVertices.Count(); i++)
            {
                int vertex = revgraphprocessedVertices[i];
                if (reverseGraph[vertex].dist + graph[vertex].dist >= int.MaxValue)
                {
                    continue;
                }
                long tempdist = reverseGraph[vertex].dist + graph[vertex].dist;
                if (distance > tempdist)
                {
                    distance = tempdist;
                }

            }
            return distance;
        }

    }
}
