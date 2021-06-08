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

    // [1,2,3,4]
    public int LongestSubsequence(int[] arr, int difference) {
        if(arr.Length == 1) return 1;
        int res = 1;

        for (int i = 0; i < arr.Length; i++)
        {
            int curr = arr[i] + difference;
            int count = 1;
            int j = i + 1;

            while (j < arr.Length)
            {
                if(arr[j] == curr) {
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

