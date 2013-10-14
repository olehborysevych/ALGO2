using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign3
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs;
            try
            {
                fs = File.OpenRead(@".\data\knapsack_big.txt");
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

            int nCapacity = Int32.Parse(config_parts[0]);
            int nItems = Int32.Parse(config_parts[1]);

            List<Tuple<int, int>> items = new List<Tuple<int, int>>();


            string sItem = sr.ReadLine();
            while (!String.IsNullOrEmpty(sItem))
            {
                var sItemData = sItem.Split();
                items.Add(new Tuple<int, int>(Int32.Parse(sItemData[0]), Int32.Parse(sItemData[1])));
                sItem = sr.ReadLine();
            }

            Console.WriteLine("Loaded");

        }
    }
}
