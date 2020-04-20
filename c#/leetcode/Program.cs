using BinaryTree2;
using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    internal class Program {
        private static void Main(string[] args) {

            var sol = new Search_in_Rotated_Sorted_Array();

            int[] input = new int[8] { 7, 8, 1, 2, 3, 4, 5, 6 };

            int res = sol.Search(input, 2);


            Console.WriteLine(res);
            //  sol.MinPathSum()
        }

    }
}