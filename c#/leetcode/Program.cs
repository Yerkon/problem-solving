using System;
using System.Collections.Generic;
using System.Linq;
using MathType;

namespace leetcode {
    class Program {
        static void Main(string[] args) {
            //Solution sol = new Solution();

            // [[-35,19],[40,19],[27,-20],[35,-3],[44,20],[22,-21],[35,33],[-19,42],[11,47],[11,37]]
            // [[-35,19],[40,19],[27,-20],[35,-3],[44,20],[22,-21],[35,33],[-19,42],[11,47],[11,37]]
            Solution sol = new Solution();
            sol.LargestTriangleArea(new int[][] {
                new int[] {-35, 19 },
                    new int[] { 40, 19 },
                    new int[] { 27, -20 },
                    new int[] { 35, -3 },
                    new int[] { 44, 20 },
                    new int[] { 22, -21 },
                    new int[] { 35, 33 },
                    new int[] {-19, 42 },
                    new int[] { 11, 47 },
                    new int[] { 11, 37 },
            });
        }

    }
}