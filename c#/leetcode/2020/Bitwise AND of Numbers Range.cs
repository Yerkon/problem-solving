using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode {
    class Bitwise_AND_of_Numbers_Range {
        public int RangeBitwiseAnd(int m, int n) {
            int val = 0;

            for (int i = 31; i >= 0; i--) {
                int k = m & (1 << i);
                int t = n & (1 << i);

                if (k > 0 && k == t) {
                    val += 1 << i;

                } else if (k > 0 || t > 0) {
                    return val;
                }
            }

            return val;
        }
    }
}
