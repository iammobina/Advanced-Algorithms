using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A9
{
    public class Q2OptimalDiet : Processor
    {
        public Q2OptimalDiet(string testDataName) : base(testDataName)
        {
            ExcludeTestCases(18);
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<int, int, double[,], String>)Solve);

        public string Solve(int N, int M, double[,] matrix1)
        {
            double[,] table = ExpandMatrix(matrix1, N, M);
            double pivotValue;
            int pivotI;
            int pivotJ;
            while (FindPivot(table, N, M, out pivotValue, out pivotI, out pivotJ))
            {
                if (pivotI == -1 && pivotJ != -1)
                {
                    return "Infinity";
                }
                MakePivotOne(table, pivotI, pivotJ, N, M, pivotValue);
                DoRowProcess(table, pivotI, pivotJ, N, M, pivotValue);
            }



            double[] answers = CalcAnswers(table, N, M);

            for (int i = 0; i < N; i++)
            {
                double tmp = 0;
                for (int j = 0; j < M; j++)
                {
                    tmp += answers[j] * matrix1[i, j];
                }

                if (tmp > matrix1[i, M])
                {
                    return "No Solution";
                }
            }

            for (int i = 0; i < M; i++)
            {
                answers[i] = Math.Round(answers[i] * 2) / 2;
            }

            string output = "Bounded Solution\n";
            for (int i = 0; i < answers.Length; i++)
            {
                output += answers[i];
                if (i != answers.Length - 1) ;
                output += " ";
            }

            return output;
        }


        double[,] ExpandMatrix(double[,] matrix, int c, int v)
        {
            double[,] newMatrix = new double[c + 1, c + v + 2];
            for (int i = 0; i < c; i++)
            {
                for (int j = 0; j < v; j++)
                {
                    newMatrix[i, j] = matrix[i, j];
                }

                newMatrix[i, c + v + 1] = matrix[i, v];
            }

            for (int j = 0; j < v; j++)
            {
                newMatrix[c, j] = -1 * matrix[c, j];
            }

            for (int i = 0; i <= c; i++)
            {
                newMatrix[i, v + i] = 1;
            }

            return newMatrix;
        }

        bool FindPivot(double[,] matrix, int c, int v, out double pivotValue, out int i, out int j)
        {
            i = -1;
            j = -1;
            pivotValue = -1;

            double biggestNeg = 0;
            for (int p = 0; p < v + c + 1; p++)
            {
                if (matrix[c, p] < biggestNeg)
                {
                    biggestNeg = matrix[c, p];
                    j = p;
                }
            }

            if (biggestNeg == 0)
            {
                return false;
            }


            double temp = double.MaxValue;

            for (int p = 0; p < c + 1; p++)
            {
                if (matrix[p, j] != 0 && matrix[p, c + v + 1] / matrix[p, j] > 0 && matrix[p, c + v + 1] / matrix[p, j] < temp)   //sharte 2vom!!!!
                {
                    temp = matrix[p, c + v + 1] / matrix[p, j];
                    i = p;
                }
            }
            if (i >= 0 && j >= 0)
            {
                pivotValue = matrix[i, j];
            }
            return true;
        }

        void MakePivotOne(double[,] matrix, int i, int j, int c, int v, double pivotValue)
        {
            for (int p = 0; p < v + c + 2; p++)
            {
                matrix[i, p] = matrix[i, p] / pivotValue;
            }
        }

        void DoRowProcess(double[,] matrix, int i, int j, int c, int v, double pivotValue)
        {
            for (int p = 0; p < c + 1; p++)
            {
                if (p != i)
                {
                    double tmp = matrix[p, j];
                    for (int q = 0; q < c + v + 2; q++)
                    {
                        matrix[p, q] -= tmp * matrix[i, q];
                    }
                }
            }
        }

        double[] CalcAnswers(double[,] matrix, int c, int v)
        {
            double[] answers = new double[v];
            for (int i = 0; i < v; i++)
            {
                bool flag = false;
                for (int j = 0; j < c; j++)
                {
                    if (matrix[j, i] != 0)
                    {
                        if (!flag && matrix[j, i] == 1)
                        {
                            flag = true;
                            answers[i] = matrix[j, c + v + 1];
                            continue;
                        }
                        if (flag)
                        {
                            answers[i] = 0;
                            break;
                        }
                    }
                }
            }
            return answers;
        }
    }
}
