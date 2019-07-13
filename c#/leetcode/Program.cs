using System;
using System.Collections.Generic;
using System.Linq;
using ArrayTasks;

namespace leetcode {
    class Program {
        static void Main(string[] args) {
            //Solution sol = new Solution();
            Solution sol = new Solution();
            //  sol.FindDisappearedNumbers (new int[] { 10, 2, 5, 10, 9, 1, 1, 4, 3, 7 });

            sol.FindShortestSubArray(new int[] { 1,2,2,1,2,1,1,1,1,2,2,2 });
        }
    }

}