using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
/*
 * @lc app=leetcode id=190 lang=csharp
 *
 * [190] Reverse Bits
 */

// @lc code=start
public class Solution {


  public uint reverseBits(uint n) {
        
        uint res = 0;
        int pow = 31;

        while (n > 0)
        {
            res += (n & 1) << pow;
            n = n >> 1;

            pow -= 1;
        }


        return res;
    }

    public uint reverseBits1(uint n) {
        
        uint res = 0;
        StringBuilder s = new StringBuilder();
        
        for (int i = 0; i < 32; i++) {
            uint b = n % 2;
            s.Append(b);

            n /= 2;
        }

        for (int i = 0; i < 32; i++)
        {
            double val = uint.Parse(s[s.Length - 1 - i].ToString()) * Math.Pow(2, i);
            res += (uint)val;
        }

        return res;
    }
}
// @lc code=end

