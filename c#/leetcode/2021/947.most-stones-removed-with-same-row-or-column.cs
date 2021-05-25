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

        int size = 0;
        for (int i = 0; i < stones.Length; i++) {
            int r = stones[i][0];
            int c = stones[i][1];

            plane[r, c] = 1;

            size = Math.Max(c, Math.Max(size, r));
        }

        for (int i = 0; i <= size; i++) {
            for (int j = 0; j <= size; j++) {
                // Console.WriteLine($"iterate {i} {j}");

                if (!visited[i, j] && plane[i, j] == 1) {

                    // Console.WriteLine($"i: {i} j: {j}");
                    CountRemoveStones(plane, visited, i, j, ref res);

                  
                    // Console.WriteLine();
                }
            }
        }

        print(size, plane);

        return res;
    }

    public void print(int size, int[,] plane) {
        for (int i = 0; i <= size; i++) {
            for (int j = 0; j <= size; j++) {
                Console.Write($"{plane[i, j]} ");
            }

            Console.WriteLine();
        }
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

            // bottom
            for (int rr = r + 1; rr < plane.GetLength(0); rr++) {
                if (plane[rr, c] == 1) {
                    byRow = true;
                    newRow = rr;
                    break;
                }
            }

            if (!byRow) {
                // top
                for (int rr = r - 1; rr >= 0; rr--) {
                    if (plane[rr, c] == 1) {
                        byRow = true;
                        newRow = rr;
                        break;
                    }
                }
            }

            if (byRow) {
                res++;
                plane[r, c] = 0;
            } else {

                // right
                for (int cc = c + 1; cc < plane.GetLength(1); cc++) {
                    if (plane[r, cc] == 1) {
                        byCol = true;
                        newCol = cc;
                        break;
                    }
                }

                // left

                if (!byCol) {
                    for (int cc = c - 1; cc >= 0; cc--) {
                        if (plane[r, cc] == 1) {
                            byCol = true;
                            newCol = cc;
                            break;
                        }
                    }
                }

                if (byCol) {
                    res++;
                    plane[r, c] = 0;
                }
            }

            if (byRow || byCol) {
                CountRemoveStones(plane, visited, newRow, newCol, ref res);
            }
        }
    }
}
// @lc code=end

