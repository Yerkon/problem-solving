/*
 * @lc app=leetcode id=112 lang=csharp
 *
 * [112] Path Sum
 */

// @lc code=start

using BinaryTree;
/**
* Definition for a binary tree node.
* public class TreeNode {
*     public int val;
*     public TreeNode left;
*     public TreeNode right;
*     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
*         this.val = val;
*         this.left = left;
*         this.right = right;
*     }
* }
*/
public class Solution {
      public bool HasPathSum(TreeNode root, int sum) {

            if (root is null) return false;

            int currSubstr = sum - root.val;

            if(root.left is null && root.right is null) {
                return currSubstr == 0;
            }

            return HasPathSum(root.left, currSubstr) || HasPathSum(root.right, currSubstr);
            
        }
}
// @lc code=end

