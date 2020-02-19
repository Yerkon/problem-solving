using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTree2 {

    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Solution {
        private TreeNode cur;

        // https://leetcode.com/problems/path-sum-iii/
        public int PathSum(TreeNode root, int sum) {
            if (root is null) return 0;

            int count = 0;
            TraversePathSum(root, sum, ref count);

            return count;
        }

        public void TraversePathSum(TreeNode node, int sum, ref int count) {
            if (node is null) return;

            CountPathSum(node, sum, 0, ref count);

            TraversePathSum(node.left, sum, ref count);
            TraversePathSum(node.right, sum, ref count);
        }

        public void CountPathSum(TreeNode node, int sum, int accum, ref int count) {
            if (node is null) return;

            int newAccum = accum + node.val;
            if (newAccum == sum) count++;

            CountPathSum(node.left, sum, newAccum, ref count);
            CountPathSum(node.right, sum, newAccum, ref count);
        }

        // https://leetcode.com/problems/path-sum/
        public bool HasPathSum(TreeNode root, int sum) {

            if (root is null) return false;

            int currSubstr = sum - root.val;

            if(root.left is null && root.right is null) {
                return currSubstr == 0;
            }

            return HasPathSum(root.left, currSubstr) || HasPathSum(root.right, currSubstr);            
        }

        public bool HasPathSumCheck(TreeNode node, int sum, int accum) {
            if (node is null) return false;

            int currAccum = node.val + accum;
            if(node.left is null && node.right is null) {
                return sum == currAccum;
            }

            return HasPathSumCheck(node.left, sum, currAccum) 
                    || HasPathSumCheck(node.right, sum, currAccum);
        }

        // https://leetcode.com/problems/balanced-binary-tree/
        // Time: O(N)
        public bool IsBalanced(TreeNode root) {
            
            return GetBalancedHeight(root) != -1;
        }

        public int GetBalancedHeight(TreeNode node) {
            if (node is null) return 0;

            int leftHeight = GetBalancedHeight(node.left);
            if (leftHeight == -1) return -1;

            int rightHeight = GetBalancedHeight(node.right);
            if (rightHeight == -1) return -1;

            if (Math.Abs(leftHeight - rightHeight) > 1) return -1;

            return Math.Max(leftHeight, rightHeight) + 1;
        }


        // Time: N^2
        public bool IsBalanced1(TreeNode root) {
            if (root is null) return true;

            int leftHeight = GetHeight(root.left);
            int rightHeight = GetHeight(root.right);

            return Math.Abs(leftHeight - rightHeight) <= 1 
                && IsBalanced1(root.left) 
                && IsBalanced1(root.right);
        }

        public int GetHeight(TreeNode node) {
            if (node is null) return 0;

            int leftHeight = 1 + GetHeight(node.left);
            int rightHeight = 1 + GetHeight(node.right);

            return Math.Max(leftHeight, rightHeight);
        }


        // https://leetcode.com/problems/subtree-of-another-tree/
        // recursive
        public bool IsSubtree(TreeNode s, TreeNode t) {

            return Traverse(s, t);
        }

        // iterative and recursive
        public bool IsSubtree1(TreeNode s, TreeNode t) {

            var stack = new Stack<TreeNode>();

            stack.Push(s);

            while (stack.Count > 0) {
                TreeNode currNode = stack.Pop();
                if (AreTreesEqual(currNode, t)) {
                    return true;
                } else {
                    if (currNode.left != null) stack.Push(currNode.left);
                    if (currNode.right != null) stack.Push(currNode.right);
                }
            }

            return false;
        }

        public bool Traverse(TreeNode s, TreeNode t) {
            return s != null && (AreTreesEqual(s, t) || Traverse(s.left, t) || Traverse(s.right, t));
        }

        public bool AreTreesEqual(TreeNode s, TreeNode t) {
            if (s != null && t != null) {
                return s.val == t.val && AreTreesEqual(s.left, t.left) && AreTreesEqual(s.right, t.right);
            } else if (s is null && t is null) {
                return true;
            }

            return false;
        }

       
        // https://leetcode.com/problems/symmetric-tree/
        // recursive
        public bool IsSymmetric(TreeNode root) {
            if (root is null) return true;
            if (root.left is null && root.right is null) return true;
            if (root.left is null || root.right is null) return false;


            return IsMirror(root.left, root.right);
        }

        public bool IsMirror(TreeNode node1, TreeNode node2) {

            if (node1 is null && node2 is null) return true;
            if (node1 is null || node2 is null) return false;

            return node1.val == node2.val
                && IsMirror(node1.left, node2.right)
                && IsMirror(node1.right, node2.left);
        }


        // iterative 
        public bool IsSymmetric1(TreeNode root) {
            if (root is null) return true;
            if (root.left is null && root.right is null) return true;

            if (root.left == null || root.right == null) {
                return false;
            }

            var stack1 = new Stack<TreeNode>();
            var stack2 = new Stack<TreeNode>();

            stack1.Push(root.left);
            stack2.Push(root.right);

            while (stack1.Count > 0 && stack2.Count > 0) {
                TreeNode node1 = stack1.Pop();
                TreeNode node2 = stack2.Pop();

                if (node1 != null && node2 != null) {
                    if (node1.val != node2.val) {
                        return false;
                    }

                    stack1.Push(node1.left);
                    stack1.Push(node1.right);

                    stack2.Push(node2.right);
                    stack2.Push(node2.left);

                } else if (node1 == null && node2 == null) {
                    continue;
                } else {
                    // one of null
                    return false;
                }
            }

            return true;
        }

        // https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/
        // iterative
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
            TreeNode currNode = root;

            while (currNode != null) {

                if (p.val < currNode.val && q.val < currNode.val) {
                    currNode = currNode.left;
                } else if (p.val > currNode.val && q.val > currNode.val) {
                    currNode = currNode.right;
                } else {
                    return currNode;
                }
            }

            return null;
        }

        // recursive
        public TreeNode LowestCommonAncestor1(TreeNode root, TreeNode p, TreeNode q) {
            if (p.val < root.val && q.val < root.val) {
                return LowestCommonAncestor(root.left, p, q);
            } else if (p.val > root.val && q.val > root.val) {
                return LowestCommonAncestor(root.right, p, q);
            }

            return root;
        }


        // https://leetcode.com/problems/diameter-of-binary-tree/
        public int DiameterOfBinaryTree(TreeNode root) {
            int maxDistance = 0;

            FillDiameterOfBinaryTreeList(root, ref maxDistance);

            return maxDistance;
        }

        public int FillDiameterOfBinaryTreeList(TreeNode node, ref int maxDistance) {
            if (node is null) {
                return 0;
            }

            int leftDepth = 0, rightDepth = 0;
            if (node.left != null) {
                leftDepth = 1 + FillDiameterOfBinaryTreeList(node.left, ref maxDistance);
            }

            if (node.right != null) {
                rightDepth = 1 + FillDiameterOfBinaryTreeList(node.right, ref maxDistance);
            }

            maxDistance = Math.Max(maxDistance, leftDepth + rightDepth);

            return Math.Max(leftDepth, rightDepth);

        }

        // https://leetcode.com/problems/binary-tree-paths/
        public IList<string> BinaryTreePaths(TreeNode root) {
            var list = new List<string>();

            FillBinaryTreePath(root, "", list);

            return list;
        }


        public void FillBinaryTreePath(TreeNode node, string val, List<string> list) {
            if (node is null) {
                return;
            }

            val += "->" + node.val;

            if (node.left is null && node.right is null) {
                list.Add(val.Substring(2));
                return;
            }

            FillBinaryTreePath(node.left, val, list);
            FillBinaryTreePath(node.right, val, list);
        }


        // https://leetcode.com/problems/binary-tree-level-order-traversal-ii/
        // Recursive way
        public IList<IList<int>> LevelOrderBottom(TreeNode root) {
            if (root is null) {
                return new List<IList<int>>();
            }


            var list = new List<IList<int>>();
            FillListLevelOrderBottomRec(list, root, 0);

            return list;
        }

        public void FillListLevelOrderBottomRec(List<IList<int>> list, TreeNode node, int level) {
            if (node is null) return;

            if (level >= list.Count) {
                list.Insert(0, new List<int>());
            }

            FillListLevelOrderBottomRec(list, node.left, level + 1);
            FillListLevelOrderBottomRec(list, node.right, level + 1);

            list[(list.Count - level - 1)].Add(node.val);
        }


        // Iterative way
        public IList<IList<int>> LevelOrderBottom1(TreeNode root) {
            if (root is null) {
                return new List<IList<int>>();
            }

            var stack = new Stack<IList<int>>();
            var queue = new Queue<TreeNode>();

            queue.Enqueue(root);

            while (queue.Count > 0) {

                var valueList = new List<int>();
                int queueSize = queue.Count;

                for (int i = 0; i < queueSize; i++) {
                    if (queue.Peek().left != null) queue.Enqueue(queue.Peek().left);
                    if (queue.Peek().right != null) queue.Enqueue(queue.Peek().right);

                    valueList.Add(queue.Dequeue().val);
                }

                stack.Push(valueList);
            }

            return stack.ToList();
        }


        // https://leetcode.com/problems/sum-of-left-leaves/
        public int SumOfLeftLeaves(TreeNode root) {
            if (root is null) return 0;

            return SumLeftLeavesRec(root, false);
        }

        public int SumLeftLeavesRec(TreeNode node, bool isLeft) {
            if (node is null) return 0;

            if (isLeft) {
                if (node.left == null && node.right == null) {
                    return node.val;
                }
            }

            return SumLeftLeavesRec(node.left, true) + SumLeftLeavesRec(node.right, false);
        }


        // https://leetcode.com/problems/same-tree/
        public bool IsSameTree(TreeNode p, TreeNode q) {
            if (p != null && q != null) {
                if (p.val == q.val) {
                    return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
                }
            } else if (p == null && q == null) {
                return true;
            }

            return false;
        }


        // https://leetcode.com/problems/cousins-in-binary-tree/
        public bool IsCousins(TreeNode root, int x, int y) {
            var stack = new Stack<TreeNode>();

            stack.Push(root);

            while (stack.Count > 0) {
                var tempStack = new Stack<TreeNode>();
                var tempList = new List<TreeNode>();

                while (stack.Count > 0) {
                    TreeNode currNode = stack.Pop();
                    if (currNode.left != null && currNode.right != null
                        && (currNode.left.val == x || currNode.right.val == x)
                        && (currNode.left.val == y || currNode.right.val == y)) {
                        return false;
                    }

                    if (currNode.left != null) {
                        tempList.Add(currNode.left);
                        tempStack.Push(currNode.left);
                    }
                    if (currNode.right != null) {
                        tempList.Add(currNode.right);
                        tempStack.Push(currNode.right);
                    }
                }

                bool isFirst = false;
                bool isSecond = false;
                foreach (TreeNode node in tempList) {
                    if (node.val == x) isFirst = true;
                    else if (node.val == y) isSecond = true;

                    if (isFirst && isSecond) return true;
                }

                stack = tempStack;
            }

            return false;
        }

        // https://leetcode.com/problems/minimum-absolute-difference-in-bst/
        public int GetMinimumDifference(TreeNode root) {
            int minDiff = int.MaxValue;

            var list = new List<int>();

            FillList(root, list);

            for (int i = 0; i < list.Count - 1; i++) {
                int currDiff = Math.Abs(list.ElementAt(i) - list.ElementAt(i + 1));
                minDiff = Math.Min(minDiff, currDiff);
            }

            return minDiff;
        }

        public void FillList(TreeNode node, List<int> vals) {
            if (node is null) return;

            FillList(node.left, vals);
            vals.Add(node.val);
            FillList(node.right, vals);
        }

        // https://leetcode.com/problems/convert-bst-to-greater-tree/
        public TreeNode ConvertBST(TreeNode root) {
            if (root is null) return root;

            int accum = 0;
            ConvertInOrderReverse(root, ref accum);

            return root;
        }

        public void ConvertInOrderReverse(TreeNode node, ref int accum) {
            if (node is null) return;

            ConvertInOrderReverse(node.right, ref accum);
            int temp = node.val;
            node.val += accum;
            accum += temp;

            ConvertInOrderReverse(node.left, ref accum);
        }

        public void FillInOrderReverseList(TreeNode node, List<TreeNode> nodes) {
            if (node is null) return;

            FillInOrderReverseList(node.right, nodes);
            nodes.Add(node);
            FillInOrderReverseList(node.left, nodes);
        }


        // with hashset
        // https://leetcode.com/problems/two-sum-iv-input-is-a-bst/
        public bool FindTarget(TreeNode root, int k) {
            var set = new HashSet<int>();

            return FindSum(root, set, k);
        }

        public bool FindSum(TreeNode node, HashSet<int> set, int k) {
            if (node is null) return false;

            if (set.Contains(node.val)) {
                return true;
            } else {
                set.Add(k - node.val);

                return FindSum(node.left, set, k) || FindSum(node.right, set, k);
            }
        }

        // with list

        public bool FindTarget1(TreeNode root, int k) {
            var list = new List<int>();

            FillListInOrder(root, list);

            int l = 0, r = list.Count - 1;

            while (l < r) {
                int sum = list.ElementAt(l) + list.ElementAt(r);

                if (sum == k) return true;
                else if (sum < k) {
                    l++;
                } else {
                    r--;
                }
            }

            return false;
        }

        public void FillListInOrder(TreeNode node, List<int> list) {
            if (node is null) return;

            FillListInOrder(node.left, list);
            list.Add(node.val);
            FillListInOrder(node.right, list);
        }

        // https://leetcode.com/problems/average-of-levels-in-binary-tree/
        public IList<double> AverageOfLevels(TreeNode root) {
            var averageList = new List<double>();

            if (root is null) return averageList;

            var stack = new Stack<TreeNode>();

            stack.Push(root);

            while (stack.Count > 0) {
                double avg = 0;
                var childs = new List<TreeNode>();
                int count = 0;

                while (stack.Count > 0) {
                    TreeNode currNode = stack.Pop();

                    avg += currNode.val;
                    count++;

                    if (currNode.left != null) childs.Add(currNode.left);
                    if (currNode.right != null) childs.Add(currNode.right);
                }

                avg /= (count * 1.0);

                averageList.Add(avg);

                childs.ForEach(n => stack.Push(n));
            }

            return averageList;
        }


        // https://leetcode.com/problems/trim-a-binary-search-tree/
        public TreeNode TrimBST(TreeNode root, int L, int R) {
            TrimBSTRec(root, L, R);

            return cur;
        }

        public TreeNode TrimBSTRec(TreeNode node, int L, int R) {
            if (node is null) return null;

            if (L <= node.val && node.val <= R) {
                if (cur is null) cur = node; // assign root node

                node.left = TrimBSTRec(node.left, L, R);
                node.right = TrimBSTRec(node.right, L, R);

                return node;
            } else {
                TreeNode rightNode = TrimBSTRec(node.right, L, R);
                return rightNode is null ? TrimBSTRec(node.left, L, R) : rightNode;
            }
        }


        // https://leetcode.com/problems/invert-binary-tree/
        // recursive
        public TreeNode InvertTree(TreeNode root) {
            if (root is null) return null;

            TreeNode leftNode = root.left;
            root.left = root.right;
            root.right = leftNode;

            InvertTree(root.left);
            InvertTree(root.right);

            return root;
        }

        // iterative
        public TreeNode InvertTree1(TreeNode root) {
            if (root is null) return null;

            var stack = new Stack<TreeNode>();

            stack.Push(root);

            while (stack.Count > 0) {
                TreeNode currNode = stack.Pop();

                TreeNode leftNode = currNode.left;
                currNode.left = currNode.right;
                currNode.right = leftNode;

                if (currNode.left != null) stack.Push(currNode.left);
                if (currNode.right != null) stack.Push(currNode.right);
            }

            return root;
        }

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

        //public void IncreaseBST(TreeNode node) {
        //    TreeNode leftNode = node.left;

        //    node.left = null;

        //    leftNode.
        //}




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

    }

}
