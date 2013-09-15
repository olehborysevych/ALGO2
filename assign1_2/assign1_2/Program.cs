using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int nEdges = 0;
            int nNodes;
            Edge[] edges;
            bool[] nodes;
            FileStream fs;
            try
            {
                fs = File.OpenRead(@".\data\test1.txt");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            StreamReader sr = new StreamReader(fs);
            string sTemp = sr.ReadLine();
            var words = sTemp.Split();
            nNodes = Int32.Parse(words[0]);
            nEdges = Int32.Parse(words[1]);
            edges = new Edge[nEdges];
            nodes = new bool[nNodes];
            
            for (int i = 0; i < nEdges; i++)
            {
                string sEdge = sr.ReadLine();
                words = sEdge.Split();
                edges[i] = new Edge(i, Int32.Parse(words[0]), Int32.Parse(words[1]), Int32.Parse(words[2]));
            }

            edges = edges.OrderBy(edge => edge.Cost).ToArray();

            HashSet<int> visitedNodes = new HashSet<int>();
            List<Edge> mstEdges = new List<Edge>();
            int nTotalCost = 0;
            foreach (var edge in edges)
            {
                bool node1Taken = visitedNodes.Contains(edge.Node1);
                bool node2Taken = visitedNodes.Contains(edge.Node2);
                if (!(node1Taken && node2Taken))
                {
                    visitedNodes.Add(edge.Node1);
                    visitedNodes.Add(edge.Node2);
                    mstEdges.Add(edge);
                    nTotalCost += edge.Cost;
                }
                if (mstEdges.Count == nNodes-1)
                    break;
            }

            Console.WriteLine("MST Cost is (Weight/Length) = " + nTotalCost.ToString());
        }
    }
}
