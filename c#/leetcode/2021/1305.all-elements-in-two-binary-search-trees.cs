using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
/*
 * @lc app=leetcode id=1305 lang=csharp
 *
 * [1305] All Elements in Two Binary Search Trees
 */

// @lc code=start
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
    public IList<int> GetAllElements(TreeNode root1, TreeNode root2) {
        var res = new List<int>();
    
        var list1 = new List<int>();
        var list2 = new List<int>();
        Dfs(root1, list1);
        Dfs(root2, list2);

        // Print(leftList);
        // Print(rightList);

        int it1 = 0, it2 = 0;

        while (it1 < list1.Count && it2 < list2.Count)
        {
            if(list1[it1] <= list2[it2]) {
                res.Add(list1[it1++]);
            } else {
                res.Add(list2[it2++]);
            }
        }

        if(it1 < list1.Count) {
            res.AddRange(list1.GetRange(it1, list1.Count - it1));
        } else if(it2 < list2.Count) {
            res.AddRange(list2.GetRange(it2, list2.Count - it2));
        }

        return res;
    }

    public void Print(List<int> list) {
         foreach (var item in list)
        {
            Console.Write(item  + " ");
        }
        Console.WriteLine();
    }

    public void Dfs(TreeNode root, List<int> list) {
        if(root is null) return;

        Dfs(root.left, list);
        list.Add(root.val);
        Dfs(root.right, list);

    }
    
}
// @lc code=end

