using BinaryTree;
using System;
using System.Collections.Generic;
using System.Text;

// https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/ 

namespace leetcode {
    class Convert_Sorted_Array_to_Binary_Search_Tree {
        public TreeNode SortedArrayToBST(int[] nums) {
            if (nums == null || nums.Length == 0) return null;

            return ConvertToBST(nums, 0, nums.Length - 1);
        }


        public TreeNode ConvertToBST(int[] nums, int l, int r) {
            if(l > r) {
                return null;
            }

            int middle = (l + r) / 2;
            var node = new TreeNode(nums[middle]);

            node.left = ConvertToBST(nums, l, middle - 1);
            node.right = ConvertToBST(nums, middle + 1, r);

            return node;
        }

    }
}
