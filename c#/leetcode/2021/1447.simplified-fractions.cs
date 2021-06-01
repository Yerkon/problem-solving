using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*
 * @lc app=leetcode id=1447 lang=csharp
 *
 * [1447] Simplified Fractions
 */

// @lc code=start
public class Solution {
    public IList<string> SimplifiedFractions(int n) {
        var res = new List<string>();

        for (int denum = 2; denum <= n; denum++)
        {
            for (int num = 1; num < denum; num++)
            {
                if(Gcd(num, denum) == 1) {
                    string val = $"{num}/{denum}";

                    res.Add(val);
                }        
            }
        }

        return res;

    }


    public int Gcd(int a, int b) {
        return b == 0 ? a : Gcd(b, a % b);
    }
}
// @lc code=end

