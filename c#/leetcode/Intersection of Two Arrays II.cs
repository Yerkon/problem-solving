using System;
using System.Collections.Generic;
using System.Text;

// https://leetcode.com/problems/intersection-of-two-arrays-ii/

namespace Intersection_of_Two_Arrays_II {
    class Solution {

        // What if the given array is already sorted? How would you optimize your algorithm?
        public int[] Intersect(int[] nums1, int[] nums2) {
            var list = new List<int>();
            var set1 = new HashSet<int>();
            var set2 = new HashSet<int>();

            var sorted1 = new List<int>();
            var sorted2 = new List<int>();

            sorted1.AddRange(nums1);
            sorted1.Sort();

            sorted2.AddRange(nums2);
            sorted2.Sort();

            int i = 0, j = 0;

            while (i < sorted1.Count && j < sorted2.Count) {
                if (sorted1[i] > sorted2[j]) j++;
                else if (sorted1[i] < sorted2[j]) i++;
                else {
                    list.Add(sorted1[i]);
                    i++; j++;
                }
            }

            return list.ToArray();
        }

        // brute force
        public int[] Intersect1(int[] nums1, int[] nums2) {
            var list = new List<int>();
            var set1 = new HashSet<int>();
            var set2 = new HashSet<int>();


            for (int i = 0; i < nums1.Length; i++) {
                for (int j = 0; j < nums2.Length; j++) {

                    if (nums1[i] == nums2[j] && !set1.Contains(i) && !set2.Contains(j)) {
                        list.Add(nums1[i]);

                        set1.Add(i);
                        set2.Add(j);
                    }
                }
            }

            return list.ToArray();
        }
    }
}
