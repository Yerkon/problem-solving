using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode {
    public class Perm {
        static int n = 2;
        Stack<int> permutation = new Stack<int>();
        bool[] chosen = new bool[n];

        public void search() {
            if (permutation.Count == n) {
                // process permutation
                foreach (var item in permutation) {
                    Console.Write(item + " ");
                }

                Console.WriteLine();
            
            } else {
                for (int i = 0; i < n; i++) {
                    if (chosen[i]) continue;

                    chosen[i] = true;
                    permutation.Push(i);
                    search();

                    // clean up
                    chosen[i] = false;
                    permutation.Pop();
                }
            }
        }
    }
}
