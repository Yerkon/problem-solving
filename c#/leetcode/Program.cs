using System;
using System.Collections.Generic;
using StringTasks;

namespace leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();
            string paragraph = "Bob hit a ball" + Environment.NewLine +
                                "the hit BALL flew far after it was hit. Bob hit a ball" + Environment.NewLine +
                                "the hit BALL flew far after it was hit.Bob hit a ball" + Environment.NewLine +
                                "the hit BALL flew far after it was hit. ";

            //paragraph = "a, a, a, a, b,b,b,c, c";
            string result = sol.MostCommonWord(paragraph, new string[] { "hit" });
            Console.WriteLine(result);
        }
    }

}



