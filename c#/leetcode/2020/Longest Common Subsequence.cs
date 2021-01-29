using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode {
    class Longest_Common_Subsequence {
        public int LongestCommonSubsequence(string text1, string text2) {
            int c = 0;

            int prevIdx = -1;

            string temp = text1;

            if(text1.Length > text2.Length) {
                text1 = text2;
                text2 = temp;
            }


            for (int i = 0; i < text1.Length; i++) {
                int inner = 0;

                for (int j = prevIdx + 1; j < text2.Length; j++) {
                    if (text1[i] == text2[j]) {
                        prevIdx = j;
                        i++;
                        inner++;
                    }

                    if (i == text1.Length) return Math.Max(c, inner);
                }



                if (i + 1 != text1.Length) {
                    c = Math.Max(c, inner);

                }

            }

            return c;
        }
    }
}
