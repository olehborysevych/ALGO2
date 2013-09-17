using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using assign1_2;
using System.IO;

namespace assign2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int nEdges = 0;
            int nNodes;
            const int nClusters = 4;

            List<Edge> edges = new List<Edge>();
            bool[] nodes;
            FileStream fs;
            try
            {
                fs = File.OpenRead(@".\data\clustering1.txt");
                //fs = File.OpenRead(@".\data\test1.txt");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            StreamReader sr = new StreamReader(fs);
            string sTemp = sr.ReadLine();
            nNodes = Int32.Parse(sTemp);
            nEdges = nNodes*nNodes;

            nodes = new bool[nNodes];

            UnionFind uf = new UnionFind(nNodes);

            string sEdge = sr.ReadLine();
            int i = 0;
            while (!String.IsNullOrEmpty(sEdge))
            {
                var words = sEdge.Split();
                edges.Add(new Edge(i++, Int32.Parse(words[0]) - 1, Int32.Parse(words[1]) - 1, Int32.Parse(words[2])));
                sEdge = sr.ReadLine();
            }

            edges = edges.OrderBy(edge => edge.Cost).ToList();

            HashSet<int> visitedNodes = new HashSet<int>();
            List<Edge> mstEdges = new List<Edge>();
            //int nTotalCost = 0;

            foreach (var edge in edges)
            {
                //bool node1Taken = visitedNodes.Contains(edge.Node1);
                //bool node2Taken = visitedNodes.Contains(edge.Node2);
                //if (!(node1Taken && node2Taken))
                if (uf.GetRoot(edge.Node1) != uf.GetRoot(edge.Node2))
                {
                    uf.Merge(edge.Node1, edge.Node2);
                    visitedNodes.Add(edge.Node1);
                    visitedNodes.Add(edge.Node2);
                    mstEdges.Add(edge);
                    //nTotalCost += edge.Cost;
                }

                if (mstEdges.Count == nNodes - 1)
                    break;

            }

            //Console.WriteLine("MST Cost is (Weight/Length) = " + nTotalCost.ToString());
        }
    }
}
