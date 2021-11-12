/*
 * @lc app=leetcode id=342 lang=csharp
 *
 * [342] Power of Four
 */

// @lc code=start
using System;

public class Solution {

    public bool IsPowerOfFour(int n) {
        if (n < 1) return false;

        int curr = 1;
      
        while (curr <= n)
        {
            if((curr & n) == n) return true;

            curr <<= 2;
            // Console.WriteLine(curr);
        }


        return false;
    }

    public bool IsPowerOfFour1(int n) {
        if (n < 1) return false;

        while (n > 1) {
            if (n % 4 != 0) return false;

            n /= 4;
        }


        return true;
    }
}
// @lc code=end

