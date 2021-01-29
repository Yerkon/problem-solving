using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode {
    class Minimum_Path_Sum {
        public int MinPathSum(int[][] grid) {
            var dic = new Dictionary<string, int>();
            int sum = GetSum(grid, 0, 0, dic);

            return sum;
        }

        public int GetSum(int[][] grid, int i, int j, Dictionary<string, int> dic) {
            string key = i + "#" + j;

            if (dic.ContainsKey(key)) {
                return dic[key];
            }

            if (i == grid.Length - 1 && j == grid[i].Length - 1) {
                dic[key] = grid[i][j];
                return grid[i][j];
            }

      
            int sum1 = -1;
            int sum2 = -1;
            if(j + 1 < grid[i].Length) {
                sum1 = grid[i][j] + GetSum(grid, i, j + 1, dic);
            }

            if(i + 1 < grid.Length) {
                sum2 = grid[i][j] + GetSum(grid, i + 1, j, dic);
            }

            if(sum1 != -1 && sum2 != -1) {
                dic[key] = Math.Min(sum1, sum2);
                return Math.Min(sum1, sum2);

            } else if (sum1 == -1) {
                dic[key] = sum2;
                return sum2;

            } else {

                dic[key] = sum1;
                return sum1;
            }
        }
    }
}
