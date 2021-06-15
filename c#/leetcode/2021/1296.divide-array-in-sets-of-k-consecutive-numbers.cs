using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*
 * @lc app=leetcode id=1296 lang=csharp
 *
 * [1296] Divide Array in Sets of K Consecutive Numbers
 */

// @lc code=start
public class Solution {
    public bool IsPossibleDivide(int[] nums, int k) {
        var map = new Dictionary<int, int>();
        
        for (int i = 0; i < nums.Length; i++) {
            map[nums[i]] = map.GetValueOrDefault(nums[i], 0) + 1;
        }

        for (int i = 0; i < nums.Length; i++) {
            if(!IsRemoved(map, nums[i], k)) {
                return false;
            }
        }

        return true;
    }

    public void PrintMap(Dictionary<int, int> map) {
        foreach (var item in map)
        {
            Console.WriteLine(item.Key + ": " + item.Value);
        }
    }

    public bool IsRemoved(Dictionary<int, int> map, int curr, int k) {
        if(map[curr] == 0) return true;

        int it = curr;
       
        // move to begin conseq
        while (map.ContainsKey(it) && map[it] > 0) {
            it--;
        }

        it++;
        int freq = map[it];

        for (int i = 0; i < k; i++)
        {
            if(!map.ContainsKey(it + i) || map[it + i] < freq) return false;
            
            map[it + i] -= freq;
        }

        return true;
    }
}
// @lc code=end

