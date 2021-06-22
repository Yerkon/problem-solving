using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*
 * @lc app=leetcode id=658 lang=csharp
 *
 * [658] Find K Closest Elements
 */

// @lc code=start
public class Solution {
    public IList<int> FindClosestElements(int[] arr, int k, int x) {
        if (arr.Length == k) {
            return arr.ToList();
        }

        var res = new List<int>();
        int idx = Array.BinarySearch(arr, x);

        if (idx < 0) idx = ~(idx);

        int left = idx - 1, right = idx;

        while (right - left - 1 < k) {

            if (left < 0) {
                right++;
                continue;
            } 

            // in range
            if (right == arr.Length || Math.Abs(arr[left] - x) <= Math.Abs(arr[right] - x)) {
                left--;
            } else {
                right++;
            }
        }

        for (int i = left + 1; i < right; i++) {
            res.Add(arr[i]);
        }

        return res;
    }
}
// @lc code=end

