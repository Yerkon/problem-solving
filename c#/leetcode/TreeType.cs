using System;
using System.Collections.Generic;

namespace Tree {
    public class Node {
        public int val;
        public IList<Node> children;

        public Node() { }
        public Node(int _val, IList<Node> _children) {
            val = _val;
            children = _children;
        }
    }

    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Solution {

        // https://leetcode.com/problems/sum-of-root-to-leaf-binary-numbers/
        public int SumRootToLeaf(TreeNode root) {
            var binaryList = new List<string>();
            int sum = 0;

            GetAllPathBinary(root, "", binaryList);

            binaryList.ForEach(binaryStr => {

                //Console.WriteLine(binaryStr);

                sum += Convert.ToInt32(binaryStr, 2);
            });

            return sum;
        }

        public void GetAllPathBinary(TreeNode node, string currBinary, List<string> binaryList) {
            if (node is null) {
                return;
            }

            currBinary += node.val;

            if (node.left is null && node.right is null) {
                binaryList.Add(currBinary);
                return;
            }

            GetAllPathBinary(node.left, currBinary, binaryList);
            GetAllPathBinary(node.right, currBinary, binaryList);
        }


        // https://leetcode.com/problems/maximum-depth-of-binary-tree/
        public int MaxDepth(TreeNode root) {
            if (root is null) return 0;
            int maxDepth = 0;

            var stack = new Stack<TreeNode>();
            stack.Push(root);

            while (stack.Count > 0) {
                var list = new List<TreeNode>();

                while (stack.Count > 0) {
                    TreeNode currNode = stack.Pop();
                    list.Add(currNode);
                }

                list.ForEach(n => {
                    if (n.left != null) stack.Push(n.left);
                    if (n.right != null) stack.Push(n.right);
                });

                maxDepth++;
            }

            return maxDepth;
        }


        // https://leetcode.com/problems/leaf-similar-trees/
        public bool LeafSimilar(TreeNode root1, TreeNode root2) {
            var leafs1 = new List<TreeNode>();
            var leafs2 = new List<TreeNode>();

            GetLeafs(root1, leafs1);
            GetLeafs(root2, leafs2);

            if (leafs1.Count == leafs2.Count) {
                for (int i = 0; i < leafs1.Count; i++) {
                    if (leafs1.ElementAt(i).val != leafs2.ElementAt(i).val) {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        public void GetLeafs(TreeNode node, List<TreeNode> leafs) {
            if (node == null) return;

            GetLeafs(node.left, leafs);

            if (node.left == null && node.right == null) {
                leafs.Add(node);
            }

            GetLeafs(node.right, leafs);
        }

        // https://leetcode.com/problems/increasing-order-search-tree/
        private TreeNode cur;
        public TreeNode IncreasingBST(TreeNode root) {
            var ans = new TreeNode(0);
            cur = ans;
            InOrderSearch(root);

            return ans.right;
        }

        public void InOrderSearch(TreeNode node) {
            if (node is null) return;

            InOrderSearch(node.left);

            node.left = null;

            cur.right = node;
            cur = node;

            InOrderSearch(node.right);

        }

        public void IncreaseBST(TreeNode node) {
            TreeNode leftNode = node.left;

            node.left = null;

            leftNode.
        }

        // https://leetcode.com/problems/maximum-depth-of-n-ary-tree/

        public int MaxDepth(Node root) {

            if (root is null) return 0;

            return GetMaxDepth(root, 1);
        }

        public int GetMaxDepth(Node root, int depth) {
            if (root.children.Count == 0) {
                return depth;
            }

            depth++;
            int maxDepth = depth;
            foreach (Node child in root.children) {
                maxDepth = Math.Max(GetMaxDepth(child, depth), maxDepth);
            }

            return maxDepth;
        }

        public int MaxDepth1(Node root) {

            if (root is null) return 0;

            int depth = 0;
            var stack = new Stack<Node>();
            stack.Push(root);

            while (stack.Count > 0) {
                var list = new List<Node>();
                while (stack.Count > 0) {
                    Node curr = stack.Pop();

                    list.AddRange(curr.children);
                }

                list.ForEach(r => stack.Push(r));

                depth++;
            }


            return depth;
        }


        // https://leetcode.com/problems/range-sum-of-bst/
        public int RangeSumBST(TreeNode root, int L, int R) {
            return DfsRange(root, L, R);
        }

        public int DfsRange(TreeNode node, int l, int r) {
            if (node is null) {
                return 0;
            }

            int sum = 0;

            if (l <= node.val && node.val <= r) {
                sum = node.val;
            }

            return sum + DfsRange(node.left, l, r) + DfsRange(node.right, l, r);

        }


        public IList<IList<int>> LevelOrder(Node root) {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null) {
                return result;
            }

            var nodes = new List<Node>() { root };

            result.Add(nodes.ConvertAll(node => node.val));
            BFS(result, nodes);

            return result;
        }

        public void BFS(IList<IList<int>> result, List<Node> nodes) {
            var valuesArr = new List<int>();
            var nodesArr = new List<Node>();

            for (int i = 0; i < nodes.Count; i++) {
                var currChildren = nodes[i].children as List<Node>;
                valuesArr.AddRange((currChildren.ConvertAll(child => child.val)));
                nodesArr.AddRange(currChildren);
            }

            result.Add(valuesArr);
            if (nodesArr.Count == 0) return;

            BFS(result, nodesArr);
        }

        // iterative way
        public List<int> Preorder(Node root) {
            var tempStack = new Stack<Node>();
            var resList = new List<int>();

            if (root == null) return resList;

            tempStack.Push(root);

            while (tempStack.Count > 0) {
                Node currNode = tempStack.Pop();
                resList.Add(currNode.val);

                for (int i = currNode.children.Count - 1; i >= 0; i--) {
                    Node currChild = currNode.children[i];
                    tempStack.Push(currChild);
                }
            }

            return resList;
        }

        // recursive way
        public IList<int> Preorder1(Node root) {
            var result = new List<int>();
            if (root == null) return result;

            result.Add(root.val);

            for (int i = 0; i < root.children.Count; i++) {
                Node currNode = root.children[i];
                this.Preorder(currNode);
            }

            return result;
        }
        /**
        with stack
         */
        public int[] Postorder(Node root) {
            var stackResult = new Stack<int>();
            var tempStack = new Stack<Node>();

            if (root == null) {
                return stackResult.ToArray();
            }

            tempStack.Push(root);

            while (tempStack.Count > 0) {
                Node currNode = tempStack.Pop();
                for (int i = 0; i < currNode.children.Count; i++) {
                    Node childNode = currNode.children[i];
                    tempStack.Push(childNode);
                }

                stackResult.Push(currNode.val);
            }

            return stackResult.ToArray();
        }

        /**
        with list
        */
        public List<int> Postorder1(Node root) {
            var listResult = new List<int>();

            if (root == null) {
                return listResult;
            }

            Node parentNode = null;
            Node currNode = root;

            while (currNode != null) {
                if (currNode.children.Count == 0) {
                    // there is no child
                    if (currNode == root) {
                        listResult.Add(currNode.val);
                        currNode = null;
                        continue;
                    }

                    listResult.Add(currNode.val);
                    parentNode.children.Remove(currNode);

                    // start from beginning
                    currNode = root;
                } else {
                    parentNode = currNode;
                    currNode = currNode.children[0];
                }

            }

            return listResult;
        }

        /**
        Recursive solution
         */
        public void ProceedPostOrder(Node root, List<int> result) {

            foreach (Node child in root.children) {
                ProceedPostOrder(child, result);
                result.Add(child.val);
            }
        }

        public Node GetTest1() {
            var root = new Node(1, new List<Node>());

            var child1 = new Node(3, new List<Node>());
            var child2 = new Node(2, new List<Node>());
            var child3 = new Node(4, new List<Node>());

            child1.children.Add(new Node(5, new List<Node>()));
            child1.children.Add(new Node(6, new List<Node>()));

            root.children = new List<Node>(){
                child1,
                child2,
                child3
            };

            return root;
        }

        public List<int> GetMock1() {
            return new List<int>() { 5, 6, 3, 2, 4, 1 };
        }
        public Node getTest2() {

            var root = new Node(1, new List<Node>());

            var child1 = new Node(10, new List<Node>());
            var child2 = new Node(3, new List<Node>());

            child1.children.Add(new Node(5, new List<Node>()));
            child1.children.Add(new Node(0, new List<Node>()));

            child2.children.Add(new Node(6, new List<Node>()));


            root.children = new List<Node>(){
                child1,
                child2,
            };

            return root;
        }

        public List<int> GetMock2() {
            return new List<int>(){
                5,0,10,6,3,1
            };
        }
    }

}
