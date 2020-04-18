using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode {
    class Product_of_Array_Except_Self {


        public int[] ProductExceptSelf(int[] nums) {
            int totalProduct = 1;
            int[] res = new int[nums.Length];
            int zeroCount = 0;

            for (int i = 0; i < nums.Length; i++) {
                if (nums[i] != 0) {
                    totalProduct *= nums[i];
                } else {
                    zeroCount++;
                }
            }

            for (int i = 0; i < nums.Length; i++) {
                if (nums[i] != 0) {
                    res[i] = zeroCount >= 1 ? 0 : totalProduct / nums[i];
                } else {
                    res[i] = zeroCount >= 2 ? 0 : totalProduct;
                }

            }

            return res;
        }

        // Without division
        public int[] ProductExceptSelf1(int[] nums) {
            int totalProduct = 1;
            int[] res = new int[nums.Length];
            int zeroCount = 0;

            for (int i = 0; i < nums.Length; i++) {
                if (nums[i] != 0) {
                    totalProduct *= nums[i];
                } else {
                    zeroCount++;
                }
            }

            for (int i = 0; i < nums.Length; i++) {
                if (nums[i] != 0) {
                    res[i] = zeroCount >= 1 ? 0 : Divide(totalProduct, nums[i]);
                } else {
                    res[i] = zeroCount >= 2 ? 0 : totalProduct;
                }

            }

            return res;
        }

        public int Divide(int a, int b) {
            int count = 0;

            int aSign = a >= 0 ? 1 : -1;
            int bSign = b >= 0 ? 1 : -1;
            int k = aSign * bSign;

            k = k >= 0 ? 1 : -1;

            a = Math.Abs(a);
            b = Math.Abs(b);

            while (a >= b) {
                a -= b;
                count++;
            }

            return count * k;
        }
    }
}
