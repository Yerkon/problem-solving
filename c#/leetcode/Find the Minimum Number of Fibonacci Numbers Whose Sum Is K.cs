using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode {
    internal class Find_the_Minimum_Number_of_Fibonacci_Numbers_Whose_Sum_Is_K {
        public int FindMinFibonacciNumbers(int k) {
            List<int> fib = new List<int>() { 1 };

            int t1 = 0, t2 = 1;
            for (int i = 1; i <= 45; i++) {
                int sum = t1 + t2;
                t1 = t2;
                t2 = sum;

                fib.Add(sum);
            }

            int curr = k, count = 0;

            while (curr != 0) {
                for (int i = fib.Count - 1; i >= 0; i++) {
                    if(fib[i] <= curr) {
                        curr -= fib[i];
                        count++;
                    }
                }
            }

            return count;
        }


        public int GetFibonacciNumbers(int curr, int[] nums) {

            if(curr == 1 || curr == 0) {
                nums[curr] = 1;
                return 1;
            }

            nums[curr] = GetFibonacciNumbers(curr - 1, nums) + GetFibonacciNumbers(curr - 2, nums);
            return nums[curr];
        }
    }
}
