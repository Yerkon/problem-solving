using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DP {
    public class Solution {

        // bottom- up. in progress
        public int CountSquares(int[][] matrix) {
            int count = 0;
            int[][] dp = new int[matrix.Length][];

            for (int i = 0; i < matrix.Length; i++) {
                int[] dpRow = new int[matrix[i].Length];

                dp[i] = dpRow;
            }


            for (int i = 0; i < matrix.Length; i++) {
                for (int j = 0; j < matrix[i].Length; j++) {

                    int prevTop = i - 1 < 0 ? 0 : dp[i - 1][j];
                    int prevLeft = j - 1 < 0 ? 0 : dp[i][j - 1];
                    int prevTopLeft = 0;

                    if (i - 1 < 0 && j - 1 < 0) {
                        prevTopLeft = 0;
                    } else if (i - 1 < 0) {
                        prevTopLeft = prevLeft;

                    } else if (j - 1 < 0) {
                        prevTopLeft = prevTop;
                    }

                    dp[i][j] = matrix[i][j] + Math.Min(Math.Min(prevTop, prevLeft), prevTopLeft);
                    count += dp[i][j];
                }
            }

            for (int i = 0; i < dp.Length; i++) {
                for (int j = 0; j < dp[i].Length; j++) {
                    Console.WriteLine(dp[i][j] + " ");
                }

                Console.WriteLine();
            }

            return count;
        }



        // Recursive way. Top-down
        public int CountSquares1(int[][] matrix) {
            int count = 0;
            int[][] memo = new int[matrix.Length][];

            for (int i = 0; i < matrix.Length; i++) {
                int[] memoRow = new int[matrix[i].Length];

                for (int j = 0; j < memoRow.Length; j++) {
                    memoRow[j] = -1;
                }

                memo[i] = memoRow;
            }


            for (int i = 0; i < matrix.Length; i++) {

                for (int j = 0; j < matrix[i].Length; j++) {
                    if (matrix[i][j] == 1) {
                        count += CountSquares(matrix, i, j, memo);
                    }
                }
            }

            return count;
        }

        public int CountSquares(int[][] matrix, int i, int j, int[][] memo) {
            if (i >= matrix.Length || j >= matrix[i].Length || matrix[i][j] == 0) {
                return 0;
            }

            if (memo[i][j] != -1) {
                return memo[i][j];
            }

            int bottomMin = CountSquares(matrix, i + 1, j, memo);
            int rightMin = CountSquares(matrix, i, j + 1, memo);
            int bottomRightMin = CountSquares(matrix, i + 1, j + 1, memo);

            memo[i][j] = 1 + Math.Min(Math.Min(bottomMin, rightMin), bottomRightMin);

            return memo[i][j];
        }
    }
}
