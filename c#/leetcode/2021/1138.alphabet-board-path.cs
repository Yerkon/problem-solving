using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*
 * @lc app=leetcode id=1138 lang=csharp
 *
 * [1138] Alphabet Board Path
 */

// @lc code=start
public class Solution {
    public string AlphabetBoardPath(string target) {
        string ans = "";
        int currRow = 0, currCol = 0;

        for (int i = 0; i < target.Length; i++) {

            var (row, col) = GetPosition(target[i]);
            ans += GetPath(currRow, currCol, row, col);

            currRow = row; currCol = col;
        }

        return ans;
    }

    public (int r, int c) GetPosition(char l) {
        int order = l - 'a';

        int row = order / 5;
        int col = order % 5;

        return (row, col);
    }

    public string GetPath(int row, int col, int dRow, int dCol) {
        string ans = "";

        char vDirection = row > dRow ? 'U' : 'D';
        char hDirection = col > dCol ? 'L' : 'R';

        int vDiff = Math.Abs(row - dRow);
        int hDiff = Math.Abs(col - dCol);

        if (row == 5 && col == 0) {
            for (int i = 0; i < vDiff; i++) {
                ans += vDirection;
            }

            for (int i = 0; i < hDiff; i++) {
                ans += hDirection;
            }
        } else {
            for (int i = 0; i < hDiff; i++) {
                ans += hDirection;
            }

            for (int i = 0; i < vDiff; i++) {
                ans += vDirection;
            }
        }

        return ans + "!";
    }
}
// @lc code=end

