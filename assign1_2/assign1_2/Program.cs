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
            FileStream fs;
            try
            {
                fs = File.OpenRead(@".\data\edges.txt");
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
            for (int i = 0; i < nEdges; i++)
            {
                string sEdge = sr.ReadLine();
                words = sEdge.Split();
                edges[i] = new Edge(i, Int32.Parse(words[0]), Int32.Parse(words[1]), Int32.Parse(words[2]));
            }

            edges = edges.OrderBy(edge => edge.Cost).ToArray();
            foreach (var edge in edges)
            { 
            
            }

        }
    }
}
