using System;
using System.Collections.Generic;
using System.Text;

// https://leetcode.com/problems/peak-index-in-a-mountain-array/

namespace leetcode {
    class Peak_Index_in_a_Mountain_Array {

        // Time: log(n), space: 0(1)
        public int PeakIndexInMountainArray(int[] A) {
           
            int l = 0, r = A.Length - 1;

            while (l <= r) {
                int m = (l + r) / 2;

                if (A[m - 1] < A[m] && A[m] > A[m + 1]) {
                    return m;
                } else if(A[m -1] >  A[m] ) {
                    r = m - 1;
                } else if(A[m] < A[m + 1]) {
                    l = m + 1;
                }
            }

            return -1;
        }


        // linear 
        public int PeakIndexInMountainArray1(int[] A) {
            int peak = A[0];

            for (int i = 1; i < A.Length; i++) {
                if (peak > A[i]) return i - 1;

                peak = A[i];
            }

            return -1;
        }
    }
}
