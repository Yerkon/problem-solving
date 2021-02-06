using System;
using System.Collections.Generic;
using System.Text;

namespace Project.January_2021 {
    internal class Longest_Common_Subsequence {
        public int LongestCommonSubsequence(string text1, string text2) {
            int longest = 0;

            var set1 = new HashSet<string>();
            var set2 = new HashSet<string>();

            for (int i = 0; i < text1.Length; i++) {
                CountSubs(text1, new StringBuilder(), i, set1);
            }

            for (int i = 0; i < text2.Length; i++) {
                CountSubs(text2, new StringBuilder(), i, set2);
            }

            foreach (string item in set1) {
                Console.WriteLine(item);
                if(set2.Contains(item)) {
                    longest = Math.Max(longest, item.Length);
                }
            }

            return longest;
        }

        public void CountSubs(string text, StringBuilder currStr, int currIdx, HashSet<string> set) {

            //string curr = currStr +  text1[currIdx];
            var newBuilder = new StringBuilder(currStr.ToString());
            newBuilder.Append(text[currIdx]);

            for (int i = currIdx + 1; i < text.Length; i++) {
                CountSubs(text, newBuilder, i, set);
            }

            set.Add(newBuilder.ToString());
        }
    }
}
