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
        public TreeNode TrimBST(TreeNode root, int L, int R) {
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

    }
}
