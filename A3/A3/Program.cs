using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Q1MinCost mn = new Q1MinCost("ss");
            //mn.Solve(5, new long[][] { new long[] { 1 ,5, 4 }, new long[] { 4 ,1, 6 },

            // new long[] { 4 ,3 ,9 },
            //    new long[] { 2 ,3 ,6 }
            //,new long[] {3 ,2, 8 },
            //new long[] {5 ,1 ,4 },
            //new long[] {3 ,5 ,6 },
            //new long[] {1 ,3 ,2 },
            //  new long[] {5 ,4, 7},
            //new long[] {1 ,4 ,8 },
            //new long[] {5 ,2, 9 },
            // new long[] {3 ,1 ,8},
            //new long[] {2 ,5 ,2}}
            //, 2, 4);

            //Q2DetectingAnomalies q2 = new Q2DetectingAnomalies("sss");
            //q2.Solve(4,new long[][] {new long[] { 1 ,2 ,- 5 },
            //new long[] { 4, 1, 2 },
            //new long[] { 2, 3, 2 },
            //new long[] { 3 ,1, 1 } });


            //Q3ExchangingMoney em = new Q3ExchangingMoney("cc");
            //em.Solve(6, new long[][] {
            //new long[] { 6,5,20 },
            //new long[] { 6,4,-2 },
            //new long[] { 5,1,59},
            //new long[] { 2,5,60 },
            //new long[] { 4,6,22 },
            //new long[] { 2,6,51},
            //new long[] { 3,4,74 },
            // new long[] { 2,1,75},
            //new long[] { 1,5,42},
            //new long[] { 1,3,-21 },
            //new long[] { 5,6,-22},
            // new long[] {2,4,-18},
            //},6);

            Q4FriendSuggestion ae = new Q4FriendSuggestion("]]");
            ae.Solve(2, 1, new long[][] { new long[] { 1, 2, 1 } },4,new long[][] { new long[] { 1, 1 }, new long[] { 2, 2 }, new long[] { 1, 2 }, new long[] { 2, 1 } });

        }













    }
}
