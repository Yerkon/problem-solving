using System;
using System.Collections.Generic;
using Trees;

namespace leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            Solution sol = new Solution();
            TreeNode[] treeArr = sol.GetMock1();
            bool res = sol.IsUnivalTree(treeArr[0]);
            Console.WriteLine("---");

        }
    }

}



