using System;
using System.Collections.Generic;
using System.Text;

namespace Project.HackerRank.DP {
    internal class Matrix_Block_Sum {

        // wrong
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
                    if (i + K < res.Length && j + K < res[i].Length) {
                        res[i][j] = dp[i + K][j + K];
                    } else if (j + K >= res[i].Length && i + K >= res.Length) {
                        int left = Math.Max(dp[i].Length - 2 - K, 0);
                        int top = Math.Max(dp.Length - 2 - K, 0);

                        res[i][j] = dp[dp.Length - 1][dp[i].Length - 1] - dp[dp.Length - 1][left] - dp[top][dp[i].Length - 1];


                        // add cross

                        res[i][j] += dp[top][left]; 
                    } else if (j + K >= res[i].Length) {
                        int begin = Math.Max(res[i].Length - 2 - K, 0);
                        res[i][j] = dp[i + K][res[i].Length - 1] - dp[i + K][begin];
                    } else if (i + K >= res.Length) {
                        int begin = Math.Max(res.Length - 2 - K, 0);
                        res[i][j] = dp[res.Length - 1][j + K] - dp[begin][j + K];
                    }

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
