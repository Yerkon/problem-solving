using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArrayTasks
{
    public class Solution
    {
        // https://leetcode.com/problems/transpose-matrix/
        public int[][] Transpose(int[][] A)
        {
            int[][] result = new int[A[0].Length][];

            Console.WriteLine(A[0].Length);
            for (int i = 0; i < A[0].Length; i++)
            {
                result[i] = new int[A.Length];

                for (int j = 0; j < result[i].Length; j++)
                {
                    //  Console.Write(i + "" + j + " ");
                    result[i][j] = A[j][i];
                }
                //  Console.WriteLine();

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