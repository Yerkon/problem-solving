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

        // iterative 
        public bool FlipEquiv(TreeNode root1, TreeNode root2) {
            var stack1 = new Stack<TreeNode>();
            var stack2 = new Stack<TreeNode>();

            stack1.Push(root1);
            stack2.Push(root2);

            while (stack1.Count > 0 && stack2.Count > 0) {
                TreeNode node1 = stack1.Pop();
                TreeNode node2 = stack2.Pop();

                if(node1 is null && node2 is null) {
                    continue;
                } else if(node1 is null) {
                    return false;
                } else if(node2 is null) {
                    return false;
                } else if (node1.val != node2.val) return false;

                if (node1.left?.val == node2.left?.val && node1.right?.val == node2.right?.val) {
                    stack1.Push(node1.left);
                    stack2.Push(node2.left);

                    stack1.Push(node1.right);
                    stack2.Push(node2.right);
                } else if (node1.left?.val == node2.right?.val && node1.right?.val == node2.left?.val) {
                    stack1.Push(node1.left);
                    stack2.Push(node2.right);

                    stack1.Push(node1.right);
                    stack2.Push(node2.left);
                } else {
                    return false;
                }
             }

            return true;
        }

        // recursive
        public bool FlipEquiv1(TreeNode root1, TreeNode root2) {
            return IsNodesAreEqual(root1, root2);
        }

        public bool IsNodesAreEqual(TreeNode root1, TreeNode root2) {
            if (root1 is null && root2 is null) { return true; } 
            else if (root1 is null) return false;
            else if (root2 is null) return false;
            else if (root1.val != root2.val) return false;

            return (IsNodesAreEqual(root1.left, root2.left) && IsNodesAreEqual(root1.right, root2.right)) 
                || (IsNodesAreEqual(root1.left, root2.right) && IsNodesAreEqual(root1.right, root2.left));

        }

    }
}
