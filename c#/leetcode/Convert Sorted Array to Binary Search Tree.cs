using BinaryTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode {
    class Convert_Sorted_Array_to_Binary_Search_Tree {
        public TreeNode SortedArrayToBST(int[] nums) {
            

            return ConvertToBST(nums, 0, nums.Length/2, nums.Length - 1);
        }


        public TreeNode ConvertToBST(int[] nums, int l, int m, int r) {

            var node = new TreeNode(nums[m]);

            node.left = ConvertToBST(nums, l, (l + m) / 2, m);
            node.right = ConvertToBST(nums, m + 1, (m + r) / 2, r);

            return node;
            
        }

        
    }
}
