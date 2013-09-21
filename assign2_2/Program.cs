using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using assign1_2;
using System.IO;

namespace assign2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs;
            try
            {
                fs = File.OpenRead(@".\data\clustering_big.txt");
                //fs = File.OpenRead(@".\data\test6.txt");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            StreamReader sr = new StreamReader(fs);
            string sTemp = sr.ReadLine();
            var config_parts = sTemp.Split();

            int nNodes = Int32.Parse(config_parts[0]);
            int nBits = Int32.Parse(config_parts[1]);

            Dictionary<int, int> nodes = new Dictionary<int, int>();
            UnionFind uf = new UnionFind(nNodes);

            string sEdge = sr.ReadLine();
            int duplicate = 0;
            int i = 0;
            while (!String.IsNullOrEmpty(sEdge))
            {
                string sValue = sEdge.Trim().Replace(" ", "").Substring(0, nBits);
                int z = Convert.ToInt32(sValue, 2);
                if (nodes.ContainsKey(z))
                {
                    duplicate++;
                    uf.Merge(i, nodes[z]);
                }
                else
                {
                    nodes.Add(z, i);
                }
                sEdge = sr.ReadLine();
                i++;
            }

           
            int clusters = nNodes - duplicate;

            foreach(var node in nodes)
            {
                    for (int j = 0; j < nBits; j++)
                    {
                        int neighbour = HammingDistanceCalculator.Flip(node.Key, j);   
                        for (int k = 0; k < nBits; k++)
                        {
                            int neighbour2 = 0;
                            if (k != j)
                            {
                                neighbour2 = HammingDistanceCalculator.Flip(neighbour, k);
                            }
                            else 
                            {
                                neighbour2 = neighbour;
                            }

                            if (nodes.ContainsKey(neighbour2) && (uf.GetRoot(node.Value) != uf.GetRoot(nodes[neighbour2])))
                            {
                                clusters--;
                                uf.Merge(node.Value, nodes[neighbour2]);
                            }
                        }
                    }

            }

            Console.WriteLine("NUmber of clusters is: " + clusters);
            Console.ReadLine();
           
        }
    }
}
