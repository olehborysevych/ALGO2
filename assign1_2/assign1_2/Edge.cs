using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign1_2
{
    public class Edge
    {
        public Edge(int id, int node1, int node2,int cost)
            {
                Node1 = node1;
                Node2 = node2;
                Cost = cost;
                Id = id;
            }

            public int Node1 { get; set; }
            public int Node2 { get; set; }
            public int Cost { get; set; }
            public int Id { get; set; }


            public override string ToString()
            {
                return String.Format("Edge Id: {0}, Node1: {1}, Node2: {2},  Cost: {3}", Id, Node1, Node2, Cost);
            }
    }
}
