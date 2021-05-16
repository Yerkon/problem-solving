using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*
 * @lc app=leetcode id=310 lang=csharp
 *
 * [310] Minimum Height Trees
 */

// @lc code=start
public class Solution {
    public IList<int> FindMinHeightTrees(int n, int[][] edges) {
        var result = new List<int>();
        var adjList = new List<List<int>>();

        for (int i = 0; i < n; i++) {
            adjList.Add(new List<int>());
        }

        for (int i = 0; i < edges.Length; i++) {
            int[] edge = edges[i];

            adjList[edge[0]].Add(edge[1]);
            adjList[edge[1]].Add(edge[0]);
        }

        int[] heights = new int[n];
        int minHeight = int.MaxValue;

        for (int i = 0; i < n; i++) {
           heights[i] = GetHeightForNode(i, adjList, n); 
           minHeight = Math.Min(minHeight, heights[i]);
        }

        for (int i = 0; i < heights.Length; i++)
        {
            if(heights[i] == minHeight) {
                result.Add(i);
            }
        }

        return result;
    }
    public int GetHeightForNode(int node, List<List<int>> adjList, int n) {
        bool[] visited = new bool[n];
        int[] distance = new int[n];
        int maxDistance = 0;
        Queue<int> q = new Queue<int>();

        visited[node] = true;
        distance[node] = 0;
        q.Enqueue(node);

        while (q.Count > 0) {
            int currNode = q.Dequeue();

            // iterate over direct connections
            foreach (int u in adjList[currNode]) {
                if (visited[u]) continue;

                visited[u] = true;
                distance[u] = distance[currNode] + 1;

                maxDistance = Math.Max(maxDistance, distance[u]);
                q.Enqueue(u);
            }
        }

        return maxDistance;
    }
}
// @lc code=end