using System;
using System.Collections.Generic;
using System.Text;

namespace Project.January_2021 {
    internal class Max_Chunks_To_Make_Sorted {

        // time: O(N^2)
        public int MaxChunksToSorted1(int[] arr) {
            int chunks = 0;
            HashSet<int> set = new HashSet<int>();

            for (int i = 0; i < arr.Length; i++) {
                set.Add(i);

                bool isInSet = true;
                for (int j = 0; j <= i; j++) {
                    if (!set.Contains(arr[j])) {
                        isInSet = false;
                    }
                }

                if(isInSet) {
                    chunks++;
                }

            }
            return  chunks;
        }

        // time: O(N)
        public int MaxChunksToSorted(int[] arr) {
            int chunks = 0;

            int[] sumArr = new int[arr.Length];

            for (int i = 1; i < arr.Length; i++) {
                sumArr[i] = sumArr[i - 1] + i;
            }

            int currSum = 0;
            for (int i = 0; i < arr.Length; i++) {
                currSum += arr[i];

                if(sumArr[i] == currSum) {
                    chunks++;
                }
            }
           
            return chunks;
        }
    }
}
