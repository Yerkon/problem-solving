using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode {
    class Number_of_Islands {
        int count = 0;
        public int NumIslands(char[][] grid) {
            bool[][] seen = new bool[grid.Length][];

            for (int i = 0; i < grid.Length; i++) {
                bool[] row = new bool[grid[i].Length];
                seen[i] = row;
            }

            for (int i = 0; i < grid.Length; i++) {
                for (int j = 0; j < grid[i].Length; j++) {
                    if (grid[i][j] == '1' && seen[i][j] == false) {
                        count++;

                        MarkRecursive(grid, seen, i, j);
                    }
                }
            }

            return count;
        }

        public void MarkRecursive(char[][] grid, bool[][] seen, int i, int j) {

            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length) {
                return;
            }

            if (seen[i][j]) {
                return;
            }

            if (grid[i][j] == '1') {
                seen[i][j] = true;
            } else {
                return;
            }

            MarkRecursive(grid, seen, i, j + 1);
            MarkRecursive(grid, seen, i, j - 1);
            MarkRecursive(grid, seen, i + 1, j);
            MarkRecursive(grid, seen, i - 1, j);

        }

    }
}
