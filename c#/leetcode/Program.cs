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

            int[] input = new int[]{
                5,3,6,2,4,7
            };

            TreeNode root = new TreeNode(input[0]);

            for (int i = 1; i < input.Length; i++)
            {
                sol.InsertIntoBST(root, input[i]);
            }

            sol.DeleteNode(root, 6);
            Console.WriteLine(root);

        }
    }

}



