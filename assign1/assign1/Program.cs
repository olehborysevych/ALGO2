using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text;


namespace ALGO2
{
    namespace Assignment1
    {
        class Program
        {
            static void Main(string[] args)
            {

                FileStream fs;
                try
                {
                    fs = File.OpenRead(@".\data\jobs.txt");
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
                StreamReader sr = new StreamReader(fs);
                int numberOfJobs = Int32.Parse(sr.ReadLine());
                Job[] jobs = new Job[numberOfJobs];
                for (int i = 0; i < numberOfJobs; i++)
                {
                    string sJob = sr.ReadLine();
                    var words = sJob.Split();
                    jobs[i] = new Job(i, Double.Parse(words[0]), Double.Parse(words[1]));
                }

                jobs = jobs.OrderByDescending(job => (job.Weight - job.Length)).ThenByDescending(job => job.Weight).ToArray();

                double res = 0, offset = 0;

                foreach (Job job in jobs)
                {
                    res += job.GetWeighedCompletion(offset);
                    offset += job.Length;
                }
                Console.WriteLine("MinSumComplTimes(Weight-Length) = " + res.ToString());

                res = 0;
                offset = 0;

                jobs = jobs.OrderByDescending(job => (job.Weight / job.Length)).ToArray();
                foreach (Job job in jobs)
                {
                    res += job.GetWeighedCompletion(offset);
                    offset += job.Length;
                }
                Console.WriteLine("MinSumComplTimes(Weight/Length) = " + res.ToString());


            }

        }
    }
}
