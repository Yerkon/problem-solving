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

            Solution sol = new Solution();
            //sol.UniqueMorseRepresentations(new string[]{"gin", "zen", "gig", "msg"});
            // sol.ReverseString(new char[] { 'h', 'e', 'l', 'l', 'o' });
            int count = sol.NumSpecialEquivGroups(new string[] { "abc" });

            Console.WriteLine(count);
        }
    }

}



