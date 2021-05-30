using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*
 * @lc app=leetcode id=947 lang=csharp
 *
 * [947] Most Stones Removed with Same Row or Column
 */

// @lc code=start
public class Solution {

    string[, ] plane = new string[10000, 10000];
    int[, ] size = new int[10000, 10000];

    public int RemoveStones(int[][] stones) {
        int res = 0;
        bool[, ] visited = new bool[10000, 10000];
        int[, ] matrix = new int[10000, 10000];

        int maxLength = 0;

        for (int i = 0; i < stones.Length; i++) {
            int r = stones[i][0];
            int c = stones[i][1];

            plane[r, c] = r + "#" + c;
            size[r, c] = 1;

            maxLength = Math.Max(c, Math.Max(maxLength, r));
        }

        for (int r = 0; r <= maxLength; r++) {
            for (int c = 0; c <= maxLength; c++) {
                if (!visited[r, c] && matrix[r, c] == 1) {
                    ArratDFS(matrix, visited, r, c, r, c);
                }
            }
        }

        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 4; j++) {
                Console.Write(plane[i, j] + " ");
            }

            Console.WriteLine();
        }

        //  print(size, plane);

        return res;
    }

    public string Find(int row, int col) {
        string val = row + "#" + col;

        while (val != plane[row, col]) {
            val = plane[row, col];
            (row, col) = ToPosition(val);
        }

        return val;
    }

    public void Union(int rowA, int colA, int rowB, int colB) {
        string rootA = Find(rowA, colA);
        string rootB = Find(rowB, colB);

        if (rootA == rootB) {
            return;
        }

        var(rootArow, rootAcol) = ToPosition(rootA);
        var(rootBrow, rootBcol) = ToPosition(rootB);

        // a smaller
        if (size[rootArow, rootAcol] <= size[rootBrow, rootBcol]) {
            plane[rootArow, rootAcol] = plane[rootBrow, rootBcol];
            size[rootBrow, rootBcol] += size[rootArow, rootAcol];
        } else {
            // b smaller
            plane[rootBrow, rootBcol] = plane[rootArow, rootAcol];
            size[rootArow, rootAcol] += size[rootBrow, rootBcol];
        }
    }

    public(int, int) ToPosition(string pos) {
        string[] strArr = pos.Split("#");

        return (int.Parse(pos[0].ToString()), int.Parse(pos[1].ToString()));
    }

    public void ArratDFS(int[, ] matrix, bool[, ] visited, int row, int col, int parentRow, int parentCol) {
        if (row == matrix.GetLength(0) || col == matrix.GetLength(1) || visited[row, col]) {
            return;
        }

        if (matrix[row, col] == 1) {
            visited[row, col] = true;

            // connect with parent;
            Union(parentRow, parentCol, row, col);

            for (int rr = 0; rr < matrix.GetLength(0); rr++) {
                ArratDFS(matrix, visited, rr, col, row, col);
            }

            for (int cc = 0; cc < matrix.GetLength(1); cc++) {
                ArratDFS(matrix, visited, row, cc, row, col);
            }
        }
    }

    public void print(int size, int[, ] plane) {
        for (int i = 0; i <= size; i++) {
            for (int j = 0; j <= size; j++) {
                Console.Write($"{plane[i, j]} ");
            }

            Console.WriteLine();
        }
    }

    public void CountRemoveStones(int[, ] plane, bool[, ] visited, int r, int c, ref int res) {
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