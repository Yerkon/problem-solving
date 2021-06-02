using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*
 * @lc app=leetcode id=1640 lang=csharp
 *
 * [1640] Check Array Formation Through Concatenation
 */

// @lc code=start
public class Solution {
    public bool CanFormArray(int[] arr, int[][] pieces) {

        Dictionary<int, int[]> dic = new Dictionary<int, int[]>();

        for (int i = 0; i < pieces.Length; i++)
        {
            dic.Add(pieces[i][0], pieces[i]);
        }

        for (int i = 0; i < arr.Length;)
        {
            if(!dic.ContainsKey(arr[i])) return false;

            var pieceArr = dic[arr[i]];

            for (int j = 0; j < pieceArr.Length; j++)
            {
                if(arr[i++] != pieceArr[j]) {
                    return false;
                }
            }
        }

        return true;
    }

}
// @lc code=end

