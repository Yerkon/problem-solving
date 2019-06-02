using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArrayTasks
{
    public class ArrayTasks
    {
        // https://leetcode.com/problems/sort-array-by-parity-ii/
        public int[] SortArrayByParityII(int[] A)
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