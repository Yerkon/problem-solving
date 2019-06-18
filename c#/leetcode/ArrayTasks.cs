using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArrayTasks
{
    public class Solution
    {

        // Space Complexity: O(1), Time: O(N^2)
        // https://leetcode.com/problems/duplicate-zeros/
        public void DuplicateZeros1(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                {
                    for (int j = arr.Length - 1; j >= 1 && j != i; j--)
                    {
                        arr[j] = arr[j - 1];
                    }

                    i++;
                }
            }
        }
        // one pass, clear way
        // https://leetcode.com/problems/monotonic-array/
        public bool IsMonotonic(int[] A)
        {
            bool isIncreasing = true;
            bool isDecreasing = true;

            for (int i = 0; i < A.Length - 1; i++)
            {
                if (A[i] > A[i + 1]) isIncreasing = false;
                if (A[i] < A[i + 1]) isDecreasing = false;
            }

            return isIncreasing || isDecreasing;
        }

        // one pass
        // https://leetcode.com/problems/monotonic-array/
        public bool IsMonotonic2(int[] A)
        {
            bool shouldIncrease = true;
            bool isTheSame = true;

            for (int i = 0; i < A.Length - 1; i++)
            {
                if (isTheSame && A[i] != A[i + 1])
                {
                    isTheSame = false;
                    shouldIncrease = A[i] < A[i + 1];
                }

                if (!isTheSame && !shouldIncrease && A[i] < A[i + 1])
                {
                    return false;
                }

                if (!isTheSame && shouldIncrease && A[i] > A[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        //  two pass
        // https://leetcode.com/problems/monotonic-array/
        public bool IsMonotonic1(int[] A)
        {
            bool isIncrease = true;

            for (int i = 0; i < A.Length - 1; i++)
            {
                if (A[i] > A[i + 1])
                {
                    isIncrease = false;
                    break;
                }
            }

            if (!isIncrease)
            {
                // should decrease
                for (int i = 0; i < A.Length - 1; i++)
                {
                    if (A[i] < A[i + 1]) return false;
                }
            }

            return true;
        }

        // https://leetcode.com/problems/fair-candy-swap/
        public int[] FairCandySwap(int[] A, int[] B)
        {
            int aSum = 0, bSum = 0, delta = 0;
            int[] ans = new int[2];

            aSum = A.Sum();
            bSum = B.Sum();
            delta = (bSum - aSum) / 2;

            HashSet<int> setB = new HashSet<int>();
            Array.ForEach(B, val => setB.Add(val));

            foreach (int a in A)
            {
                if (setB.Contains(a + delta))
                {
                    return new int[] { a, a + delta };
                }
            }

            return ans;
        }

        // https://leetcode.com/problems/fair-candy-swap/
        public int[] FairCandySwap1(int[] A, int[] B)
        {
            int aSum = 0, bSum = 0, avg = 0;
            int[] ans = new int[2];

            aSum = A.Sum();
            bSum = B.Sum();
            avg = (aSum + bSum) / 2;

            for (int i = 0; i < A.Length; i++)
            {
                aSum -= A[i];
                for (int j = 0; j < B.Length; j++)
                {
                    aSum += B[j];

                    if (aSum == avg)
                    {
                        ans[0] = A[i];
                        ans[1] = B[j];

                        return ans;
                    }

                    aSum -= B[j];
                }

                aSum += A[i];
            }

            return ans;
        }

        // https://leetcode.com/problems/reshape-the-matrix/
        public int[][] MatrixReshape(int[][] nums, int r, int c)
        {
            int R = nums.Length, C = nums[0].Length, count = 0;
            if (R * C != r * c) return nums;

            int[][] ans = new int[r][];

            for (int i = 0; i < r; i++)
            {
                ans[i] = new int[c];
            }

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums[0].Length; j++)
                {
                    ans[count / c][count % c] = nums[i][j];
                    count++;
                }
            }

            return ans;
        }

        // https://leetcode.com/problems/reshape-the-matrix/
        public int[][] MatrixReshape1(int[][] nums, int r, int c)
        {
            int R = nums.Length, C = nums[0].Length;
            if (R * C != r * c) return nums;

            int[][] ans = new int[r][];

            int rIt = 0, cIt = 0;

            for (int i = 0; i < r; i++)
            {
                ans[i] = new int[c];

                for (int j = 0; j < c; j++)
                {
                    ans[i][j] = nums[rIt][cIt];
                    cIt++;

                    if (cIt == C)
                    {
                        cIt = 0;
                        rIt++;
                    }
                }
            }

            return ans;
        }

        // https://leetcode.com/problems/toeplitz-matrix/
        public bool IsToeplitzMatrix(int[][] matrix)
        {
            for (int r = 0; r < matrix.Length - 1; r++)
            {
                int[] row = matrix[r];

                for (int c = 0; c < row.Length - 1; c++)
                {
                    if (matrix[r][c] != matrix[r + 1][c + 1]) return false;
                }
            }

            return true;
        }

        // Time limit:  O(A.length) + O(queryes.length)) 
        // https://leetcode.com/problems/sum-of-even-numbers-after-queries/
        public int[] SumEvenAfterQueries(int[] A, int[][] queries)
        {
            int[] ans = new int[queries.Length];
            int evens = A.Sum(val => val % 2 == 0 ? val : 0);

            for (int r = 0; r < queries.Length; r++)
            {
                int[] queryRow = queries[r];
                int index = queryRow[1], val = queryRow[0];

                if (A[index] % 2 == 0)
                {
                    int rem = evens - A[index];
                    A[index] += val;

                    evens = A[index] % 2 == 0 ? rem + A[index] : rem;
                }
                else
                {
                    // odd becomes even
                    A[index] += val;
                    if (A[index] % 2 == 0) evens += A[index];
                }

                ans[r] = evens;
            }

            return ans;
        }

        // https://leetcode.com/problems/transpose-matrix/
        public int[][] Transpose(int[][] A)
        {
            int C = A[0].Length, R = A.Length;
            int[][] result = new int[C][];

            for (int c = 0; c < C; c++)
            {
                result[c] = new int[R];

                for (int r = 0; r < R; r++)
                {
                    result[c][r] = A[r][c];
                }
            }

            return result;
        }

        // https://leetcode.com/problems/find-common-characters/
        public IList<string> CommonChars(string[] A)
        {
            List<string> commonList = new List<string>();
            if (A.Length == 0) return commonList;

            int[] count = new int[26];
            Array.Fill(count, int.MaxValue);

            for (int i = 0; i < A.Length; i++)
            {
                int[] currArr = new int[26];
                string word = A[i];

                for (int j = 0; j < word.Length; j++)
                {
                    currArr[word[j] - 'a']++;
                }

                for (int j = 0; j < 26; j++)
                {
                    count[j] = Math.Min(count[j], currArr[j]);
                }
            }

            for (char c = 'a'; c <= 'z'; c++)
            {
                while (count[c - 'a'] > 0)
                {
                    commonList.Add(c + "");
                    count[c - 'a']--;
                }
            }

            return commonList;
        }

        // https://leetcode.com/problems/find-common-characters/
        public IList<string> CommonChars1(string[] A)
        {
            List<string> commonList = new List<string>();
            if (A.Length == 0) return commonList;

            Dictionary<char, int> mainDic = new Dictionary<char, int>();

            for (int i = 0; i < A[0].Length; i++)
            {
                string firstWord = A[0];
                mainDic[firstWord[i]] = mainDic.GetValueOrDefault(firstWord[i], 0) + 1;
            }

            for (int i = 1; i < A.Length; i++)
            {
                Dictionary<char, int> wordDic = new Dictionary<char, int>();
                string word = A[i];

                for (int j = 0; j < word.Length; j++)
                {
                    wordDic[word[j]] = wordDic.GetValueOrDefault(word[j], 0) + 1;
                }

                for (int j = 0; j < mainDic.Keys.Count; j++)
                {
                    char letterKey = mainDic.Keys.ElementAt(j);
                    mainDic[letterKey] = Math.Min(mainDic[letterKey], wordDic.GetValueOrDefault(letterKey, 0));
                }

            }

            foreach (var letterKey in mainDic.Keys)
            {
                for (int i = 0; i < mainDic[letterKey]; i++)
                {
                    commonList.Add(letterKey.ToString());
                }
            }

            return commonList;
        }

        // https://leetcode.com/problems/fibonacci-number/
        public int Fib(int N)
        {
            if (N == 0) return 0;
            if (N == 1) return 1;

            return Fib(N - 1) + Fib(N - 2);
        }

        // in place
        // https://leetcode.com/problems/sort-array-by-parity-ii/
        public int[] SortArrayByParityII(int[] A)
        {
            for (int i = 0, it = 0; i < A.Length && it < A.Length;)
            {
                if (it % 2 == A[i] % 2)
                {
                    if (it != i)
                    {
                        int temp = A[it];
                        A[it] = A[i];
                        A[i] = temp;

                        i = it;
                    }

                    it++;
                    i++;
                }

                i++;
            }

            return A;
        }
        // https://leetcode.com/problems/sort-array-by-parity-ii/
        public int[] SortArrayByParityII1(int[] A)
        {
            int[] result = new int[A.Length];
            int[] tempArr = new int[A.Length];
            int tempIt = 0;

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] % 2 == 0)
                {
                    tempArr[tempIt++] = A[i];
                }
            }

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] % 2 == 1)
                {
                    tempArr[tempIt++] = A[i];
                }
            }

            int evenIt = 0;
            int oddIt = tempArr.Length / 2;

            for (int i = 0; i < result.Length; i++)
            {
                if (i % 2 == 0)
                {
                    result[i] = tempArr[evenIt++];
                }
                else
                {
                    result[i] = tempArr[oddIt++];
                }
            }

            return result;
        }

        // https://leetcode.com/problems/squares-of-a-sorted-array/
        public int[] SortedSquares(int[] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = A[i] * A[i];
            }

            Array.Sort(A);

            return A;
        }
        // https://leetcode.com/problems/sort-array-by-parity/
        public int[] SortArrayByParity(int[] A)
        {
            int i = 0, j = A.Length - 1;
            while (i < j)
            {
                if (A[i] % 2 > A[j] % 2)
                {
                    int temp = A[i];
                    A[i] = A[j];
                    A[j] = temp;
                }

                if (A[i] % 2 == 0) i++;
                if (A[j] % 2 == 1) j--;
            }

            return A;

        }


        // https://leetcode.com/problems/sort-array-by-parity/
        public int[] SortArrayByParity1(int[] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] % 2 == 0) continue;

                for (int j = i + 1; j < A.Length; j++)
                {
                    if (A[j] % 2 == 0)
                    {
                        int temp = A[i];
                        A[i] = A[j];
                        A[j] = temp;

                        break;
                    }
                }
            }

            return A;
        }

        // https://leetcode.com/problems/flipping-an-image/
        public int[][] FlipAndInvertImage(int[][] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                int[] row = A[i];
                for (int j = 0; j < (row.Length + 1) / 2; j++)
                {
                    int temp = row[j] ^ 1;
                    row[j] = row[row.Length - 1 - j] ^ 1;
                    row[row.Length - 1 - j] = temp;
                }
            }

            return A;
        }
    }
}