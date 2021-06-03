using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*
 * @lc app=leetcode id=1748 lang=csharp
 *
 * [1748] Sum of Unique Elements
 */

// @lc code=start
public class Solution {
    public int SumOfUnique(int[] nums) {
        int res = 0;
        
        int[] countArr = new int[101];

        for (int i = 0; i < nums.Length; i++)
        {
            countArr[nums[i]]++;
        }

        for (int i = 0; i < countArr.Length; i++)
        {
            if(countArr[i] == 1) {
                res += i;
            }
        }

        return res;
    }
}
// @lc code=end

