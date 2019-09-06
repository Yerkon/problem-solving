using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace MathType {

    public class Solution {

        // https://leetcode.com/problems/distribute-candies-to-people/
        public int[] DistributeCandies(int candies, int num_people) {
            int[] ans = new int[num_people];
            int index = 0;
            int count = 0;

            while (candies > 0) {
                count++;
                int rem = candies - count;
                ans[index] += rem < 0 ? candies : count;

                index = ++index % num_people;
                candies = rem;
            }

            return ans;
        }

        // https://leetcode.com/problems/smallest-range-i/
        public int SmallestRangeI(int[] A, int K) {
            int min = 10000;
            int max = 0;

            for (int i = 0; i < A.Length; i++) {
                min = Math.Min(min, A[i]);
                max = Math.Max(max, A[i]);

            }

            K = Math.Abs(K);

            min += K;
            max -= K;

            return max - min < 0 ? 0 : max - min;
        }

        // Time: O(N^2), N = grid.length, Space: O(1)
        // https://leetcode.com/problems/projection-area-of-3d-shapes/
        public int ProjectionArea(int[][] grid) {
            int N = grid.Length;
            int ans = 0;

            for (int i = 0; i < N; i++) {
                int bestRow = 0;
                int bestCol = 0;

                for (int j = 0; j < N; j++) {
                    if (grid[i][j] > 0) ans++; // top shadow

                    bestRow = Math.Max(bestRow, grid[i][j]);
                    bestCol = Math.Max(bestCol, grid[j][i]);
                }

                ans += bestRow + bestCol;
            }

            return ans;
        }

        // Time: O(N^2) N = grid.length, Space: O(N^2)
        // https://leetcode.com/problems/projection-area-of-3d-shapes/
        public int ProjectionArea1(int[][] grid) {
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