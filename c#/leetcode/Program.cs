using System;
using System.Collections.Generic;
using StringTasks;

namespace leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            
            string a = "abc";
            string b = a.Substring(1); 
            Console.WriteLine(b);
            
            Solution sol = new Solution();
            int res =  sol.NFact(3);
            Console.WriteLine(res);

            // int[] input = new int[]{
            //     5, 1, 10
            // };

            // TreeNode root = new TreeNode(input[0]);

            // for (int i = 1; i < input.Length; i++)
            // {
            //     sol.InsertIntoBST(root, input[i]);
            // }

            // sol.DeleteNode(root, 5);
            // Console.WriteLine(root);

        }
    }

}



