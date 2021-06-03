using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * @lc app=leetcode id=1748 lang=csharp
 *
 * [1748] Sum of Unique Elements
 */

// @lc code=start
public class Solution {

    // two hashsets
     public int SumOfUnique(int[] nums) {
        int res = 0;
        
        var set1 = new HashSet<int>();
        var set2 = new HashSet<int>();

        foreach (var num in nums)
        {
            if(set1.Add(num)) {
                set2.Add(num);
            } else if(set2.Contains(num)) {
                set2.Remove(num);
            }
        }

        return set2.Sum();
    }


 // hashmap two loops
    public int SumOfUnique2(int[] nums) {
        int res = 0;
        
        var map = new Dictionary<int, int>();

        foreach (var num in nums)
        {
            map[num] = map.GetValueOrDefault(num, 0) + 1;
        }

        foreach (var num in nums)
        {
            if(map[num] == 1) {
                res += num;
            }
        }

        return res;
    }

    // array two loops
    public int SumOfUnique1(int[] nums) {
        int res = 0;
        
        int[] countArr = new int[101];

        for (int i = 0; i < nums.Length; i++)
        {
            countArr[nums[i]]++;
        }

        for (int i = 0; i < countArr.Length; i++)
        {
            if(countArr[i] == 1) {
                res += i;
            }
        }

        return res;
    }
}
// @lc code=end

