/*
 * @lc app=leetcode id=1 lang=csharp
 *
 * [1] Two Sum
 */

// @lc code=start
public class Solution {
   public int[] TwoSum(int[] numbers, int target) {

            Dictionary<int, int> dic = new Dictionary<int, int>();
            List<int> result = new List<int>();

            for (int i = 0; i < numbers.Length; i++) {
                int c = target - numbers[i];

                if (dic.ContainsKey(c)) {
                    int idx = dic[c];
                    result.Add(idx + 1);
                    result.Add(i + 1);
                    break;
                }

                dic[numbers[i]] = i;
            }

            return result.ToArray();
        }
}
// @lc code=end

