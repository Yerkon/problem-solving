using BinaryTree2;
using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    internal class Program {
        private static void Main(string[] args) {
            Solution sol = new Solution();

            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(-2);
            root.left.left = new TreeNode(1);
            root.left.right = new TreeNode(3);

            root.left.left.left = new TreeNode(-1);

            sol.PathSum(root, 0);

            //Console.WriteLine(res);
        }

    }
}