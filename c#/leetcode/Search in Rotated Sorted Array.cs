using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode {
    class Search_in_Rotated_Sorted_Array {
        public int Search(int[] nums, int target) {
            if (nums.Length == 0) return -1;

            int maxIndex = FindMaxIndex(nums, 0, nums.Length - 1);
            int minIndex = (maxIndex + 1) % nums.Length;
            
            if(target == nums[minIndex]) {
                return minIndex;

            } else if (minIndex == 0) {
                return FindIndex(nums, 1, nums.Length - 1, target);

            } else if(minIndex == nums.Length - 1) {
                return FindIndex(nums, 0, nums.Length - 2, target);

            } else if(target > nums[nums.Length - 1]) {
                return FindIndex(nums, 0, minIndex - 1, target);

            } else if(target <= nums[nums.Length - 1]) {
                return FindIndex(nums, minIndex, nums.Length - 1, target);
            }

         
            return -1;
        }

        public int FindMaxIndex(int[] nums, int l, int r) {
            if(l >= r) {
                return r;
            }
            
            int m = (l + r) / 2;

            if (nums[l] > nums[m]) {
                return FindMaxIndex(nums, l, m - 1);
            } else if (nums[m] > nums[r]) {
                return FindMaxIndex(nums, m, r - 1);
            } else if(nums[m] < nums[r]) {
                return FindMaxIndex(nums, m + 1, r);
            }

            return -1;
        }

        public int FindIndex(int[] nums, int l, int r, int target) {
            if (l >= r) {

                if (r < 0 || r == nums.Length || nums[r] != target) return -1;

                return r;
            }

            int m = (l + r) / 2;

            if (target == nums[m]) return m;

            else if(target < nums[m]) {
                return FindIndex(nums, l, m - 1, target);

            } else {
                return FindIndex(nums, m + 1, r, target);
            }            
        }
    }
}
