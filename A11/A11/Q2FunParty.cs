using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A11
{
    public class Vertex
    {
        public long maxFun;
        public long weight;
        public List<long> children;
        public Vertex()
        {
            this.weight = 0;
            this.children = new List<long>();
        }
    }

    public class Q2FunParty : Processor
    {
        public Q2FunParty(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[][], long>)Solve);

        public virtual long Solve(long n, long[] funFactors, long[][] hierarchy)
        {

            Vertex[] tree = loadTree(n,hierarchy,funFactors);
            long weight = MaxWeightIndependentTreeSubset(tree);
            return weight;
        }

        public static void dfs(Vertex[] tree, int vertex, int parent)
        {
            foreach (int child in tree[vertex].children)
            {
                if (child != parent)
                    dfs(tree, child, vertex);
            }
            long maxFun1 = tree[vertex].weight;
            long maxFun2 = 0;
            foreach (int child in tree[vertex].children)
            {
                if (child != parent)
                {
                    maxFun2 += tree[child].maxFun;
                    foreach (int grandchild in tree[child].children)
                    {
                        if (grandchild != child && grandchild != parent)
                        {
                            maxFun1 += tree[grandchild].maxFun;
                        }
                    }
                }
            }
            tree[vertex].maxFun = Math.Max(maxFun1, maxFun2);
        }

        public static long MaxWeightIndependentTreeSubset(Vertex[] tree)
        {
            long size = tree.Length;
            if (size == 0)
                return 0;
            dfs(tree, 0, -1);
            return tree[0].maxFun;
        }

        public static Vertex[] loadTree(long n, long[][] hierachy, long[] factor)
        {
            long vertices_count = n;

            Vertex[] tree = new Vertex[vertices_count];

            for (int i = 0; i < vertices_count; ++i)
            {
                tree[i] = new Vertex();
                tree[i].weight = factor[i];
            }

            for (int i = 1; i < vertices_count; ++i)
            {
                long from = hierachy[i][0];
                long to = hierachy[0][i];
                tree[from - 1].children.Add(to - 1);
                tree[to - 1].children.Add(from - 1);
            }

            return tree;
        }

    }
}
   
