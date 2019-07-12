using System;
using System.Collections.Generic;
using TestCommon;

namespace A9
{
    public class Equation
    {
        public Equation(double[,] a, double[] b)
        {
            this.a = a;
            this.b = b;
        }

        public double[,] a;
        public double[] b;
    }

    public class Position
    {

        public Position(long raw, long column)
        {
            this.column = column;
            this.raw = raw;
        }

        public long column;
        public long raw;
    }

    public class Q1InferEnergyValues : Processor
    {
        public static long num ;
        public Q1InferEnergyValues(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, double[,], double[]>)Solve);

        public double[] Solve(long MATRIX_SIZE, double[,] matrix)
        {
             num = MATRIX_SIZE;
            double[] b = new double[MATRIX_SIZE];
            Equation e = new Equation(matrix, b);
            return Solvehelper(e,MATRIX_SIZE);
        }

        public  double[] Solvehelper(Equation equation,long MATRIX_SIZE)
        {
            //List<double> fb = new List<double>();
            double[,] a = equation.a;
            double[] b = new double[num];
            long size = MATRIX_SIZE;

            bool[] used_columns = new bool[size];
            bool[] used_raws = new bool[size];

            for (int step = 0; step < size; ++step)
            {
                Position pelement = PivotElement(a, step);
                Swap(a, b, used_raws, pelement);
                ProcessElement(a, b, pelement);
                CheckElementUsed(pelement, used_raws, used_columns);
            }

            for (int i =(int) num - 1; i >= 0; i--)
            {
                b[i] = a[i, MATRIX_SIZE];
                for (int j = i + 1; j < num; j++)
                {
                    b[i] -= b[j] * a[i,j];
                }

                b[i] = b[i] / a[i, i];
                // fb.Add(b[i] / a[i, i]);
            }

            for (int i = 0; i < MATRIX_SIZE; i++)
            {

                b[i] = Math.Round(b[i] * 2, 0) / 2;
            }

            return b;
        }

        public static Position PivotElement(double[,] a, long step)
        {

            long max = step;
            for (int i =(int) step + 1; i < num; i++)
            {
                //double maxy = a[max, step];
                if (Math.Abs(a[i,step]) > Math.Abs(a[max,step]))
                {
                    max = i;
                   // maxy = Math.Abs(a[i, step]);
                }
            }
            //if (Math.Abs(a[max, step]) != 0)
            //{
            //    PivotElement(a, step);
            //}


            return new Position(max, step);
        }

        public static void Swap(double[,] a, double[] b, bool[] used_raws, Position pelement)
        {
            for (int column = 0; column <= num; column++)
            {
                double tmpa = a[pelement.column,column];
                a[pelement.column,column] = a[pelement.raw,column];
                a[pelement.raw,column] = tmpa;
            }

            double tmpb = b[pelement.column];
            b[pelement.column] = b[pelement.raw];
            b[pelement.raw] = tmpb;

            bool tmpu = used_raws[pelement.column];
            used_raws[pelement.column] = used_raws[pelement.raw];
            used_raws[pelement.raw] = tmpu;

            pelement.raw = pelement.column;
        }

        public static void ProcessElement(double[,] a, double[] b, Position plement)
        {
            for (int i = (int)plement.column + 1; i < num; i++)
            {
                double alpha = a[i,plement.column] / a[plement.column,plement.column];
                b[i] -= b[plement.raw] * alpha;
                for (int j = (int)plement.column+1; j <= num; j++)
                {
                    a[i,j] -= a[plement.column,j] * alpha;
                }
                a[i, plement.column] = 0;
            }
        }

        public static void CheckElementUsed(Position pelement, bool[] used_raws, bool[] used_columns)
        {
            used_raws[pelement.raw] = true;
            used_columns[pelement.column] = true;
        }
    }
}
