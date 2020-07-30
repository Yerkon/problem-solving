using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result {
    /*
     * Complete the 'getWays' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. LONG_INTEGER_ARRAY c
     */

    // DP. Top-down solution
    public static long getWays(int W, List<long> c) {
        long[][] dp = new long[c.Count][];

        for (int i = 0; i < dp.Length; i++) {
            long[] row = new long[W + 1];
            dp[i] = row;

            for (int j = 0; j < row.Length; j++) {
                dp[i][j] = -1;
            }
        }

        return Calc(W, c, 0, dp);
    }

    public static long Calc(long N, List<long> c, int idx, long[][] dp) {
        if (N == 0 || c.Count == 0 || c.Count == idx) return 0;


        if (dp[idx][N] == -1) {

            if (N - c[idx] < 0) {
                dp[idx][N] = Calc(N, c, idx + 1, dp);
            }

            if (N - c[idx] >= 0) {
                int found = N - c[idx] == 0 ? 1 : 0;
                long include = Calc(N - c[idx], c, idx, dp);
                long next = Calc(N, c, idx + 1, dp);

                dp[idx][N] = include + found + next;
            }
        }

        return dp[idx][N];
    }
}

class Solution1 {
    public static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int m = Convert.ToInt32(firstMultipleInput[1]);

        List<long> c = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(cTemp => Convert.ToInt64(cTemp)).ToList();

        // Print the number of ways of making change for 'n' units using coins having the values given by 'c'

        long ways = Result.getWays(n, c);

        textWriter.WriteLine(ways);

        textWriter.Flush();
        textWriter.Close();
    }
}
