using BinaryTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace LongestUnivaluePath {
    public class Solution {

        int longPath = 0;
        // https://leetcode.com/problems/longest-univalue-path/

        public int LongestUnivaluePath(TreeNode root) {
            ArrowLength(root);

            return longPath;
        }

        public int ArrowLength(TreeNode node) {
            if (node is null) return 0;

            int left = ArrowLength(node.left);
            int right = ArrowLength(node.right);

            int leftArrow = 0, rightArrow = 0;

            if (node.left != null && node.left.val == node.val) {
                leftArrow = left + 1;
            }

            if (node.right != null && node.right.val == node.val) {
                rightArrow = right + 1;
            }

            longPath = Math.Max(longPath, leftArrow + rightArrow);

            return Math.Max(leftArrow, rightArrow);
        }


        // another solution
        public struct NodeStruct {
            public int LeftMax { get; set; }
            public int RightMax { get; set; }
        }

        public int LongestUnivaluePath1(TreeNode root) {
            int longPath = 0;
            ArrowLength(root, ref longPath);

            return longPath;
        }

        public NodeStruct ArrowLength(TreeNode node, ref int longPath) {
            if (node is null) return new NodeStruct();

            NodeStruct leftStruct = ArrowLength(node.left, ref longPath);
            NodeStruct rightStruct = ArrowLength(node.right, ref longPath);

            var currStruct = new NodeStruct();

            if (node.left != null && node.left.val == node.val) {
                currStruct.LeftMax = Math.Max(leftStruct.LeftMax, leftStruct.RightMax) + 1;
            }

            if (node.right != null && node.right.val == node.val) {
                currStruct.RightMax = Math.Max(rightStruct.LeftMax, rightStruct.RightMax) + 1;
            }

            longPath = Math.Max(longPath, currStruct.LeftMax + currStruct.RightMax);

            return currStruct;
        }
    }
}
