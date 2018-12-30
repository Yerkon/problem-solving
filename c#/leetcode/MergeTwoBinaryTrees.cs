

using System.Collections.Generic;
/**
* Definition for a binary tree node.
* public class TreeNode {
*     public int val;
*     public TreeNode left;
*     public TreeNode right;
*     public TreeNode(int x) { val = x; }
* }
*/
namespace MergeTwoBinaryTrees
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Solution
    {
        public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null) return null;
            else if (t1 != null) return t1;
            else if (t2 != null) return t2;
            
            TreeNode mergedNode = new TreeNode(0);
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(t1);
            stack.Push(t2);
            stack.Push(mergedNode);

            while (stack.Count > 0)
            {
                TreeNode currNode = stack.Pop();
                TreeNode rightTreeNode = stack.Pop();
                TreeNode leftTreeNode = stack.Pop();

                MergeTwoNodes(leftTreeNode, rightTreeNode, currNode);
                if (currNode == null) continue;

                if (leftTreeNode?.left != null || rightTreeNode?.left != null)
                {
                    currNode.left = new TreeNode(0);
                    stack.Push(leftTreeNode?.left);
                    stack.Push(rightTreeNode?.left);
                    stack.Push(currNode.left);
                }

                if (leftTreeNode?.right != null || rightTreeNode?.right != null)
                {
                    currNode.right = new TreeNode(0);
                    stack.Push(leftTreeNode?.right);
                    stack.Push(rightTreeNode?.right);
                    stack.Push(currNode.right);
                }
            }

            return mergedNode;
        }

        public TreeNode MergeTwoNodes(TreeNode t1, TreeNode t2, TreeNode resNode)
        {
            if (t1 != null && t2 != null)
            {
                resNode.val = t1.val + t2.val;
            }
            else if (t1 != null)
            {
                resNode.val = t1.val;
            }
            else if (t2 != null)
            {
                resNode.val = t2.val;
            }
            else
            {
                resNode = null;
            }

            return resNode;
        }

        /**
        Recursive way
         */
        public void MergeNodes(TreeNode t1, TreeNode t2, TreeNode currNode)
        {
            if (t1 != null && t2 != null)
            {
                currNode.val = t1.val + t2.val;
            }
            else if (t1 != null)
            {
                currNode.val = t1.val;
            }
            else if (t2 != null)
            {
                currNode.val = t2.val;
            }
            else
            {
                return;
            }

            if ((t1 != null && t1.left != null) || (t2 != null && t2.left != null))
            {
                currNode.left = new TreeNode(0);
                MergeNodes(t1?.left, t2?.left, currNode.left);
            }
            if ((t1 != null && t1.right != null) || (t2 != null && t2.right != null))
            {
                currNode.right = new TreeNode(0);
                MergeNodes(t1?.right, t2?.right, currNode.right);
            }
        }

        public TreeNode GetTest1()
        {
            TreeNode node = new TreeNode(3);
            node.left = new TreeNode(4);
            node.right = new TreeNode(5);

            node.left.left = new TreeNode(5);
            node.left.right = new TreeNode(4);

            node.right.right = new TreeNode(7);

            return node;
        }

        public TreeNode[] GetMock1()
        {
            TreeNode node1 = new TreeNode(1);

            node1.left = new TreeNode(3);
            node1.left.left = new TreeNode(5);
            node1.right = new TreeNode(2);

            TreeNode node2 = new TreeNode(2);
            node2.left = new TreeNode(1);
            node2.right = new TreeNode(3);
            node2.left.right = new TreeNode(4);
            node2.right.right = new TreeNode(7);

            TreeNode[] treeArr = new TreeNode[2];
            treeArr.SetValue(node1, 0);
            treeArr.SetValue(node2, 1);

            return treeArr;
        }
    }
}
