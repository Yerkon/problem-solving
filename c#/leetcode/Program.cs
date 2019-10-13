using System;
using System.Collections.Generic;
using System.Linq;
using MathType;

namespace leetcode {
    class Program {
        static void Main(string[] args) {
            Solution sol = new Solution();

            for (int i = 1; i <= 10000; i++) {
                bool isPerfect = sol.CheckPerfectNumber(i);

                if(isPerfect) {
                    Console.WriteLine(i + " = " + isPerfect);
                }
             
            }

        }

    }
}