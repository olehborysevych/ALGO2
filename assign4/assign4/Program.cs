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
                fs = File.OpenRead(@".\data\g1.txt");
                //fs = File.OpenRead(@".\data\test6.txt");
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

            //List<Tuple<float, float>> points = new List<Tuple<float, float>>();


            for (int i = 0; i < nEdges; i++)
            {
                sInfo = sr.ReadLine();
                var edge = sInfo.Split();
                int tail = Int32.Parse(edge[0]);
                int head = Int32.Parse(edge[1]);
                //points.Add(new Tuple<float, float>(x, y));
            }

        }
    }
}
