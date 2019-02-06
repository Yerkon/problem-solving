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
            //sol.UniqueMorseRepresentations(new string[]{"gin", "zen", "gig", "msg"});
            sol.ReverseString(new char[] { 'h', 'e', 'l', 'l', 'o' });

        }
    }

}



