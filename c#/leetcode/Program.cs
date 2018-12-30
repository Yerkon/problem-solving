using System;
using System.Collections.Generic;
using MergeTwoBinaryTrees;

namespace leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            Solution sol = new Solution();
            TreeNode[] treeArr = sol.GetMock1();
            TreeNode merged = sol.MergeTrees(treeArr[0], treeArr[1]);
            Console.WriteLine("---");

        }
    }

}



