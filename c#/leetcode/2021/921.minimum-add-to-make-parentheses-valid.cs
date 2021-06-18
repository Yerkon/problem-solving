using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*
 * @lc app=leetcode id=921 lang=csharp
 *
 * [921] Minimum Add to Make Parentheses Valid
 */

// @lc code=start
public class Solution {

     // balance
     public int MinAddToMakeValid(string s) {
        if(string.IsNullOrEmpty(s)) return 0;
        int ans = 0, bal = 0;

        for (int i = 0; i < s.Length; i++)
        {
            bal += s[i] == '(' ? 1 : -1;
            
            // bal >= -1, guarantee
            if(bal == -1) {
                bal++;
                ans++;
            }
        }

        return ans + bal;
    }

    // stack
    public int MinAddToMakeValid1(string s) {
        if(string.IsNullOrEmpty(s)) return 0;

        var stack = new Stack<char>();

        stack.Push(s[0]);
        int it = 1;

        while (it < s.Length)
        {
            char curr = stack.Peek();

            if(curr == ')') {
                stack.Push(s[it]);
            } else if(curr == '(') {

                if(s[it] == ')') {
                    stack.Pop();
                } 
                else if(s[it] == '(') {
                    stack.Push(s[it]);
                }
            }

            it++;

            if(stack.Count() == 0 && it < s.Length) {
                stack.Push(s[it]);
                it++;
            }
        }

        return stack.Count();
    }
}
// @lc code=end

