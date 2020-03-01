using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode {
    public class Solution {

        // Space: O(1)
        public int RepeatedNTimes(int[] A) {

            for (int k = 1; k <= 3; k++) {
                for (int i = 0; i < A.Length - k; i++) {

                    if(A[i] == A[i + k]) {
                        return A[i];
                    }
                }
            }

            throw null;
        }

        // Space O(N)
        public int RepeatedNTimes1(int[] A) {
            var dic = new Dictionary<int, int>();

            for (int i = 0; i < A.Length; i++) {
                int el = A[i];

                dic[el] = dic.GetValueOrDefault(el, 0) + 1;

                if (dic[el] == A.Length / 2) {
                    return el;
                }
            }

            return 0;
        }
    }
}
