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
            for (int k = 0; k < n; k++) {
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

        for (int i = 0; i < distance.Count; i++) {
            for (int j = 0; j < distance[i].Length; j++) {

                if(distance[i][j] == -1) {
                     FillDistanceForNode(j, adjList, n, distance);
                }

                heights[i] = Math.Max(heights[i], distance[i][j]);
            }

             minHeight = Math.Min(minHeight, heights[i]);
        }

        // for (int i = 0; i < heights.Length; i++)
        // {
        //     Console.WriteLine($"Height {i}: {heights[i]}");
        // }
       
        // for (int i = 0; i < distance.Count; i++) {
        //     Console.WriteLine($"Distance from {i} to ");
        //     for (int j = 0; j < distance[i].Length; j++) {
        //         Console.WriteLine($"{j} = {distance[i][j]}");
        //     }
        // }

        for (int i = 0; i < heights.Length; i++) {
            // Console.WriteLine($"node: {i}: " + heights[i]);
            if (heights[i] == minHeight) {
                result.Add(i);
            }
        }

        return result;
    }


    public void FillDistanceForNode(int node, List<List<int>> adjList, int n, List<int[]> gDistance) {
        bool[] visited = new bool[n];
        Queue<int> q = new Queue<int>();
        visited[node] = true;
        gDistance[node][node] = 0;
        q.Enqueue(node);

        while (q.Count > 0) {
            int currNode = q.Dequeue();// 0, 1, 2, 3
            gDistance[currNode][currNode] = 0;
            
            // iterate over direct connections
            foreach (int u in adjList[currNode]) { // 1, [2, 3]
                if (visited[u]) continue;

                visited[u] = true; // 0, 1, 2, 3
                gDistance[node][u] = gDistance[node][currNode] + 1; // (0-1=1), (0-2=2), (0-3=2)
                gDistance[u][node] = gDistance[node][currNode] + 1; // (1-0=1), (2-0=2), (3-0=2)
                gDistance[currNode][u] = 1;
                gDistance[u][currNode] = 1;

                q.Enqueue(u); // 1, 2, 3
            }
        }
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

        for (int i = 0; i < distance.Length; i++) {
            Console.WriteLine($"Distance from {node} to {i} : {distance[i]}");
        }

        return distance;
    }


}
// @lc code=end

