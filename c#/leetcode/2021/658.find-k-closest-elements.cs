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
        int idx = Array.BinarySearch(arr, x);

        if(idx < 0) idx = ~(idx);
        
        var res = new int[k];
        int count = 0, leftIt = idx - 1, rightIt = idx;
      
        while (count != k) {

            if (leftIt < 0) {
                res[count++] = arr[rightIt++];
                continue;
            } else if (rightIt >= arr.Length) {
                res[count++] = arr[leftIt--];
                continue;
            }
            // in range

            if ((Math.Abs(arr[leftIt] - x) < Math.Abs(arr[rightIt] - x)) ||
                Math.Abs(arr[leftIt] - x) == Math.Abs(arr[rightIt] - x)
            ) {
                res[count++] = arr[leftIt--];
            } else {
                res[count++] = arr[rightIt++];
            }
        }

        Array.Sort(res);

        return res.ToList();
    }
}
// @lc code=end

