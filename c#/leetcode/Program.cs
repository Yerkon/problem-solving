using System;
using System.Collections.Generic;
using BinaryTree;

namespace leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            Solution sol = new Solution();
            var root = sol.GetTest1();

            var arr = sol.InorderTraversal(root);

            Console.WriteLine("---");

        }
    }

}



