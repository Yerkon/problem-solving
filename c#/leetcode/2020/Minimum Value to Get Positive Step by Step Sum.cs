using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode {
    class Minimum_Value_to_Get_Positive_Step_by_Step_Sum {
        public int MinStartValue(int[] nums) {
            int minStart = 1;
            int curr = minStart;

            for (int i = 0; i < nums.Length; i++) {
                curr += nums[i];

                if(curr < 1) {
                    minStart++;
                    curr = minStart;
                    i = -1;
                }
            }

            return minStart;
        }
    }
}
