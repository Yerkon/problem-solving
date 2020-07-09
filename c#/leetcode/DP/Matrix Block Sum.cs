using System;
using System.Collections.Generic;
using System.Text;

namespace Project.HackerRank.DP {
    internal class Matrix_Block_Sum {

        
        public int[][] MatrixBlockSum(int[][] mat, int K) {
            int[][] res = new int[mat.Length][];
            int[][] dp = new int[mat.Length][];

            for (int i = 0; i < mat.Length; i++) {
                int[] row = new int[mat[i].Length];
                int[] dpRow = new int[mat[i].Length];

                res[i] = row;
                dp[i] = dpRow;
            }


            for (int i = 0; i < mat.Length; i++) {
                for (int j = 0; j < mat[i].Length; j++) {
                    dp[i][j] = mat[i][j];

                    if (i - 1 >= 0) dp[i][j] += dp[i - 1][j];

                    // add top columns sum
                    for (int k = 0; k < j; k++) {
                        dp[i][j] += mat[i][k];
                    }
                }
            }

            for (int i = 0; i < res.Length; i++) {
                for (int j = 0; j < res[i].Length; j++) {
                    int top = i - K - 1;
                    int left = j - K - 1;

                    int nextRow = Math.Min(i + K, dp.Length - 1);
                    int nextCol = Math.Min(j + K, dp[i].Length - 1);

                    res[i][j] = dp[nextRow][nextCol];

                    if (left >= 0) {
                        res[i][j] -= dp[nextRow][left];
                    }

                    if (top >= 0) {
                        res[i][j] -= dp[top][nextCol];
                    }

                    // add cross
                    if (top >= 0 && left >= 0) res[i][j] += dp[top][left];
                }
            }

            return res;
        }

        // accepted. Brute force
        public int[][] MatrixBlockSum2(int[][] mat, int K) {
            int[][] res = new int[mat.Length][];


            for (int i = 0; i < mat.Length; i++) {
                int[] row = new int[mat[i].Length];

                res[i] = row;
            }


            for (int i = 0; i < res.Length; i++) {

                for (int j = 0; j < res[i].Length; j++) {

                    // accumulate range;
                    int rStart = Math.Max(i - K, 0);
                    int rEnd = Math.Min(mat.Length - 1, i + K);

                    int cStart = Math.Max(j - K, 0);
                    int cEnd = Math.Min(mat[cStart].Length - 1, j + K);

                    for (int r = rStart; r <= rEnd; r++) {

                        for (int c = cStart; c <= cEnd; c++) {

                            res[i][j] += mat[r][c];
                        }
                    }

                }
            }

            return res;
        }

    }
}
