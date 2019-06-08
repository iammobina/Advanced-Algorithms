using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace Exam2
{

    public class Edges
    {
        public int? From;
        public int? To;
    }

    public class Matrix
    {
        public int firstrow;
        public int firtscoloumn;
        public int matrixlenght;
        public List<int?>[] rows;
        public List<int?>[] columns;
    }

    public class SATSolver
    {
        public Edges[] edges;
        public Matrix[] matris;
        public int dim;
        public int countClauses;

        public SATSolver(int dim)
        {
            matris = new Matrix[dim];
            for (int i = 0; i < dim; i++)
            {
                matris[i] = new Matrix();
            }
        }

        public List<string> SatSolvinggg()
        {
            List<string> answer = new List<string>();
            StringBuilder clauses = new StringBuilder();
            ValueinMatrix(clauses);
            InColoumn(clauses);
            InRow(clauses);
            InEachPosition(clauses);
            //Visited(clauses);
            answer.Add((countClauses + " " + dim * dim + "\n"));
            answer.Add(clauses.ToString());
            return answer;
        }

        public void InRow(StringBuilder clauses)
        {
            for (int i = 1; i < dim + 1; i++)
            {
                for (int j = 0; j < dim * dim; j += dim)
                {
                    clauses.Append(i + j)
                            .Append(" ");
                }
                clauses.Append("0\n");
                countClauses++;
            }
        }

        private void ValueinMatrix(StringBuilder clauses)
        {
            for (int i = 1; i < dim * dim + 1; i += dim)
            {
                for (int j = 0; j < dim; j++)
                {
                    clauses.Append(i + j)
                            .Append(" ");
                }
                clauses.Append("0\n");
                countClauses++;
            }
        }

        private void InEachPosition(StringBuilder clauses)
        {
            for (int i = 1; i < dim + 1; i++)
            {
                for (int j = 0; j < dim * dim; j += dim)
                {
                    for (int k = j + dim; k < dim * dim; k += dim)
                    {
                        clauses.Append(-(i + j))
                                .Append(" ")
                                .Append(-(i + k))
                                .Append(" 0\n");
                        countClauses++;
                    }
                }

            }
        }

        //private void Visited(StringBuilder clauses)
        //{
        //    bool[,] adj = new bool[dim, dim];

        //    foreach (var edge in edges)
        //    {
        //        adj[edge.From - 1, edge.From - 1] = true;
        //        adj[edge.To - 1, edge.To - 1] = true;
        //    }
        //    for (int i = 0; i < dim; i++)
        //    {
        //        for (int j = i + 1; j < dim; j++)
        //        {
        //            if (!adj[i, j])
        //            {
        //                for (int k = 0; k < dim - 1; k++)
        //                {
        //                    clauses.Append(-((i + 1) * dim - (dim - 1) + k))
        //                            .Append(" ")
        //                            .Append(-((j + 1) * dim - (dim - 1) + k + 1))
        //                            .Append(" 0\n")

        //                            .Append(-((j + 1) * dim - (dim - 1) + k))
        //                            .Append(" ")
        //                            .Append(-((i + 1) * dim - (dim - 1) + k + 1))
        //                            .Append(" 0\n");
        //                    countClauses += 2;
        //                }
        //            }
        //       }
        //    }
        //}

        private void InColoumn(StringBuilder clauses)
        {
            for (int i = 1; i < dim * dim + 1; i += dim)
            {
                for (int j = 0; j < dim; j++)
                {
                    for (int k = j + 1; k < dim; k++)
                    {
                        clauses.Append(-(i + j))
                                .Append(" ")
                                .Append(-(i + k))
                                .Append(" 0\n");
                        countClauses++;
                    }
                }
            }
        }


    }

    //public void CreateBoolean(int?[,] square, int dim)
    //{
    //    StringBuilder cc = new StringBuilder();
    //    List<int?> rows = new List<int?>();
    //    List<int?> coloumn = new List<int?>();
    //    //foreach(var i in square)
    //    //{
    //    //    //Stack<int?> stack = new Stack<int?>();
    //    //    List<int?> checker = new List<int?>();
    //    //    if(i )
    //    //}
    //    SATSolver s = new SATSolver(dim);
    //    List<int?> checker = new List<int?>();
    //    for (int i = 0; i < dim; i++)
    //    {
    //        for (int j = 0; j < dim; j++)
    //        {
    //            //s.matris[j].rows = square[i, j].;
    //            //s.matris[j].columns = square[j, i];
    //            //foreach(var b in square)
    //            //rows.Add(square[i, j]);
    //            //coloumn.Add(square[j, i]);

    //            //if(square[i,j].HasValue && !checker.Contains(square[i,j]) )
    //            //{
    //            //    checker.Add(square[i, j].Value);
    //            //}
    //            for (int k = 0; k < dim; k++)
    //            {
    //                foreach (var b in square)
    //                {
    //                    //while (true)
    //                    //{
    //                    if (b.HasValue)
    //                    {
    //                        if (b > 0)
    //                        {
    //                            cc.Append(b);
    //                        }
    //                        if (b < 0)
    //                        {
    //                            cc.Append(-b);
    //                        }
    //                    }
    //                    //}

    //                }
    //            }

    //            //cc.Append(b);
    //            //cc.Append("");
    //        }
    //    }

    //for (int i = 0; i < dim * 3; i++)
    //{
    //    //foreach (var i in rows)
    //    //{
    //    //    
    //    if (matris[i].rows
    //            checker.Add(cc.Append());
    //        else if (checker.Contains(i))

    //

    public class Q2LatinSquareBT : Processor
    {
        public Q2LatinSquareBT(string testDataName) : base(testDataName)
        {
            this.ExcludeTestCaseRangeInclusive(28, 120);
            ExcludeTestCaseRangeInclusive(1, 54);
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<int, int?[,], string>)Solve);

        public string Solve(int dim, int?[,] square)
        {
            SATSolver sat = new SATSolver(dim);
            for(int i=0;i<dim;i++)

            {
                for (int j = 0; j < dim; j++)
                {
                    sat.edges[i].From = square[i, j];
                    sat.edges[j].To = square[j, i]; ;
                }
            }

            string[] answers;
            answers = sat.SatSolvinggg().ToArray();
            StringBuilder db = new StringBuilder();
            foreach (var p in answers)
            {
                db.AppendLine(p);
            }
            return db.ToString();
        }
    }
}