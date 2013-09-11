using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGO2
{
    namespace Assignment1
    {
        struct Job
        {

            public Job(int id, double weight, double length) : this()
            {
                Weight = weight;
                Length = length;
                Id = id;
            }

            public double Weight { get; set; }
            public double Length { get; set; }
            public int Id { get; set; }

            public double GetWeighedCompletion(double offset)
            {
                return Weight * (offset + Length);
            }

            public override string ToString()
            {
                return String.Format("Job Id: {0}, Weight: {1}, Length: {2}", Id, Weight, Length);
            }

        }
    }
    }
