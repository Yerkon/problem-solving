using BinaryTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode {
    class Diameter_of_Binary_Tree {
        public class Solution {

            int maxDistance = 0;
            public int DiameterOfBinaryTree(TreeNode root) {               
                GetMaxDiameter(root);

                return maxDistance;
            }

            public int GetMaxDiameter(TreeNode node) {
                if (node == null) return 0;

                int left = GetMaxDiameter(node.left);
                int right = GetMaxDiameter(node.right);

                maxDistance = Math.Max(maxDistance, left + right);

                return Math.Max(left, right) + 1;
            }
        }
    }
}
