using BinaryTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode {
    class Construct_Binary_Search_Tree_from_Preorder_Traversal {
        public TreeNode BstFromPreorder(int[] preorder) {
            if (preorder.Length == 0) return null;

            return ConstructPreOrder(preorder, 0);
        }

        public TreeNode ConstructPreOrder(int[] preorder, int i) {
            if(i == preorder.Length || preorder[i] == -1) {
                return null;
            }
            
            var node = new TreeNode(preorder[i]);
          
            int rightIndex = -1;
            int leftIndex = -1;

            for (int k = i + 1; k < preorder.Length; k++) {
                if(leftIndex == -1 && preorder[k] < preorder[i]) {
                    leftIndex = k;

                } else if(preorder[k] > preorder[i]) {
                    rightIndex = k;
                    break;
                }
            }

            if(rightIndex != -1) {
                node.right = ConstructPreOrder(preorder, rightIndex);
            }

            if(leftIndex != -1) {
                node.left = ConstructPreOrder(preorder, leftIndex);
            }

            preorder[i] = -1;

            return node;
        }

      
        /*
         * node
         * node.left
         * node.right
         */
    }
}
