

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
namespace BinaryTree
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }

        public void AddNode(int val)
        {
            if (val < this.val)
            {
                if (this.left == null)
                {
                    this.left = new TreeNode(val);
                }
                else
                {
                    this.left.AddNode(val);
                }
            }
            else
            {
                if (this.right == null)
                {
                    this.right = new TreeNode(val);

                }
                else
                {
                    this.right.AddNode(val);
                }
            }
        }
    }

    public class Solution
    {

        // iterative way
        public IList<int> PostorderTraversal(TreeNode root)
        {
            Stack<int> resStack = new Stack<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            if (root == null) return resStack.ToArray();

            TreeNode currNode = root;
            while (stack.Count > 0 || currNode != null)
            {
                while (currNode != null)
                {
                    resStack.Push(currNode.val);
                    if (currNode.left != null)
                    {
                        stack.Push(currNode.left);
                    }

                    currNode = currNode.right;
                }

                if (stack.Count > 0)
                    currNode = stack.Pop();
            }


            return resStack.ToArray();
        }


        /**
        recursive way
         */
        public void TraversePostOrder(TreeNode node, List<int> res)
        {
            if (node.left != null)
            {
                TraversePostOrder(node.left, res);
            }

            if (node.right != null)
            {
                TraversePostOrder(node.right, res);
            }

            res.Add(node.val);
        }
        public IList<int> PreorderTraversal(TreeNode root)
        {
            List<int> res = new List<int>();
            if (root == null) return res;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode currNode = root;

            while (stack.Count > 0 || currNode != null)
            {
                while (currNode != null)
                {
                    res.Add(currNode.val);

                    if (currNode.right != null)
                    {
                        stack.Push(currNode.right);
                    }

                    currNode = currNode.left;
                }

                if (stack.Count > 0)
                {
                    currNode = stack.Pop();
                }
            }

            return res;
        }

        /**
        Recursive way
         */
        public void TraversePreOrder(TreeNode node, List<int> res)
        {
            res.Add(node.val);

            if (node.left != null)
            {
                TraversePreOrder(node.left, res);
            }
            if (node.right != null)
            {
                TraversePreOrder(node.right, res);
            }
        }

        // iterative way with list
        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> list = new List<int>();
            if (root == null) return list;

            Stack<TreeNode> tempStack = new Stack<TreeNode>();
            TreeNode currNode = root;

            while (tempStack.Count > 0 || currNode != null)
            {
                while (currNode != null)
                {
                    tempStack.Push(currNode);
                    currNode = currNode.left;
                }

                currNode = tempStack.Pop();
                list.Add(currNode.val);

                currNode = currNode.right;
            }

            return list;
        }


        // iterative way with stack
        public IList<int> InorderTraversalWithStack(TreeNode root)
        {
            Stack<int> stack = new Stack<int>();
            if (root == null) return stack.ToArray();

            Stack<TreeNode> tempStack = new Stack<TreeNode>();
            tempStack.Push(root);

            while (tempStack.Count > 0)
            {
                TreeNode currNode = tempStack.Peek();

                while (currNode.right != null)
                {
                    tempStack.Push(currNode.right);
                    currNode = currNode.right;
                }

                currNode = tempStack.Pop();

                while (tempStack.Count > 0 && currNode.left == null)
                {
                    stack.Push(currNode.val);
                    currNode = tempStack.Pop();
                }

                if (currNode.left != null)
                {
                    stack.Push(currNode.val);
                    tempStack.Push(currNode.left);
                }

                if (tempStack.Count == 0)
                {
                    stack.Push(currNode.val);
                }
            }

            return stack.ToArray();
        }

        public int FindSecondMinimumValue(TreeNode root)
        {
            if (root == null) return -1;
            return TraverseSecondMin(root, root.val);
        }

        public int TraverseSecondMin(TreeNode node, int minValue)
        {
            if (node == null) return -1;
            if (node.val > minValue)
            {
                return node.val;
            }
            else
            {
                int leftMin = TraverseSecondMin(node.left, minValue);
                int rightMin = TraverseSecondMin(node.right, minValue);
                if (leftMin > minValue && (rightMin == -1 || leftMin <= rightMin))
                {
                    return leftMin;
                }
                else if (rightMin > minValue && (leftMin == -1 || rightMin < leftMin))
                {
                    return rightMin;
                }
                else
                {
                    return -1;
                }

            }

            //return -1;
        }
        public TreeNode InsertIntoBST(TreeNode root, int val)
        {
            if (root == null) return new TreeNode(val);

            if (val < root.val)
            {
                root.left = InsertIntoBST(root.left, val);
            }
            else
            {
                root.right = InsertIntoBST(root.right, val);
            }

            return root;
        }


        public TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null || root.val == val) return root;
            else if (val < root.val)
            {
                return SearchBST(root.left, val);
            }
            else
            {
                return SearchBST(root.right, val);
            }
        }

        public bool IsUnivalTree(TreeNode root)
        {
            if (root == null) return true;

            return isUnivalTraverse(root, root.val);
        }

        public bool isUnivalTraverse(TreeNode node, int value)
        {
            if (node == null)
            {
                return true;
            }
            else if (node != null && node.val != value)
            {
                return false;
            }
            else
            {
                return isUnivalTraverse(node.left, value)
                && isUnivalTraverse(node.right, value);
            }
        }

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
