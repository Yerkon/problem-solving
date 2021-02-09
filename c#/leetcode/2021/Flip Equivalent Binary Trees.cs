using BinaryTree;
using System;
using System.Collections.Generic;
using System.Text;

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

namespace Project._2021 {
    internal class Flip_Equivalent_Binary_Trees {
        public bool FlipEquiv(TreeNode root1, TreeNode root2) {
            return IsNodesAreEqual(root1, root2);
        }

        public bool IsNodesAreEqual(TreeNode root1, TreeNode root2) {
            if (root1 is null && root2 is null) { return true; } 
            else if (root1 is null) return false;
            else if (root2 is null) return false;
            else if (root1.val != root2.val) return false;

            if(root1.left?.val == root2.left?.val && root1.right?.val == root2.right?.val) {
                return IsNodesAreEqual(root1.left, root2.left) && IsNodesAreEqual(root1.right, root2.right);
            } else if (root1.left?.val == root2.right?.val && root1.right?.val == root2.left?.val) {
                return IsNodesAreEqual(root1.left, root2.right) && IsNodesAreEqual(root1.right, root2.left);
            }

            return false;
        }
    }
}
