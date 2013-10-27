using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign4
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs;
            try
            {
                fs = File.OpenRead(@".\data\g3.txt");
                //fs = File.OpenRead(@".\data\test1.txt");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            StreamReader sr = new StreamReader(fs);
            string sInfo = sr.ReadLine();
            var parameters = sInfo.Split();

            int nVertices = Int32.Parse(parameters[0]);
            int nEdges = Int32.Parse(parameters[1]);

            //ListT<uple<float, float>> points = new List<Tuple<float, float>>();



            int[,] arr0 = new int[nVertices, nVertices];

            for (int i = 0; i < nVertices; i++)
            {
                for (int j = 0; j < nVertices; j++)
                {
                    arr0[i, j] = Int32.MaxValue;
                }
                arr0[i, i] = 0;
            }
            
            for (int i = 0; i < nEdges; i++)
            {
                sInfo = sr.ReadLine();
                var edge = sInfo.Split();
                int tail = Int32.Parse(edge[0]);
                int head = Int32.Parse(edge[1]);
                int length = Int32.Parse(edge[2]);
                arr0[tail - 1, head - 1] = length;
            }

            int[,] arr1 = new int[nVertices, nVertices];
            for (int k = 0; k < nVertices; k++)
            {
                for (int i = 0; i < nVertices; i++)
                {
                    for (int j = 0; j < nVertices; j++)
                    {

                        int case1 = arr0[i, j];
                        int case2 = Int32.MaxValue;
                        if (arr0[i, k] == Int32.MaxValue || arr0[k, j] == Int32.MaxValue)
                        {
                            case2 = Int32.MaxValue;
                        }
                        else 
                        {
                            case2 = arr0[i, k] + arr0[k, j];
                        }
                        int x = Math.Min(case1, case2);
                        arr1[i, j] = x;
                    }
                }
                arr0 = arr1;
                arr1 = new int[nVertices, nVertices];
            }

            bool bHasNegCycle = false;
            for (int i = 0; i < nVertices; i++)
            {
                if (arr0[i, i] != 0)
                {
                    bHasNegCycle = true;
                }
            
            }

            if (bHasNegCycle)
            {
                Console.WriteLine("Has negative cycle!");
                Console.ReadKey();
                return;
            }

            int min_path = Int32.MaxValue;

            for (int i = 0; i < nVertices; i++)
            {
                for (int j = 0; j < nVertices; j++)
                {

                    if (arr0[i, j] < min_path)
                    {
                        min_path = arr0[i, j];
                    }
                }
            }

            Console.WriteLine("MinPath is: {0}", min_path.ToString());
            Console.ReadKey();
        }
    }
}
