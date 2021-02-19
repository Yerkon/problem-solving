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
    public class Trim_a_Binary_Search_Tree {
        public TreeNode TrimBST1(TreeNode root, int L, int R) {
            if (root is null) return null;

            if (root.val < L) {
                return TrimBST(root.right, L, R);
            } else if(root.val > R) {
                return TrimBST(root.left, L, R);
            }

            // in range
            root.left = TrimBST(root.left, L, R);
            root.right = TrimBST(root.right, L, R);

            return root;
        }


        // iterative
        public TreeNode TrimBST(TreeNode root, int L, int R) {
            if (root is null) return null;
            
            TreeNode newRoot = null;
            TreeNode parent = null;

            var stack = new Stack<TreeNode>();
            stack.Push(root);

            while (stack.Count > 0) {
                TreeNode curr = stack.Pop();

                if(curr is null) {
                    continue;
                }

                if(curr.val < L) {
                    stack.Push(curr.right);

                    if(parent != null) parent.left = curr.right;

                    continue;
                } else if(curr.val > R ) {
                    stack.Push(curr.left);

                    if(parent != null) parent.right = curr.left;

                    continue;
                }

                if(newRoot is null) {
                    newRoot = curr;
                }

                parent = curr;
                stack.Push(curr.left);
                stack.Push(curr.right);
               
            }

            return newRoot;
        }

    }
}
