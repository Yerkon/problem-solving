using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace MathType {

    public class Point3D {
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }

        public Point3D(int x, int y, int z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
    public class Solution {

        // https://leetcode.com/problems/projection-area-of-3d-shapes/
        public int ProjectionArea(int[][] grid) {
            int totalArea = 0;

            int[] xzProj = new int[grid.Length];
            int[] yzProj = new int[grid[0].Length];
            int[][] xyProj = new int[grid.Length][];

            for (int x = 0; x < grid.Length; x++) {
                xyProj[x] = new int[grid[0].Length];

                for (int y = 0; y < xyProj[x].Length; y++) {
                    xyProj[x][y] = 1;
                }
            }

            for (int x = 0; x < grid.Length; x++) {

                for (int y = 0; y < grid[x].Length; y++) {

                    xzProj[x] = Math.Max(xzProj[x], grid[x][y]); // max by y
                    yzProj[x] = Math.Max(yzProj[x], grid[y][x]); // max by x

                    xyProj[x][y] = Math.Min(xyProj[x][y], grid[x][y]);
                }
            }

            int xyCount = 0;
            for (int x = 0; x < xyProj.Length; x++) {
                xyCount += xyProj[x].Sum();
            }

            totalArea = xzProj.Sum() + yzProj.Sum() + xyCount;
            return totalArea;
        }

        // https://leetcode.com/problems/di-string-match/
        public int[] DiStringMatch(string S) {
            int min = 0;
            int max = S.Length;

            int[] res = new int[S.Length + 1];

            for (int i = 0; i < S.Length; i++) {
                if (S[i] == 'D') {
                    res[i] = max--;

                    if (i == S.Length - 1) {
                        res[i + 1] = max;
                    }

                } else if (S[i] == 'I') {
                    res[i] = min++;

                    if (i == S.Length - 1) {
                        res[i + 1] = min;
                    }
                }
            }

            return res;
        }

        // https://leetcode.com/problems/self-dividing-numbers/
        public IList<int> SelfDividingNumbers(int left, int right) {

            var result = new List<int>();

            for (int i = left; i <= right; i++) {

                int currVal = i;
                bool selfDividable = true;

                while (currVal > 0) {
                    int val = currVal % 10;
                    if (val == 0 || i % val != 0) {
                        selfDividable = false;
                        break;
                    }

                    currVal /= 10;
                }

                if (selfDividable) {
                    result.Add(i);
                }
            }

            return result;
        }
    }
}