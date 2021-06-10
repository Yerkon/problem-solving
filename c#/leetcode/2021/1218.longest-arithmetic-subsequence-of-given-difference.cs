using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*
 * @lc app=leetcode id=1218 lang=csharp
 *
 * [1218] Longest Arithmetic Subsequence of Given Difference
 */

// @lc code=start
public class Solution {

    public int LongestSubsequence(int[] arr, int difference) {
        int res = 1;
        var map = new Dictionary<int, int>();

        for (int i = 0; i < arr.Length; i++) {
            int key = arr[i] + difference;

            // init if no key
            map[arr[i]] = map.GetValueOrDefault(arr[i], 0);

            map[key] = map[arr[i]] + 1;

            res = Math.Max(res, map[key]);
        }

        return res;
    }

    // [1,2,3,4]
    // brute force
    public int LongestSubsequence1(int[] arr, int difference) {
        if (arr.Length == 1) return 1;
        int res = 1;

        for (int i = 0; i < arr.Length; i++) {
            int curr = arr[i] + difference;
            int count = 1;
            int j = i + 1;

            while (j < arr.Length) {

                if (arr[j] == curr) {
                    count++;
                    curr += difference;
                }

                j++;
            }

            res = Math.Max(res, count);
        }

        return res;
    }
}
// @lc code=end

