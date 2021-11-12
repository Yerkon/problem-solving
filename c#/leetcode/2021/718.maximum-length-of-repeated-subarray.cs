using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*
 * @lc app=leetcode id=718 lang=csharp
 *
 * [718] Maximum Length of Repeated Subarray
 */

// @lc code=start
public class Solution {
    public int FindLength(int[] nums1, int[] nums2) {
        int res = 0;

        for (int i = 0; i < nums1.Length; i++)
        {
            res = Math.Max(res, CalcConsequetiveLength(i, nums1, nums2)); 
        }

        for (int i = 0; i < nums2.Length; i++)
        {
            res = Math.Max(res, CalcConsequetiveLength(i, nums2, nums1));
        }

        return res;
    }

    public int CalcConsequetiveLength(int i, int[] nums1, int[] nums2){
         int res = 0;

        for (; i < nums1.Length; )
        {
            int lCount = 0;
           
            for (int j = 0; j < nums2.Length; )
            {
                if(i >= nums1.Length) {
                    break;
                }

                if(nums1[i] == nums2[j]) {
                    lCount++;
                    i++; j++;
                } else {
                    j++;

                    res = Math.Max(res, lCount);
                    lCount = 0;
                }
            }

            res = Math.Max(res, lCount);
            lCount = 0;
            i++;
        }    

        return res;
    }
}
// @lc code=end

