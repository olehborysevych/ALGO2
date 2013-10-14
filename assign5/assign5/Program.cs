using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace assign5
{
    class Program
    {
        static void Main(string[] args)
        {

            FileStream fs;
            try
            {
                fs = File.OpenRead(@".\data\tsp.txt");
                //fs = File.OpenRead(@".\data\test6.txt");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            StreamReader sr = new StreamReader(fs);
            string sCities = sr.ReadLine();

            int nCities = Int32.Parse(sCities);
            List<Tuple<float, float>> points = new List<Tuple<float, float>>();

            string sCoordinates;
            for (int i = 0; i < nCities; i++)
            {
                sCoordinates = sr.ReadLine();
                var coords = sCoordinates.Split();
                float x = Single.Parse(coords[0]);
                float y = Single.Parse(coords[1]);
                points.Add(new Tuple<float, float>(x, y));

            }

            float[,] distances = new float[nCities,nCities];

            for (int i = 0; i < nCities; i++)
            {
                for (int j = 0; j < nCities; j++)
                {
                    if (i == j)
                    {
                        distances[i, j] = 0;
                    }
                    else
                    {
                        distances[i, j] = (float)Math.Sqrt(Math.Pow((points[i].Item1 - points[j].Item1), 2) + Math.Pow((points[i].Item2 - points[j].Item2), 2));
                    }
                }
            }

            //double[] factorials = PrefillFaclorialTable(nCities);

            int nDestinations = nCities - 1;
            long[] sets = new long[nCities - 1];
            sets[0] = nDestinations;
            for (int i = 1; i < nDestinations; i++)
            {
                sets[i] = (sets[i - 1] * (nDestinations - i)) / i;
            }
            Random z = new Random();

            for (int i = 0; i < 100000000; i++)
            {
                int k = i;
                if ((k % 1000) == 0)
                {
                  

                    int f = z.Next();
                    Console.WriteLine(k + " : " + f);
                    int[] va = new int[1000];
                }
            }
            Console.ReadLine();
            //////////////////////////////////////////////////////////
            // nCities   - number of cities 
            // distances - array of distances
            // factorials - precalculated factorials up to nCities - 1
            ///////////////////////////////////////////////////////////


        }

        public static double[] PrefillFaclorialTable(int nCities)
        {
            double[] fact = new double[nCities];
            fact[0] = 1;
            for (uint i = 1; i < nCities+1; i++)
            {
            fact[i] = i*fact[i-1]; 
            }
            return fact;
        }

        /// <summary>
        /// Builds all subsets {1,2,...n} of a given size m that include "1"
        /// </summary>
        /// <param name="?"></param>
        /// <param name="m"></param>
        public static int[] GetSubsets(int n, int m, double[] factorials)
        {
            
            if (m < 1)
            {
                throw new ArgumentException("m should be greater than zero");
            }

            if (m > 30)
            {
                throw new ArgumentException("m should be less than 31");
            }

            int[] sets; 
            if (m == 1)
            {
                sets = new int[1];
                sets[0] = 1;
                return sets;
            }
            else
            {
                double count = factorials[n - 1] / (factorials[m - 1] * factorials[n - 1 - m - 1]);
                sets = new int[(uint)count];
                return sets;
            }
        }

        //public static int[] GetCitiesFromSet(int value, int m)
        //{ 
        //    int[] = int[m-1]
        //for ()
        //}

    }
}
