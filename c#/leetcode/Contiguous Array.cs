using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode {
    class Contiguous_Array {

        int maxLength = 0;

        public int FindMaxLength(int[] nums) {

            int curr = 0, count = 0;
            int sum = 0;
            var leftDic = new Dictionary<int, int>();
            var rightDic = new Dictionary<int, int>();

           // GetLeftSum(nums, nums.Length - 1, leftDic);
            GetRightSum(nums, 0, rightDic);


            return maxLength;
        }

        public int GetLeftSum(int[] nums, int idx, Dictionary<int, int> leftDic) {
            if (idx < 0 || idx >= nums.Length) return 0;

            if(leftDic.ContainsKey(idx)) {
                return leftDic[idx];
            }
            int val = nums[idx] == 0 ? -1 : 1;

            leftDic[idx] = val + GetLeftSum(nums, idx - 1, leftDic);

            if (leftDic[idx] == 0) {
                maxLength = Math.Max(maxLength, nums.Length - idx);
            }

            return leftDic[idx];
        }

        public int GetRightSum(int[] nums, int idx, Dictionary<int, int> rightDic) {
            if (idx < 0 || idx >= nums.Length) return 0;

            if (rightDic.ContainsKey(idx)) {
                return rightDic[idx];
            }

            int val = nums[idx] == 0 ? -1 : 1;
            rightDic[idx] = val + GetRightSum(nums, idx + 1, rightDic);

            if (rightDic[idx] == 0) {
                maxLength = Math.Max(maxLength, idx + 1);
            }

            return rightDic[idx];
        }


        // brute force
        public int FindMaxLength1(int[] nums) {

            int maxLength = 0;
            int curr = 0, count = 0;
            int sum = 0;

            for (int i = 0; i < nums.Length; i++) {

                for (int j = i; j < nums.Length; j++) {
                    if (nums[j] == 0) curr--;
                    else curr++;

                    count++;

                    if (curr == 0) {

                        sum += count;
                        count = 0;
                    }
                }

               // Console.WriteLine("Clean: " +  i + " "  + sum);

                maxLength = Math.Max(maxLength, sum);

                count = 0;
                curr = 0;
                sum = 0;
            }

            return maxLength;
        }

        public int FindMaxLength2(int[] nums) {

            int maxLength = 0;
            int curr = 0 , count = 0, prev = 0;
            int sum = 0;
            for (int i = 0; i < nums.Length; i++) {
                if (nums[i] == 0) curr--;
                else curr++;

                count++;

                if(curr == 0) {
                    sum += count;
                    maxLength = Math.Max(maxLength, count + prev);
                    prev = count;
                    count = 0;
                }
            }

            maxLength = Math.Max(maxLength, sum);

            curr = 0;
            count = 0;
            prev = 0;
            sum = 0;

            for (int i = nums.Length - 1; i >= 0; i--) {
                if (nums[i] == 0) curr--;
                else curr++;

                count++;

                if (curr == 0) {
                    maxLength = Math.Max(maxLength, count + prev);
                    prev = count;
                    count = 0;
                }
            }

            maxLength = Math.Max(maxLength, sum);

            return maxLength;
        }
    }
}
