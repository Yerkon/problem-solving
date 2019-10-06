using System;
using System.Collections.Generic;
using System.Linq;
using MathType;

namespace leetcode {
    class Program {
        static void Main(string[] args) {
            Solution sol = new Solution();
            sol.IsBoomerang(new int[][] {
                new int[] {0, 0},
                new int[] {1, 1},
                new int[] {1, 1}
            });
        }

    }
}