using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace MathType {

    public class Solution {
        
        // https://leetcode.com/problems/prime-arrangements/
        public int NumPrimeArrangements(int n) {
            int primeCount = 0;
            int nonPrimeCount = 0;

            for (int i = 2; i <= n; i++) {
                if (IsPrime(i)) primeCount++;
            }

            nonPrimeCount = n - primeCount;

            int primeNumComb = GetTotalCombinations(primeCount);
            int nonPrimeComb = GetTotalCombinations(nonPrimeCount);

            int ans = primeNumComb * nonPrimeComb % 1000000007;
            return ans;

        }

        public int GetTotalCombinations(int n) {
            int res = 1;
            for (int i = 2; i <= n; i++) {
                res = res * i;
            }

            return res;
        }

        public bool IsPrime(int n) {
            int c = 0;

            for (int i = 1; i <= n; i++) {
                if (n % i == 0) c++;
            }

            return c <= 2;
        }

        // iterative
        // https://leetcode.com/problems/prime-arrangements/
        public int NumPrimeArrangements2(int n) {
            HashSet<int> primeSet = new HashSet<int>();

            for (int num = 2; num <= 100; num++) {
                int c = 0;

                for (int i = 1; i <= num; i++) {
                    if (num % i == 0) {
                        c++;
                    }
                }

                if (c == 2) {
                    primeSet.Add(num);
                }
            }

            int ans = 0;
            int k = 2;
            Stack<List<int>> permStack = new Stack<List<int>>();
            permStack.Push(new List<int>() { 1 });

            while (k <= n) {
                List<List<int>> newListOfList = new List<List<int>>();

                while (permStack.Count > 0) {
                    List<int> source = permStack.Pop();

                    for (int i = 0; i <= source.Count; i++) {
                        List<int> newList = source.ToList();
                        newList.Insert(i, k);
                        newListOfList.Add(newList);
                    }

                }

                if (k == n) {

                    foreach (List<int> newList in newListOfList) {
                        bool isPrimePerm = true;

                        for (int i = 0; i < newList.Count; i++) {
                            if (primeSet.Contains(newList[i]) && !primeSet.Contains(i + 1)) {
                                isPrimePerm = false;

                                break;
                            }
                        }

                        if (isPrimePerm) {
                            ans++;
                        }
                    }

                } else {
                    foreach (List<int> newList in newListOfList) {
                        permStack.Push(newList);
                    }
                }

                k++;
            }

            return ans;

        }

        // https://leetcode.com/problems/prime-arrangements/
        public int NumPrimeArrangements1(int n) {
            HashSet<int> primeSet = new HashSet<int>() {
                2,
                3,
                5,
                7,
                11,
                13,
                17,
                19,
                23,
                29,
                31,
                37,
                41,
                43,
                47,
                53,
                59,
                61,
                67,
                71,
                73,
                79,
                83,
                89,
                97
            };

            List<int> answerList = new List<int>() { 0 };
            List<int> permutationList = new List<int>();

            GetPermutationPrimeList(primeSet, permutationList, answerList, n, 1, 0);

            return answerList[0];
        }

        public void GetPermutationPrimeList(
            HashSet<int> primeSet, List<int> permutationList, List<int> answerList, int size, int val, int index
        ) {

            List<int> newList = permutationList.ToList(); // copy
            newList.Insert(index, val);

            // base case
            if (newList.Count == size) {
                bool isPrimePerm = true;

                for (int i = 0; i < newList.Count; i++) {
                    if (primeSet.Contains(newList[i]) && !primeSet.Contains(i + 1)) {
                        isPrimePerm = false;

                        break;
                    }
                }

                if (isPrimePerm) {
                    answerList[0]++;
                }

                return;
            }

            for (int i = 0; i <= newList.Count; i++) {
                GetPermutationPrimeList(primeSet, newList, answerList, size, val + 1, i);
            }

        }

        // https://leetcode.com/problems/excel-sheet-column-number/
        public int TitleToNumber(string s) {
            int ans = s[0] - 'A' + 1;

            for (int i = 1; i < s.Length; i++) {
                int currNum = s[i] - 'A' + 1;
                ans = ans * 26 + currNum;
            }

            return ans;
        }

        // no loops
        // https://leetcode.com/problems/add-digits/    
        public int addDigits(int num) {
            if (num == 0) return 0;

            int rem = num % 9;

            return rem > 0 ? rem : 9;
        }

        // with use 'while'
        // https://leetcode.com/problems/add-digits/    
        public int addDigits1(int num) {
            while (num > 9) {
                int k = 0;

                while (num > 0) {
                    k += num % 10;
                    num /= 10;
                }

                num = k;
            }

            return num;
        }

        // https://leetcode.com/problems/largest-triangle-area/
        public double LargestTriangleArea(int[][] points) {
            double area = 0;

            for (int i = 0; i < points.Length; i++) {
                int[] point1 = points[i];

                for (int j = i + 1; j < points.Length; j++) {
                    int[] point2 = points[j];

                    for (int k = j + 1; k < points.Length; k++) {
                        int[] point3 = points[k];

                        // calculate area 

                        double p1p2 = CalcLengthOfTriangleSide(point1, point2);
                        double p2p3 = CalcLengthOfTriangleSide(point2, point3);
                        double p1p3 = CalcLengthOfTriangleSide(point1, point3);

                        double p = p1p2 + p2p3 + p1p3;
                        double s = p / 2;
                        double a = Math.Sqrt(s * (s - p1p2) * (s - p2p3) * (s - p1p3));

                        area = Math.Max(area, double.IsNaN(a) ? 0 : a);
                    }
                }
            }

            return area;
        }

        public double CalcLengthOfTriangleSide(int[] p1, int[] p2) {
            int x = p2[0] - p1[0];
            int y = p2[1] - p1[1];
            return Math.Sqrt(x * x + y * y);
        }

        public int LargestPerimeter(int[] A) {
            Array.Sort(A);

            int maxP = 0;

            for (int i = 0; i < A.Length - 2; i++) {
                int a = A[i];
                int b = A[i + 1];
                int c = A[i + 2];

                int p = a + b + c;
                double s = p * 1.0 / 2;
                double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

                maxP = Math.Max(maxP, area > 0 ? p : 0);
            }

            return maxP;
        }

        public int LargestPerimeter1(int[] A) {
            int max1 = -1, max2 = -1, max3 = -1;

            for (int i = 0; i < A.Length; i++) {

                if ((i < 3 && A[i] > max1) || (A[i] > max1 && isTriangle(A[i], max1, max2))) {
                    max3 = max2;
                    max2 = max1;
                    max1 = A[i];

                } else if ((i < 3 && A[i] > max2) || (A[i] > max2 && isTriangle(A[i], max1, max2))) {
                    max3 = max2;
                    max2 = A[i];

                } else if ((i < 3 && A[i] > max2) || (A[i] > max3 && isTriangle(A[i], max1, max2))) {
                    max3 = A[i];
                }
            }

            int p = max1 + max2 + max3;
            double s = p * 1.0 / 2;
            double a = Math.Sqrt(s * (s - max1) * (s - max2) * (s - max3));

            return a > 0 ? p : 0;
        }

        public bool isTriangle(int a, int b, int c) {
            if ((a + b) >= c) return false;
            if ((a + c) >= b) return false;
            if ((b + c) >= a) return false;

            return true;

        }

        // https://leetcode.com/problems/complement-of-base-10-integer/
        public int BitwiseComplement(int N) {
            if (N == 0) return 1;

            Stack<int> binaryStack = new Stack<int>();

            for (int i = 0; N > 0; i++) {
                int binary = (N % 2) ^ 1;
                binaryStack.Push(binary);

                N /= 2;
            }

            string binaryRepresent = string.Join("", binaryStack);
            int numRep = Convert.ToInt32(binaryRepresent, 2);

            return numRep;
        }

        public int BinaryGap(int N) {

            List<int> binaryList = new List<int>();
            int maxDistance = 0;

            for (int i = 0; N > 0; i++) {
                binaryList.Add(N % 2);
                N /= 2;
            }

            int startIdx = -1;
            int endIdx = -1;

            for (int i = 0; i < binaryList.Count; i++) {
                if (startIdx == -1 && binaryList.ElementAt(i) == 1) {
                    startIdx = i;
                } else if (endIdx == -1 && binaryList.ElementAt(i) == 1) {
                    endIdx = i;

                    maxDistance = Math.Max(maxDistance, endIdx - startIdx);
                    startIdx = endIdx;
                    endIdx = -1;
                }
            }

            return maxDistance;
        }

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