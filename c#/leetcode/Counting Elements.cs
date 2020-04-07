using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode {
    class Counting_Elements {

        // Time: O(nlogn), Space: O(1)
        public int CountElements(int[] arr) {
            int count = 0;
            int innerCount = 0;

            Array.Sort(arr);

            for (int i = 0; i < arr.Length - 1; i++) {
                if(arr[i] == arr[i + 1]) {
                    innerCount++;
                }
                else if(arr[i] + 1 == arr[i + 1]) {
                    count += innerCount + 1;
                    innerCount = 0;
                } else {
                    innerCount = 0;
                }
            }

            return count;
        }


        // Time: O(n), Space: O(uniq numbers of arr) = O(n)
        public int CountElements1(int[] arr) {
            int count = 0;

            var set = new HashSet<int>();
            for (int i = 0; i < arr.Length; i++) {

                set.Add(arr[i]);
            }

            for (int i = 0; i < arr.Length; i++) {
                if (set.Contains(arr[i] + 1)) count++;
            }

            return count;
        }

        
    }
}
