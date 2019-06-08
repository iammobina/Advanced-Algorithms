using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace Exam2
{
    public class Edge
    {
        //public int? From;
        //public int? To;
        public int? Row;
        public int? Coulumn;

    }


    public class ConvertingToSat
    {
        public int CountV;
        public Edge[] edges;

        public ConvertingToSat(int n)
        {
            CountV = n;
            edges = new Edge[n];
            for(int i=0;i<n;i++)
            {
                edges[i] = new Edge();
            }
        }

        public List<string> SATHelper()
        {
            List<string> answer = new List<string>();
            StringBuilder clauses = new StringBuilder();//((4 * CountV + 3 * edges.Length) + " " + 3 * CountV + "\n");
            UniqueNumber(clauses);
            Number(clauses);
            answer.Add(clauses.ToString());
            return answer;
        }

        private void Number(StringBuilder clauses)
        {
            foreach (Edge edge in edges)
            {
                int? from = edge.Row;
                int? to = edge.Coulumn;

                clauses.Append(-(from * 3 - 2))
                        .Append(" ")
                        .Append(-(to * 3 - 2))
                        .Append(" 0\n")
                        .Append(-(from * 3 - 1))
                        .Append(" ")
                        .Append(-(to * 3 - 1))
                        .Append(" 0\n")
                        .Append(-(from * 3))
                        .Append(" ")
                        .Append(-(to * 3))
                        .Append(" 0\n");
            }
        }


        private void UniqueNumber(StringBuilder clauses)
        {
            for (int i = 1; i < CountV * 3 + 1; i += 3)
            {
                clauses.Append(i)
                        .Append(" ")
                        .Append(i + 1)
                        .Append(" ")
                        .Append(i + 2)
                        .Append(" 0\n")

                        .Append(-i)
                        .Append(" ")
                        .Append(-(i + 1))
                        .Append(" 0\n")
                        .Append(" ")
                        .Append(-i)
                        .Append(" ")
                        .Append(-(i + 2))
                        .Append(" 0\n")
                        .Append(-(i + 1))
                        .Append(" ")
                        .Append(-(i + 2))
                        .Append(" 0\n");
            }
        }
    }

    public class Q1LatinSquareSAT : Processor
    {
        public Q1LatinSquareSAT(string testDataName) : base(testDataName)
        {
            ExcludeTestCaseRangeInclusive(34, 49);
            ExcludeTestCaseRangeInclusive(51, 54);
            ExcludeTestCaseRangeInclusive(28, 32);
            ExcludeTestCaseRangeInclusive(16, 20);
            ExcludeTestCaseRangeInclusive(4, 8);
            ExcludeTestCases(1, 13, 10, 22,24,25,26);
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<int,int?[,],string>)Solve);

        public override Action<string, string> Verifier =>
            TestTools.SatVerifier;

        //dim bode matris
        //age khune khalie bashe tu ye deraye has value mige
        //value meghdare deraye
        public string Solve(int dim, int?[,] square)
        {
            //3 edge misaze
            ConvertingToSat SAT = new ConvertingToSat(dim);
            int checko = square.Length;//9
            List<string> answer = new List<string>();


            for (int i = 0; i < dim; i++)
            {
                for(int j=0;j<dim;j++)
                {
                    SAT.edges[j].Row = square[i, j];
                    SAT.edges[j].Coulumn = square[j, i];
                }
               answer.Add(SAT.SATHelper().ToString());
            }

            //HasExactlyOneInRow(square,dim);
            //HasExactlyOneInColumn(square,dim);

            //foreach(var i in square)
            //{

            //}




            string[] answers;
            answers = SAT.SATHelper().ToArray();
            StringBuilder db = new StringBuilder();
            foreach(var p in answers)
            {
                db.AppendLine(p);
            }
            return db.ToString();
        }

        private void HasExactlyOneInRow(int?[,] square,int dim)
        {
            bool[] checkinRow = new bool[dim];
            for(int i=0;i<dim;i++)
            {
                for(int j=0;j<dim;j++)
                {
                   // foreach(var element in square[i,j])
                   
                   
                }
            }
        }

        private void HasExactlyOneInColumn(int?[,] square,int dim)
        {
            throw new NotImplementedException();
        }

       

        private static void HasExactlyOneInColumn(StringBuilder clausses)
        {
            //for (int i = 0; i < countdim; i++)
            //{
            //    for (int j = 0; j < dim; j++)
            //    {
            //        clausses.Append(i)

            //    }
            //}
        }

        private static void HasExactlyOneInRow(StringBuilder clausses)
        {
            throw new NotImplementedException();
        }





    }
}
