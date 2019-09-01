using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace DpType {

    public class NumArray {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        int[] arr;
        public NumArray(int[] nums) {
            arr = nums;
        }

        public int SumRange(int i, int j) {
            if (i == j) {

                return arr[i];
            }

            if (i > j) {
                return 0;
            }

            int left = i >= arr.Length ? 0 : arr[i];
            int right = j < 0 ? 0 : arr[j];

            return left + right + SumRange(++i, --j);
        }

    }

    // with using Dictionary
    public class NumArray1 {
        Dictionary<KeyValuePair<int, int>, int> dic = new Dictionary<KeyValuePair<int, int>, int>();
        int[] arr;
        public NumArray1(int[] nums) {
            arr = nums;
        }

        public int SumRange(int i, int j) {

            if (i > j) {
                return 0;
            }

            KeyValuePair<int, int> key = KeyValuePair.Create(i, j);

            if (dic.ContainsKey(key)) return dic[key];

            if (i == j) {
                dic[key] = arr[i];
                return dic[key];
            }

            int left = i >= arr.Length ? 0 : arr[i];
            int right = j < 0 ? 0 : arr[j];

            dic[key] = left + right + SumRange(++i, --j);
            return dic[key];
        }

    }
    public class Solution {

        // Time: O(N), Space: recursive stack   
        // https://leetcode.com/problems/divisor-game/
        public bool DivisorGame(int N) {

            return MoveInDivisorGame(N, true);
        }

        public bool MoveInDivisorGame(int n, bool isAliceMove) {
            if (n <= 1) {
                return isAliceMove == true ? false : true;
            }

            int selectedVal = 1;

            return MoveInDivisorGame(n - selectedVal, !isAliceMove);
        }

        // iterative way
        // Time: O(N), Space: O(N)
        // https://leetcode.com/problems/house-robber/
        public int Rob(int[] nums) {
            int[] dp = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++) {
                int end = nums.Length - 1 - i;
                int dpMinus2 = i - 2 < 0 ? 0 : dp[i - 2];
                int dpMinus1 = i - 1 < 0 ? 0 : dp[i - 1];

                dp[i] = Math.Max(dpMinus2 + nums[end], dpMinus1);
            }

            return nums.Length == 0 ? 0 : dp[dp.Length - 1];
        }

        // recursive way
        // Time: O(N), Space: O(N + recursive stack)
        // https://leetcode.com/problems/house-robber/
        public int Rob1(int[] nums) {
            Dictionary<int, int> dic = new Dictionary<int, int>();

            return getRobRec(nums, 0, dic);
        }

        public int getRobRec(int[] nums, int index, Dictionary<int, int> dic) {
            if (dic.ContainsKey(index)) return dic[index];

            if (index >= nums.Length) return 0;

            if (index == nums.Length - 1) {
                dic[index] = nums[index];
                return dic[index];
            }

            int currVal = nums[index] + getRobRec(nums, index + 2, dic);
            currVal = Math.Max(currVal, getRobRec(nums, index + 1, dic));

            dic[index] = currVal;

            return dic[index];
        }

        // Time: O(N), Space: Stack size with max 3 items, O(1) ?
        // https://leetcode.com/problems/climbing-stairs/
        public int ClimbStairs(int n) {
            Stack<int> stack = new Stack<int>();
            int k = 0;

            while (k <= n) {
                if (k <= 2) {
                    stack.Push(k);
                } else {

                    int prev = stack.Pop();
                    int prev2 = stack.Pop();

                    int curr = prev + prev2;

                    stack.Push(prev);
                    stack.Push(curr);
                }

                k++;
            }

            return stack.Peek();
        }

        public int getPossibleSteps(int n, Dictionary<int, int> dic) {
            if (dic.ContainsKey(n)) return dic[n];

            if (n <= 2) {
                dic[n] = n;
                return n;
            }

            int val = ClimbStairs(n - 1) + ClimbStairs(n - 2);
            dic[n] = val;

            return dic[n];
        }

        // Time: O(N), Space: O(1)
        // https://leetcode.com/problems/is-subsequence/
        public bool IsSubsequence1(string s, string t) {

            if (s.Length == 0) return false;

            int start = 0;
            for (int i = 0; i < t.Length; i++) {

                if (s[start] == t[i]) {
                    start++;
                }

                if (start == s.Length) {
                    break;
                }
            }

            return start == s.Length;
        }
    }
}