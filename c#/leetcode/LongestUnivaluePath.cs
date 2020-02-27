using BinaryTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace LongestUnivaluePath {
    public class Solution {

        // https://leetcode.com/problems/longest-univalue-path/
        public struct NodeStruct {
            public int LeftMax { get; set; }
            public int RightMax { get; set; }
        }

        public int LongestUnivaluePath(TreeNode root) {
            int longPath = 0;
            CalLongestUnivaluePath(root, ref longPath);

            return longPath;
        }

        public NodeStruct CalLongestUnivaluePath(TreeNode node, ref int longPath) {
            if (node is null) return new NodeStruct();

            NodeStruct leftStruct = CalLongestUnivaluePath(node.left, ref longPath);
            NodeStruct rightStruct = CalLongestUnivaluePath(node.right, ref longPath);

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
