

using System.Collections;
using System.Collections.Generic;
using System.Text;
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
    }

    public class SimpleObj
    {
        public TreeNode node { get; set; }
        public string remaining { get; set; }

        public SimpleObj(TreeNode node, string rem)
        {
            this.node = node;
            this.remaining = rem;
        }
    }

    public class Solution
    {
        // https://leetcode.com/problems/construct-string-from-binary-tree/
        // iterative way
        public string Tree2str(TreeNode t)
        {
            if (t == null) return "";
            StringBuilder sb = new StringBuilder();
            Dictionary<TreeNode, StringBuilder> dic = new Dictionary<TreeNode, StringBuilder>();

            Stack<SimpleObj> stack = new Stack<SimpleObj>();

            stack.Push(new SimpleObj(t, ""));

            while (stack.Count > 0)
            {
                SimpleObj currObj = stack.Pop();

                sb.Append("(" + currObj.node.val);



                if (currObj.node.right != null)
                {

                    if (currObj.node.left == null)
                    {
                        sb.Append("()");
                    }

                    SimpleObj obj = new SimpleObj(currObj.node.right, currObj.remaining + ")");
                    stack.Push(obj);
                }
                if (currObj.node.left != null)
                {

                    if (currObj.node.right == null)
                    {
                        SimpleObj obj = new SimpleObj(currObj.node.left, currObj.remaining + ")");
                        stack.Push(obj);
                    }
                    else
                    {
                        SimpleObj obj = new SimpleObj(currObj.node.left, "");
                        stack.Push(obj);
                    }

                }

                if (currObj.node.left == null && currObj.node.right == null)
                {
                    // when no childs
                    sb.Append(")").Append(currObj.remaining);
                }
            }

            sb.Remove(0, 1);
            sb.Remove(sb.Length - 1, 1);

            return sb.ToString();
        }

        // [1,2,3,4, 5, null, null, 6, 7, null, null, null, null, 1, 3]
        // https://leetcode.com/problems/construct-string-from-binary-tree/
        // recursive way
        public string Tree2strRecursive(TreeNode t)
        {
            if (t == null) return "";
            StringBuilder sb = new StringBuilder();
            PreOrderToStr(t, sb, false);

            sb.Remove(0, 1);
            sb.Remove(sb.Length - 1, 1);

            return sb.ToString();
        }

        public void PreOrderToStr(TreeNode node, StringBuilder sb, bool writeLeft)
        {
            if (node != null)
            {
                sb.Append("(").Append(node.val);
                PreOrderToStr(node.left, sb, node.right != null);
                PreOrderToStr(node.right, sb, false);
                sb.Append(")");
            }
            else if (writeLeft == true)
            {
                sb.Append("()");
            }
        }

        /**
Elegant solution
         */
        public TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null)
                return root;

            if (key < root.val)
                root.left = DeleteNode(root.left, key);
            else if (key > root.val)
                root.right = DeleteNode(root.right, key);
            else
            {
                if (root.left == null)
                    return root.right;
                else if (root.right == null)
                    return root.left;

                TreeNode minNode = findMin(root.right);
                root.val = minNode.val;
                root.right = DeleteNode(root.right, root.val);
            }

            return root;
        }


        private TreeNode findMin(TreeNode node)
        {
            while (node.left != null)
            {
                node = node.left;
            }
            return node;
        }

        public TreeNode DeleteNode1(TreeNode root, int key)
        {
            if (root == null) return null;

            TreeNode parent = FindParent(root, key);

            bool isLeft = false;
            TreeNode currNode;

            if (parent != null)
            {
                if (parent.left?.val == key)
                {
                    isLeft = true;
                    currNode = parent.left;
                }
                else
                    currNode = parent.right;
            }
            else // parent null
            {
                if (root.val == key)
                    currNode = root;
                else // not found 
                    return root;
            }

            // no child case
            if (currNode.left == null && currNode.right == null)
            {
                if (parent != null)
                {
                    if (isLeft)
                        parent.left = null;
                    else
                        parent.right = null;
                }
                else
                {
                    root = null;
                }
            }

            // one child
            else if (currNode.left == null || currNode.right == null)
            {
                TreeNode child = currNode.left != null ? currNode.left : currNode.right;
                if (parent != null)
                {
                    if (isLeft)
                        parent.left = child;
                    else
                        parent.right = child;
                }
                else
                {
                    if (root.left != null) root = root.left;
                    else root = root.right;
                }
            }


            // two childs
            else if (currNode.left != null && currNode.right != null)
            {
                // find successor
                TreeNode parentSucc = FindParentSuccessor(currNode.right, currNode);
                TreeNode succ = parentSucc.left;

                if (parentSucc == currNode)
                {
                    succ = parentSucc.right;
                }

                currNode.val = succ.val;

                if (parentSucc != currNode)
                {
                    if (succ.right != null)
                        parentSucc.left = succ.right;
                    else if (succ.right == null)
                        parentSucc.left = null;
                }
                else
                {
                    if (succ.right != null)
                        currNode.right = succ.right;
                    else
                        currNode.right = null;
                }
            }

            return root;
        }
        public TreeNode FindParentSuccessor(TreeNode curr, TreeNode parent)
        {
            if (curr.left != null)
            {
                parent = curr;
                return FindParentSuccessor(curr.left, parent);
            }
            else
            {
                return parent;
            }
        }

        public TreeNode FindParent(TreeNode node, int key)
        {
            if (node == null) return null;

            else if (node.left?.val == key || node.right?.val == key)
            {
                return node;
            }
            else
            {
                TreeNode left = FindParent(node.left, key);
                TreeNode right = FindParent(node.right, key);

                if (left != null) return left;
                else if (right != null) return right;
                else return null;
            }
        }

        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;

            List<TreeNode> list = new List<TreeNode>();
            list.Add(root);

            LevelOrderTraverse(list, result);

            return result;
        }

        public void LevelOrderTraverse(List<TreeNode> list, List<IList<int>> result)
        {
            List<TreeNode> nodesList = new List<TreeNode>();
            List<int> chunk = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                TreeNode currNode = list[i];
                chunk.Add(currNode.val);

                if (currNode.left != null)
                {
                    nodesList.Add(currNode.left);
                }
                if (currNode.right != null)
                {
                    nodesList.Add(currNode.right);
                }
            }

            result.Add(chunk);

            if (nodesList.Count > 0)
            {
                LevelOrderTraverse(nodesList, result);
            }
        }

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
