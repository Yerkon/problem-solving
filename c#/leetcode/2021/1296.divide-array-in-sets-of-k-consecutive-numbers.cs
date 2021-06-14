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
            int length = GetConseqLength(map, nums[i], k);
            Console.Write(nums[i] + "_" +  length + " ");
            PrintMap(map);
            Console.WriteLine("------");

            if (length != 0 && length != k) {
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

    public int GetConseqLength(Dictionary<int, int> map, int curr, int k) {
        int count = 0, it = curr;
        
        while (map.ContainsKey(it) && map[it] > 0) {
            map[it] -= 1;
            count++;
            it--;

            if (count == k) return count;
        }

        it = curr + 1;
        while (map.ContainsKey(it) && map[it] > 0) {
            map[it] -= 1;
            count++;
            it++;

            if (count == k) return count;
        }

        return count;
    }
}
// @lc code=end

