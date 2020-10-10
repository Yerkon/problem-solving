using System;
using System.Collections.Generic;
using System.Text;

namespace Project._10_10_2020 {
    public class Solution_MaxIncreaseKeepingSkyline {
        public int MaxIncreaseKeepingSkyline(int[][] grid) {
            int sum = 0;

            int[] topSkyLine = new int[grid[0].Length];
            int[] leftSkyLine = new int[grid.Length];

            for (int i = 0; i < grid.Length; i++) {
                for (int j = 0; j < grid[i].Length; j++) {
                    leftSkyLine[i] = Math.Max(leftSkyLine[i], grid[i][j]);
                    topSkyLine[i] = Math.Max(topSkyLine[i], grid[j][i]);
                }
            }

            for (int i = 0; i < grid.Length; i++) {
                for (int j = 0; j < grid[i].Length; j++) {
                    int addLeftHeight = Math.Max(0, leftSkyLine[i] - grid[i][j]);
                    int addTopHeight = Math.Max(0, topSkyLine[j] - grid[i][j]);

                    int addSum = Math.Min(addLeftHeight, addTopHeight);
                    grid[i][j] += addSum;

                    sum += addSum;
                }
            }

            return sum;
        }
    }
}
