using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign1_2
{
    public class UnionFind
    {

        private int[] parent;
        private int[] rank;
        
        public UnionFind(int size)
        {
            parent = new int[size];
            for (int i = 0; i < size; i++)
            {
                parent[i] = i;
            }
                rank = new int[size];
        }

        public int GetRoot(int element)
        {
            //TODO add Path compression
            HashSet<int> nodes = new HashSet<int>();

            int el = element;
            while (parent[el] != el)
            {
                nodes.Add(element);
                el = parent[el];
            }
            foreach (var node in nodes)
            {
                parent[node] = el;
            }

            return el;
        }
        
        public int GetRoot(int element, out int el_rank)
        {
            //TODO add Path compression
            int el = element;
            HashSet<int> nodes = new HashSet<int>();
            while (parent[el] != el)
            {
                nodes.Add(element);
                el = parent[el];
            }
            foreach (var node in nodes)
            {
                parent[node] = el;
            }
            el_rank = rank[el];
            return el;
        }

        public void Merge(int element1, int element2)
        {

            int rank1;
            int root1 = GetRoot(element1, out rank1);

            int rank2;
            int root2 = GetRoot(element2, out rank2);

            if (rank1 > rank2)
            {
                parent[root2] = root1;
            }
            else
            {
                parent[root1] = root2;
                if (rank1 == rank2)
                {
                    rank[root2] += 1;
                }
            }
        }



    }
}
