using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode {
    class Maximum_Subarray {

        // Brute force
        public int MaxSubArray1(int[] nums) {
            int maxSubRange = int.MinValue;

            for (int i = 0; i < nums.Length; i++) {
                int sum = nums[i];
                for (int j = i + 1; j < nums.Length; j++) {

                    sum += nums[j];

                    maxSubRange = Math.Max(maxSubRange, sum);
                }
            }

            return maxSubRange;
        }

       
    }
}
