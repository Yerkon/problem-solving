using System;
using System.Collections.Generic;
using System.Text;

namespace Project._14_10_2020 {
    public class RangeSum_Solution {
        public int RangeSum(int[] nums, int n, int left, int right) {
            
            int sum = 0;
            int mod = 1000000007;
            int[] res = new int[n * (n + 1) / 2];
            int pos = 0;

            for (int i = 0; i < nums.Length; i++) {
                int currSum = nums[i];

                for (int j = i + 1; j < nums.Length; j++) {
                    res[pos++] = currSum;
                    currSum = currSum % mod + nums[j] % mod;
                }

                res[pos++] = currSum;
            }

            Array.Sort(res);

            for (int i = left - 1; i < right; i++) {
                sum = sum % mod + res[i] % mod;
            }

            return sum;
        }
    }
}
