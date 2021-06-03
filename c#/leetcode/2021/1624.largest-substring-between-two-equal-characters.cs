using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * @lc app=leetcode id=1624 lang=csharp
 *
 * [1624] Largest Substring Between Two Equal Characters
 */

// @lc code=start
public class Solution {
    public int MaxLengthBetweenEqualCharacters(string s) {
        int res = -1;
        int[] letterArr = new int[26];
        letterArr = Array.ConvertAll<int, int>(letterArr, r => r = -1);

        for (int i = 0; i < s.Length; i++)
        {
            int k = s[i] - 'a';

            if(letterArr[k] == -1) {
                letterArr[k] = i;
            } else {
                // item found
                int length = i - letterArr[k] + 1 - 2;

                res = Math.Max(res, length);
            }
        }

        return res;
    }
}
// @lc code=end

