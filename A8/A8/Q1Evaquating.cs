using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A8
{


    public class Edge
    {
        public int from, to, capacity, flow;

        public Edge(int from, int to, int capacity)
        {
            this.from = from;
            this.to = to;
            this.capacity = capacity;
            this.flow = 0;
        }
    }

    public class FlowGraph
    {
        public List<Edge> edges;
        public List<int>[] graph;

        public FlowGraph(int n,long[][] edges)
        {
            this.graph = new List<int>[n];
            for (int i = 0; i < graph.Length; i++)
                this.graph[i] = new List<int>();
            this.edges = new List<Edge>();
            
        }


        public int Size()
        {
            return graph.Length;
        }

        public List<int> GetIds(int from)
        {
            //List<int> anser = new List<int>();
            //foreach (var i in graph[from])
            //{
            //    anser.Add(i);
            //}
            //return anser  ;
            return graph[from];
        }

        public Edge GetEdge(int id)
        {
            return edges[id];
        }

        public void AddEdge(int from, int to, int capacity)
        {
            Edge forwardEdge = new Edge(from, to, capacity);
            Edge backwardEdge = new Edge(to, from, 0);
            graph[from].Add(edges.Count);
            edges.Add(forwardEdge);
            graph[to].Add(edges.Count);
            edges.Add(backwardEdge);
        }

        public void AddFlow(int id, int flow)
        {
            edges[id].flow += flow;
            edges[id ^ 1].flow -= flow;
        }
    }

    public class Q1Evaquating : Processor
    {
        public Q1Evaquating(string testDataName) : base(testDataName)
        {
            //this.ExcludeTestCaseRangeInclusive(1, 1);
            //this.ExcludeTestCaseRangeInclusive(11, 100);
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long[][], long>)Solve);

        public virtual long Solve(long nodeCount, long edgeCount, long[][] edges)
        {


           FlowGraph graph = ReadGraph(nodeCount,edgeCount,edges);
           return (MaxFlow(graph, 1, graph.Size() - 1));


        }

        public static FlowGraph ReadGraph(long nodecount,long edgeCount, long[][] edges)
        {

            FlowGraph graph = new FlowGraph((int)nodecount+1,edges);
            
            for (int i = 0; i < edgeCount; i++)
            {
                int from = (int)edges[i][0];
                int to = (int)edges[i][1];
                int capacity = (int)edges[i][2];
                graph.AddEdge(from, to, capacity);
            }
            return graph;

        }

        private static int MaxFlow(FlowGraph graph, int from, int to)
        {
            int flow = 0;
            bool existAugmentingPath = true;
            while (existAugmentingPath)
            {
                //Dictionary<int, int> prev =bfs(graph, from, to);
                //if (prev[to] == null)
                //    break;
                existAugmentingPath = RecalculateFlow(graph, to, Bfs(graph, from, to));//prev);
            }

            foreach (int edge in graph.GetIds(from))
            {
                Edge current = graph.GetEdge(edge);
                if (current.capacity > 0)
                {
                    flow += current.flow;
                }
            }
            return flow;
        }


        private static /*KeyValuePair<int,int>*/ Dictionary<int, int> /*List<KeyValuePair<int, int>>*/ Bfs(FlowGraph graph, int from, int to)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(from);
            bool[] visited = new bool[graph.Size()];
            //Tuple<int, int> prev=new Tuple<int, int>;
            //Tuple.Create(prev)

            //List<KeyValuePair<int, int>> prev = new List<KeyValuePair<int, int>>();
            Dictionary<int, int> prev = new Dictionary<int, int>();

            //KeyValuePair<int, int> prev = new KeyValuePair<int, int>();

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                visited[current] = true;
                //graph.GetIds(current);

                foreach (var edgeId in graph.GetIds(current))
                {

                    Edge edge = graph.GetEdge(edgeId);
                    if (!visited[edge.to] && edge.capacity > edge.flow)
                    {
                        //if(prev.Key == edge.to)
                        //{
                        //    prev.Value=current;
                        //}
                        //prev.Key(edge.to) = current;
                        prev[edge.to] = current;
                      //  if(prev.ContainsKey())
                        //if(!prev.ContainsKey(edge.to))
                       // prev = new Tuple<int, int>(edge.to, current);
                        //prev.Add(new KeyValuePair<int, int> (edge.to, current));

                        queue.Enqueue(edge.to);
                        if (edge.to == to)
                            break;
                    }
                }
            }
            return prev;
        }
        private static bool RecalculateFlow(FlowGraph graph, int to, Dictionary<int,int> prev)//List<KeyValuePair<int, int>> prev)
        {
            int current = to;
            int minCap = int.MaxValue;
            List<int> path = new List<int>();
            int previous = int.MaxValue;
            while (prev.ContainsKey(current))//prev.Exists(kvp =>kvp.Key ==current))
            {
                //if(prev.ContainsKey(current))
                //{
                //previous =prev.FirstOrDefault(k =>k.Key == current).Key;
                previous = prev[current];
                //m = ;
                List<int> edges = graph.GetIds(previous);
                foreach (int edgeId in edges)
                {
                    Edge edge = graph.GetEdge(edgeId);
                    if (edge.to == current && edge.from == previous && edge.capacity > edge.flow)
                    {
                        path.Insert(0,edgeId);//(0, edgeId);
                        minCap = Math.Min(minCap, edge.capacity - edge.flow);
                        break;
                    }
                }
                current = previous;
                if (previous == 0) break;
            }

            foreach(int edge in path)
            {
                graph.AddFlow(edge, minCap);
            }
            return (minCap < int.MaxValue && minCap > 0);
        }

    }
}
