using System;
using System.Collections.Generic;
using System.Linq;
using ArrayTasks;

namespace leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            //Solution sol = new Solution();
            Solution sol = new Solution();
            sol.SumEvenAfterQueries(new int[] { 1, 2, 3, 4 }, new int[][] {
                new int[] {1, 0},
                new int[] {-3, 1},
                new int[] {-4, 0},
                new int[] {2, 3}
            });

        }
    }

}



