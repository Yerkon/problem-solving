using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*
 * @lc app=leetcode id=1408 lang=csharp
 *
 * [1408] String Matching in an Array
 */

// @lc code=start
public class Solution {
    public IList<string> StringMatching(string[] words) {
        var builder = new StringBuilder();
        var result = new List<string>();

        for (int i = 0; i < words.Length; i++) {
            
            for (int j = 0; j < words.Length; j++) {
                if (i !=j && words[j].Contains(words[i])) {
                    result.Add(words[i]);
                    break;
                }
            }
 
        }

        return result;
    }
}
// @lc code=end

