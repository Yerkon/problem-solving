using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*
 * @lc app=leetcode id=128 lang=csharp
 *
 * [128] Longest Consecutive Sequence
 */

// @lc code=start
public class Solution {

    public int LongestConsecutive(int[] nums) {
        if (nums.Length == 0) return 0;

        Array.Sort(nums);
        int max = 0, count = 0;

        for (int i = 0; i < nums.Length - 1; i++) {
            if (nums[i] == nums[i + 1]) {
                continue;
            }

            if (nums[i] + 1 == nums[i + 1]) {
                count++;

            } else {
                max = Math.Max(max, count + 1);
                count = 0;
            }
        }

        count++;
        max = Math.Max(max, count);

        return max;
    }

    // Ordered set
    public int LongestConsecutive1(int[] nums) {

        if (nums.Length == 0) return 0;

        int max = 0;
        int count = 0;
        var orderedSet = new SortedSet<int>(nums);

        for (int i = 0; i < orderedSet.Count - 1; i++) {
            if (orderedSet.ElementAt(i) + 1 == orderedSet.ElementAt(i + 1)) {
                count++;
            } else {
                max = Math.Max(max, count + 1);
                count = 0;
            }
        }

        count++;

        max = Math.Max(max, count);

        return max;
    }
}
// @lc code=end