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
            var stack = new Stack<TreeNode>();
            var parentStack = new Stack<TreeNode>();  

            stack.Push(root);
          
            while (stack.Count > 0) {
                var parentNode = parentStack.Count > 0 ? parentStack.Peek() : null;
                var currNode = stack.Pop();
                
                if (currNode.val < L) {
                    if(currNode.right != null) stack.Push(currNode.right);

                    if (parentNode != null) {
                        parentNode.left = currNode.right;
                    }

                    if (stack.Count > 0 && !(stack.Peek() == parentNode?.left || stack.Peek() == parentNode?.right)) {
                        if(parentStack.Count > 0) parentStack.Pop();
                    }

                    continue;
                } else if(currNode.val > R ) {
                    if(currNode.left != null) stack.Push(currNode.left);

                    if (parentNode != null) { 
                        parentNode.right = currNode.left;
                    }

                    if (stack.Count > 0 && !(stack.Peek() == parentNode?.left || stack.Peek() == parentNode?.right)) {
                        if (parentStack.Count > 0) parentStack.Pop();
                    }

                    continue;
                }

                // in range
                if (stack.Count > 0 && !(stack.Peek() == parentNode?.left || stack.Peek() == parentNode?.right)) {
                    if (parentStack.Count > 0) parentStack.Pop();
                }

                if (newRoot is null) {
                    newRoot = currNode;
                }

                if (currNode.left != null) stack.Push(currNode.left);
                if (currNode.right != null) stack.Push(currNode.right);

                if (currNode.left != null || currNode.right != null) {
                    parentStack.Push(currNode);
                }
            }

            return newRoot;
        }

    } //
}
