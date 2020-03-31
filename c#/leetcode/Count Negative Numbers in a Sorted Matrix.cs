using System;
using System.Collections.Generic;
using System.Text;

// https://leetcode.com/problems/count-negative-numbers-in-a-sorted-matrix/

namespace leetcode {
    class Count_Negative_Numbers_in_a_Sorted_Matrix {

        // Time: M * logn, Space: mlogn
        public int CountNegatives(int[][] grid) {
            int count = 0;

            for (int r = 0; r < grid.Length; r++) {
                int[] row = grid[r];

                int index = BinarySearch(row, 0, row.Length - 1);

                if (index != -1) {
                    count += row.Length - index;
                }

            }

            return count;
        }


        public int BinarySearch(int[] row, int l, int r) {
            if (l >= r) {
                return row[l] >= 0 ? -1 : l;
            }

            int mid = (l + r) / 2;

            return row[mid] >= 0
                ? BinarySearch(row, mid + 1, r)
                : BinarySearch(row, l, mid);
        }


        // naive 
        public int CountNegatives1(int[][] grid) {
            int count = 0;
           
            for (int r = 0; r < grid.Length; r++) {
                for (int c = 0; c < grid[r].Length; c++) {
                    if(grid[r][c] < 0) {
                        count++;
                    }
                }

            }

            return count;
        }
    }
}
