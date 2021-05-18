using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
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
        var distance = new List<int[]>();
        
        for (int i = 0; i < n; i++) {
            adjList.Add(new List<int>());

            int[] items = new int[n];
            for (int k = 0; k < n; k++)
            {
                items[k] = -1;           
            }
            distance.Add(items);
        }

        for (int i = 0; i < edges.Length; i++) {
            int[] edge = edges[i];

            adjList[edge[0]].Add(edge[1]);
            adjList[edge[1]].Add(edge[0]);
        }

        int[] heights = new int[n];
        int minHeight = int.MaxValue;
      
        for (int i = 0; i < n; i++) {
           heights[i] = GetHeightForNode(i, adjList, n, distance); 
           minHeight = Math.Min(minHeight, heights[i]);
        }

        // for (int i = 0; i < distance.Count; i++)
        // {
        //     Console.WriteLine($"Distance from {i} to ");
        //     for (int j = 0; j < distance[i].Length; j++)
        //     {
        //         Console.WriteLine($"{j} = {distance[i][j]}");
        //     }
        // }

        for (int i = 0; i < heights.Length; i++)
        {
           // Console.WriteLine($"node: {i}: " + heights[i]);
            if(heights[i] == minHeight) {
                result.Add(i);
            }
        }

        return result;
    }


      public int GetHeightForNode(int node, List<List<int>> adjList, int n, List<int[]> gDistance) {
        bool[] visited = new bool[n];
        int maxDistance = 0;
        Queue<int> q = new Queue<int>();

        visited[node] = true;
        gDistance[node][node] = 0;
        q.Enqueue(node);
        
        while (q.Count > 0) {
            int currNode = q.Dequeue();

            // iterate over direct connections
            foreach (int u in adjList[currNode]) {
                if (visited[u]) continue;

                if(gDistance[node][u] != -1) {
                    visited[u] = true;
                    maxDistance = Math.Max(maxDistance, gDistance[node][u]);
                    q.Enqueue(u);
                    continue;
                } else if(gDistance[u][node] != -1) {
                    visited[u] = true;
                     maxDistance = Math.Max(maxDistance, gDistance[u][node]);
                    q.Enqueue(u);
                    continue;
                }
                
                visited[u] = true;
             
                gDistance[node][u] = gDistance[node][currNode] + 1;
                gDistance[u][node] = gDistance[node][currNode] + 1;

                maxDistance = Math.Max(maxDistance, gDistance[node][u]);
                q.Enqueue(u);
            }
        }

        return maxDistance;
    }

 public int[] GetDistanceForNode(int node, List<List<int>> adjList, int n) {
        bool[] visited = new bool[n];
        int[] distance = new int[n];
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

                q.Enqueue(u);
            }
        }

         for (int i = 0; i < distance.Length; i++)
        {
            Console.WriteLine($"Distance from {node} to {i} : {distance[i]}");
        } 

        return distance;
    }

  
}
// @lc code=end

