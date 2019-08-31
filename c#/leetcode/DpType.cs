using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace DpType {
    public class Solution {
        // Time: O(nlogn?), Space: O(N + recursive stack)
        // https://leetcode.com/problems/house-robber/
        public int Rob(int[] nums) {
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