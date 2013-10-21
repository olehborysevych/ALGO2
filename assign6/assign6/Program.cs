using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign6
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int i = 1; i < 7; i++)
            {
                Verify(@".\data\2sat" + i.ToString() + ".txt");
            }

            Console.ReadKey();

        }

        static void Verify(string fileName)
        { 
            FileStream fs;
            try
            {
                fs = File.OpenRead(fileName);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            StreamReader sr = new StreamReader(fs);
            string sTemp = sr.ReadLine();

            int nVariables = Int32.Parse(sTemp);


            List<Tuple<int, int>> items = new List<Tuple<int, int>>();



            string sClause = sr.ReadLine();
            while (!String.IsNullOrEmpty(sClause))
            {
                var sItemData = sClause.Split();
                items.Add(new Tuple<int, int>(Int32.Parse(sItemData[0]), Int32.Parse(sItemData[1])));
                sClause = sr.ReadLine();
            }

            //Console.WriteLine("Data import ready");

            while (Reduce(ref items))
            {
            }
            Console.WriteLine("File: {0}; Decision: {1}", fileName, Papadimitrou(items));

        }

        private static bool Reduce(ref List<Tuple<int, int>> clauses)
        {
            HashSet<int> variables_plus = new HashSet<int>();
            HashSet<int> variables_minus = new HashSet<int>();
            foreach (var clause in clauses)
            {
                if (clause.Item1 < 0)
                {
                    variables_minus.Add(Math.Abs(clause.Item1));
                }
                else
                {
                    variables_plus.Add(Math.Abs(clause.Item1));
                }
                if (clause.Item2 < 0)
                {
                    variables_minus.Add(Math.Abs(clause.Item2));
                }
                else
                {
                    variables_plus.Add(Math.Abs(clause.Item2));
                }

            }

            HashSet<int> variables = new HashSet<int>();

            foreach (var variable in variables_minus)
            {
                if (variables_plus.Contains(variable))
                {
                    variables.Add(variable);
                }
            }

            variables_minus.ExceptWith(variables);
            variables_plus.ExceptWith(variables);

            List<Tuple<int, int>> items_left = new List<Tuple<int, int>>();
            foreach (var clause in clauses)
            {
                if (variables.Contains(Math.Abs(clause.Item1)) && variables.Contains(Math.Abs(clause.Item2)))
                {
                    items_left.Add(clause);
                }
            }
            clauses = items_left;
            return (variables_minus.Any() || variables_plus.Any() || items_left.Count != clauses.Count);
        }

        private static bool Papadimitrou(List<Tuple<int, int>> clauses)
        {
            Random rg = new Random();
            Dictionary<int, bool> variables = new Dictionary<int, bool>();
            foreach (var clause in clauses)
            {
                variables[Math.Abs(clause.Item1)] = false;
                variables[Math.Abs(clause.Item2)] = false;

            }
            int nVariables = variables.Count;
            int nOuterIterations = (int)Math.Ceiling(Math.Log(nVariables, 2));
            int nInnerIterations = 2*nVariables*nVariables;

            for (int i = 0; i < nOuterIterations; i++)
            {
               
                Dictionary<int, bool> variableAssignment = new Dictionary<int, bool>();
                foreach (var variable in variables)
                {
                    variableAssignment[variable.Key] = (rg.Next() % 2 == 0) ? true : false;
                }

                for (int j = 0; j < nInnerIterations; j++)
                {
                    bool satisfied = true;

                    foreach (var clause in clauses)
                    {
                        int var1 = Math.Abs(clause.Item1);
                        int var2 = Math.Abs(clause.Item2);
                        bool bVar1 = (clause.Item1 > 0) ? variableAssignment[var1] : !variableAssignment[var1];
                        bool bVar2 = (clause.Item2 > 0) ? variableAssignment[var2] : !variableAssignment[var2];
                        bool bRes = bVar1 || bVar2;
                        if (!bRes)
                        {
                            satisfied = false;
                            bool bFirst = (rg.Next() % 2 == 0) ? true : false;
                            if (bFirst)
                            {
                                variableAssignment[var1] = !variableAssignment[var1];
                            }
                            else 
                            {
                                variableAssignment[var2] = !variableAssignment[var2];
                            }
                        }
                    }
                    if (satisfied)
                    {
                        return satisfied;
                    }
                }


            }
                return false; 
        }


    }
}
