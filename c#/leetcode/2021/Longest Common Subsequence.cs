using System;
using System.Collections.Generic;
using System.Text;

namespace Project.January_2021 {
    internal class Longest_Common_Subsequence {
        public int LongestCommonSubsequence1(string text1, string text2) {
            
            int[][] dp = new int[text1.Length + 1][];

            for (int i = 0; i < text1.Length + 1; i++) {
                int[] dpRow = new int[text2.Length + 1];

                dp[i] = dpRow;
            }

            for (int i = 1; i <= text1.Length; i++) {
                for (int j = 1; j <= text2.Length; j++) {
                    int equal = text1[i - 1] == text2[j - 1] ? 1 : 0;
                    int k = equal + dp[i - 1][j - 1];
                    
                    dp[i][j] = Math.Max(k, Math.Max(dp[i][j - 1], dp[i - 1][j]));
                }
            }

            return dp[text1.Length][text2.Length];
        }

        // Time: O(MN), Space: O(M)
        public int LongestCommonSubsequence(string text1, string text2) {

            int[][] dp = new int[text1.Length + 1][];

            for (int i = 0; i < 2; i++) {
                int[] dpRow = new int[text2.Length + 1];

                dp[i] = dpRow;
            }

            for (int i = 1; i <= text1.Length; i++) {
                for (int j = 1; j <= text2.Length; j++) {
                    int equal = text1[i - 1] == text2[j - 1] ? 1 : 0;
                    int k = equal + dp[(i - 1)%2][j - 1];   

                    dp[i % 2][j] = Math.Max(k, Math.Max(dp[i % 2][j - 1], dp[(i - 1)%2][j]));
                }
            }

            return dp[text1.Length % 2][text2.Length];
        }

        public void CountSubs(string text, string currStr, int currIdx) {

            string curr = currStr +  text[currIdx];
            //var newBuilder = new StringBuilder(currStr.ToString());
            //newBuilder.Append(text[currIdx]);

            for (int i = currIdx + 1; i < text.Length; i++) {
                CountSubs(text, curr, i);
            }

        }
    }
}
