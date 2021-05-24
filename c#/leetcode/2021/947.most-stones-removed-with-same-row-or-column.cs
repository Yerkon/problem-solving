using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
/*
 * @lc app=leetcode id=947 lang=csharp
 *
 * [947] Most Stones Removed with Same Row or Column
 */

// @lc code=start
public class Solution {
    public int RemoveStones(int[][] stones) {
        int res = 0;
        bool[,] visited = new bool[10000, 10000];
        int[,] plane = new int[10000, 10000];

        for (int i = 0; i < stones.Length; i++) {
            int r = stones[i][0];
            int c = stones[i][1];

            plane[r,c] = 1;
        }

        // Console.WriteLine(plane.Length);

        CountRemoveStones(plane, visited, stones[0][0], stones[0][1], ref res);

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write($"{plane[i, j]} ");
            }

            Console.WriteLine();
        }

        return res;
    }

    public void CountRemoveStones(int[,] plane, bool[,] visited, int r, int c, ref int res) {
        if (r == plane.GetLength(0) || c == plane.GetLength(1)) {
            return;
        }

        if (visited[r, c]) {
            return;
        }

        visited[r, c] = true;

        if (plane[r, c] == 1) {

            int newRow = r, newCol = c;
            bool byRow = false, byCol = false;
            for (int ir = r + 1; ir < plane.GetLength(0); ir++) {
                // visited[ir, c] = true;
                if (plane[ir, c] == 1) {
                    byRow = true;

                    newRow = ir;
                    break;
                }
            }

            if (byRow) {
                res++;
                plane[r, c] = 0;
            } else {

                for (int ic = c + 1; ic < plane.GetLength(1); ic++) {
                    // visited[r, ic] = true;
                    if (plane[r, ic] == 1) {
                        byCol = true;

                        newCol = ic;
                        break;
                    }
                }

                if(byCol) {
                    res++;
                    plane[r, c] = 0;
                }
            }

            CountRemoveStones(plane, visited, newRow, newCol, ref res);
        } 
    }
}
// @lc code=end

