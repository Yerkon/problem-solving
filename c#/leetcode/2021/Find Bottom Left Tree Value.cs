using BinaryTree;
using System;
using System.Collections.Generic;
using System.Text;

// https://leetcode.com/problems/find-bottom-left-tree-value/

namespace Project._2021 {
    class Find_Bottom_Left_Tree_Value {
        public int FindBottomLeftValue(TreeNode root) {
            List<int> values = new List<int>();

            FindLeftValue(root, 0, values);

            return values[values.Count - 1];
        }

        public void FindLeftValue(TreeNode node, int level, List<int> values) {
            if (node is null) return;
            
            if(values.Count < level + 1) {
                values.Add(0);
            }

            values[level] = node.val;

            // from right to left

            FindLeftValue(node.right, level + 1, values);
            FindLeftValue(node.left, level + 1, values);
        }
    }
}
