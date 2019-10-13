using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace MathType {

    public class Solution {

        // https://leetcode.com/problems/largest-time-for-given-digits/
        public string LargestTimeFromDigits(int[] A) {

            string res = "";
            string strFormat = "00";

            List<int> minutes = new List<int>();
            Dictionary<string, int> timesDic = new Dictionary<string, int>();

            for (int i = 0; i < A.Length; i++) {
                for (int j = i + 1; j < A.Length; j++) {

                    int hour1 = int.Parse(A[i].ToString() + A[j].ToString());
                    int hour2 = int.Parse(A[j].ToString() + A[i].ToString());

                    int maxMinutes = -1;
                    minutes.Clear();

                    // find max minutes
                    for (int k = 0; k < A.Length; k++) {
                        if (!(k == i || k == j)) {
                            minutes.Add(A[k]);
                        }
                    }

                    int min1 = int.Parse(minutes[0].ToString() + minutes[1].ToString());
                    int min2 = int.Parse(minutes[1].ToString() + minutes[0].ToString());

                    if (min1 <= 59) maxMinutes = Math.Max(maxMinutes, min1);
                    if (min2 <= 59) maxMinutes = Math.Max(maxMinutes, min2);

                    if (maxMinutes != -1) {
                        if (hour1 <= 23) {
                            string time1 = hour1.ToString(strFormat) + ":" + maxMinutes.ToString(strFormat);
                            timesDic[time1] = hour1 * 60 + maxMinutes;
                        }

                        if (hour2 <= 23) {
                            string time2 = hour2.ToString(strFormat) + ":" + maxMinutes.ToString(strFormat);
                            timesDic[time2] = hour2 * 60 + maxMinutes;
                        }
                    }
                }
            }

            if (timesDic.Count == 0) return "";

            int max = -1;

            foreach (var key in timesDic.Keys) {

                if (timesDic[key] > max) {
                    res = key;

                    max = timesDic[key];
                }
            };

            return res;
        }

        // https://leetcode.com/problems/perfect-number/
        public bool CheckPerfectNumber1(int num) {
            HashSet<int> set = new HashSet<int>() { 6, 28, 496, 8128, 33550336 };

            return set.Contains(num);
        }


        // https://leetcode.com/problems/valid-boomerang/
        public bool IsBoomerang(int[][] points) {
            int[] a = points[0];
            int[] b = points[1];
            int[] c = points[2];

            if (isTwoPointsEqual(a, b) || isTwoPointsEqual(a, c) || isTwoPointsEqual(b, c)) {
                return false;
            }

            if (IsVertical(a, b) || IsVertical(a, c) || IsVertical(b, c)) {
                return !(IsVertical(a, b) && IsVertical(a, c) && IsVertical(b, c));
            }

            if (IsHorizontal(a, b) || IsHorizontal(a, c) || IsHorizontal(b, c)) {
                return !(IsHorizontal(a, b) && IsHorizontal(a, c) && IsHorizontal(b, c));
            }

            // find slope
            int yDiff = b[1] - a[1];
            int xDiff = b[0] - a[0];

            int mAB = yDiff / xDiff;

            // y − y1 = m(x − x1)
            int cY = mAB * (c[0] - a[0]) + a[1];

            return !(c[1] == cY);
        }

        public static bool isTwoPointsEqual(int[] a, int[] b) {
            return a[0] == b[0] && a[1] == b[1];
        }

        public static bool IsHorizontal(int[] a, int[] b) {
            int xDiff = b[0] - a[0];
            return xDiff != 0 && a[1] == b[1];
        }

        public static bool IsVertical(int[] a, int[] b) {
            int yDiff = b[1] - a[1];
            return yDiff != 0 && a[0] == b[0];
        }



        // https://leetcode.com/problems/factorial-trailing-zeroes/
        public int TrailingZeroes(int n) {
            int count = 0;

            while (n != 0) {
                count += n / 5;
                n /= 5;
            }

            return count;
        }


        // https://leetcode.com/problems/arranging-coins/
        public int ArrangeCoins(int n) {

            return (int)Math.Floor(-0.5 + Math.Sqrt(2.0 * n + 0.25));
        }


        public int ArrangeCoins1(int n) {
            int count = 0;

            for (int i = 1; n > 0; i++) {
                if (n >= i) {
                    count++;
                }

                n -= i;
            }

            return count;
        }


        // https://leetcode.com/problems/powerful-integers/
        public IList<int> PowerfulIntegers(int x, int y, int bound) {

            HashSet<int> set = new HashSet<int>();
            double curr = 0;

            for (int i = 0; ; i++) {
                double xPow = Math.Pow(x, i);

                for (int j = 0; curr <= bound; j++) {
                    double yPow = Math.Pow(y, j);
                    curr = xPow + yPow;

                    if (curr <= bound) {
                        set.Add((int)curr);
                    }

                    if (y == 1) break;
                }

                if (xPow > bound || x == 1) break;

                curr = 0;
            }

            return set.ToList();
        }

        // https://leetcode.com/problems/valid-perfect-square/
        public bool IsPerfectSquare(int num) {


            if (num == 1) return true;

            return FindSquareRoot(1, num, num);
        }

        public bool FindSquareRoot(int a, int b, int res) {
            if (a == b) return false;

            int middle = ((b - a) / 2 + a);
            double bigMiddle = middle * 1.0;
            double bigMultiplied = bigMiddle * bigMiddle;

            int multiplied = middle * middle;

            if (multiplied == res) {
                return true;
            } else if (bigMultiplied > res) {
                return FindSquareRoot(a, middle, res);
            } else {
                return FindSquareRoot(middle + 1, b, res);
            }

        }

        public bool IsPerfectSquare1(int num) {
            int sqr = 1;

            while (sqr * sqr < num) {
                sqr++;
            }

            return sqr * sqr == num;
        }

        // https://leetcode.com/problems/ugly-number/
        public bool IsUgly(int num) {
            if (num <= 0) return false;


            while (num > 5) {
                if (num % 2 == 0) {
                    num /= 2;
                } else if (num % 3 == 0) {
                    num /= 3;
                } else if (num % 5 == 0) {
                    num /= 5;
                } else {
                    return false;
                }
            }

            return true;
        }

        // https://leetcode.com/problems/set-mismatch/

        public int[] FindErrorNums(int[] nums) {
            int xor = 0, xor0 = 0, xor1 = 0;
            Array.ForEach(nums, n => xor ^= n);

            for (int i = 1; i <= nums.Length; i++)
                xor ^= i;

            int rightmostbit = xor & ~(xor - 1);

            Array.ForEach(nums, n => {
                if ((n & rightmostbit) != 0)
                    xor1 ^= n;
                else
                    xor0 ^= n;
            });

            for (int i = 1; i <= nums.Length; i++) {
                if ((i & rightmostbit) != 0)
                    xor1 ^= i;
                else
                    xor0 ^= i;
            }
            for (int i = 0; i < nums.Length; i++) {
                if (nums[i] == xor0)
                    return new int[] { xor0, xor1 };
            }
            return new int[] { xor1, xor0 };
        }

        public int[] FindErrorNums1(int[] nums) {
            HashSet<int> set = new HashSet<int>();
            int[] arr = new int[2];

            for (int i = 0; i < nums.Length; i++) {
                if (!set.Add(nums[i])) {
                    arr[0] = nums[i];
                }
            }

            for (int i = 1; i <= nums.Length; i++) {
                if (set.Add(i)) {
                    arr[1] = i;
                }
            }

            return arr;
        }

        // // https://leetcode.com/problems/power-of-three/
        // public bool IsPowerOfThree(int n) {

        //     string base3 = Convert.ToString(n, 3);
        //     Regex reg = new Regex("^10*$");

        //     return reg.IsMatch(base3);
        // }

        public bool IsPowerOfThree1(int n) {

            while (n > 2) {
                if (n % 3 > 0) return false;

                n /= 3;
            }

            return n == 1;
        }

        // https://leetcode.com/problems/power-of-two/
        public bool IsPowerOfTwo1(int n) {

            while (n > 1) {
                if (n % 2 == 1) return false;

                n /= 2;
            }

            return n == 1;
        }

        // https://leetcode.com/problems/happy-number/
        public bool IsHappy(int n) {
            if (n <= 0) return false;

            HashSet<int> set = new HashSet<int>();

            while (n != 1 && set.Add(n)) {
                int k = 0;

                while (n > 0) {
                    k = k + (n % 10) * (n % 10);
                    n /= 10;
                }

                n = k;
            }

            return n == 1;
        }

        // elegant way analysis
        // https://leetcode.com/problems/rectangle-overlap/
        public bool IsRectangleOverlap(int[] rec1, int[] rec2) {

            return (
                Math.Min(rec1[2], rec2[2]) > Math.Max(rec1[0], rec2[0]) && // by x
                Math.Min(rec1[3], rec2[3]) > Math.Max(rec1[1], rec2[1]) // by y
            );

        }

        // https://leetcode.com/problems/rectangle-overlap/
        public bool IsRectangleOverlap1(int[] rec1, int[] rec2) {
            int[] x1Axis = new int[] { rec1[0], rec1[2] };
            int[] x2Axis = new int[] { rec2[0], rec2[2] };

            int[] y1Axis = new int[] { rec1[1], rec1[3] };
            int[] y2Axis = new int[] { rec2[1], rec2[3] };

            return isOverlapByAxis(x1Axis, x2Axis) && isOverlapByAxis(y1Axis, y2Axis);
        }

        public bool isOverlapByAxis(int[] axisRange1, int[] axisRange2) {
            int axis1Start = Math.Min(axisRange1[0], axisRange1[1]);
            int axis1End = Math.Max(axisRange1[0], axisRange1[1]);

            int axis2Start = Math.Min(axisRange2[0], axisRange2[1]);
            int axis2End = Math.Max(axisRange2[0], axisRange2[1]);

            bool isOverlap = false;

            if (axis1Start == axis2Start && axis1End == axis2End) return true;

            if ((axis1Start < axis2Start && axis2Start < axis1End) ||
                (axis1Start < axis2End && axis2End < axis1End)
            ) {
                isOverlap = true;
            } else if ((axis2Start < axis1Start && axis1Start < axis2End) ||
                (axis2Start < axis1End && axis1End < axis2End)
            ) {
                isOverlap = true;
            }

            return isOverlap;
        }

        // https://leetcode.com/problems/range-addition-ii/
        public int MaxCount(int m, int n, int[][] ops) {
            for (int i = 0; i < ops.Length; i++) {
                m = Math.Min(m, ops[i][0]);
                n = Math.Min(n, ops[i][1]);
            }

            return m * n;
        }

        // https://leetcode.com/problems/range-addition-ii/
        public int MaxCount1(int m, int n, int[][] ops) {
            if (ops.Length == 0) {
                return m * n;
            }

            if (ops.Length == 1) {
                int a = ops[0][0];
                int b = ops[0][1];

                return a * b;
            }

            for (int i = 0; i < ops.Length; i++) {
                m = Math.Max(m, ops[i][0]);
                n = Math.Max(n, ops[i][1]);
            }

            int[][] matrix = new int[m][];
            int maxCount = 0;
            int maxVal = 0;

            for (int i = 0; i < m; i++) {
                int[] row = new int[n];

                for (int j = 0; j < n; j++) {
                    row[j] = 0;
                }

                matrix[i] = row;
            }

            for (int i = 0; i < ops.Length; i++) {
                int[] opr = ops[i];

                for (int r = 0; r < opr[0]; r++) {
                    for (int c = 0; c < opr[1]; c++) {

                        matrix[r][c]++;

                        maxVal = Math.Max(maxVal, matrix[r][c]);
                    }
                }

            }

            for (int i = 0; i < matrix.Length; i++) {
                for (int j = 0; j < matrix[i].Length; j++) {

                    if (matrix[i][j] == maxVal) {
                        maxCount++;
                    }
                }
            }

            return maxCount;
        }

        // https://leetcode.com/problems/day-of-the-year/
        public int DayOfYear(string date) {
            string[] dateArr = date.Split('-');
            int[] months = new int[] {
                31,
                28,
                31,
                30,
                31,
                30,
                31,
                31,
                30,
                31,
                30,
                33,
            };

            bool isLeapYear = false;
            int year = int.Parse(dateArr[0]);
            int month = int.Parse(dateArr[1]);
            int day = int.Parse(dateArr[2]);
            int dayOfYear = 0;

            if (year % 400 == 0) {
                isLeapYear = true;
            } else if (year % 100 == 0) {
                isLeapYear = false;
            } else if (year % 4 == 0) {
                isLeapYear = true;
            }

            if (isLeapYear) months[1] = 29;

            for (int i = 0; i < month - 1; i++) {
                dayOfYear += months[i];
            }

            return dayOfYear + day;
        }

        // https://leetcode.com/problems/minimum-moves-to-equal-array-elements/
        public int MinMoves(int[] nums) {
            int count = 0;

            int min = int.MaxValue;

            for (int i = 0; i < nums.Length; i++) {
                if (nums[i] < min) {
                    min = nums[i];
                }
            }

            for (int i = 0; i < nums.Length; i++) {
                count += nums[i] - min;
            }
            return count;
        }

        // https://leetcode.com/problems/minimum-moves-to-equal-array-elements/
        public int MinMoves1(int[] nums) {
            int count = 0;

            int min = int.MaxValue, max = int.MinValue;
            int maxIndex = 0;
            for (int i = 0; i < nums.Length; i++) {
                if (nums[i] > max) {
                    max = nums[i];
                    maxIndex = i;
                }

                if (nums[i] < min) {
                    min = nums[i];
                }
            }
            bool isAllTheSame = false;

            while (isAllTheSame == false) {
                int diff = max - min;
                int newMaxIndex = maxIndex;

                min = int.MaxValue;
                isAllTheSame = true;

                for (int i = 0; i < nums.Length; i++) {
                    if (i != maxIndex) {
                        nums[i] += diff;
                    }

                    if (nums[i] > max) {
                        max = nums[i];
                        newMaxIndex = i;
                        isAllTheSame = false;
                    }

                    if (nums[i] < min) {
                        min = nums[i];
                    }
                }

                maxIndex = newMaxIndex;
                count = count + diff;
            }

            return count;
        }

        // Sieve of Eratosthenes
        // https://leetcode.com/problems/prime-arrangements/
        public int NumPrimeArrangements(int n) {
            int primeCount = 0;
            int MOD = (int)(1e9 + 7);

            bool[] numberList = new bool[n + 1];
            for (int i = 2; i <= n; i++) {
                if (numberList[i] == false) {

                    for (int k = i * i; k <= n; k += i) {
                        numberList[k] = true;
                    }
                }
            }

            primeCount = numberList.Count(r => r == false) - 2;

            long primeNumComb = GetTotalCombinations(primeCount, MOD);
            long nonPrimeComb = GetTotalCombinations(n - primeCount, MOD);

            int ans = (int)(primeNumComb * nonPrimeComb % MOD);

            return ans;
        }

        // https://leetcode.com/problems/prime-arrangements/
        public int NumPrimeArrangements3(int n) {
            int primeCount = 0;
            int MOD = (int)(1e9 + 7);

            for (int i = 2; i <= n; i++) {
                if (IsPrime(i)) primeCount++;
            }

            long primeNumComb = GetTotalCombinations(primeCount, MOD);
            long nonPrimeComb = GetTotalCombinations(n - primeCount, MOD);

            int ans = (int)(primeNumComb * nonPrimeComb % MOD);

            return ans;
        }

        public long GetTotalCombinations(int n, int MOD) {
            long res = 1;
            for (int i = 2; i <= n; i++) {
                res = (res * i) % MOD;
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

            List<int> result = new List<int>();

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