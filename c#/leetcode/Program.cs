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

            int count;
            count = sol.NumSpecialEquivGroups(new string[] { "aaaa", "aaaa" });
            Console.WriteLine(count + "_" + 1);
            // // count = sol.NumSpecialEquivGroups(new string[] { "fcrokswjnxglmjouwkht", "shlgnfbgchiiytgxmamc", "hynzlifgupwmwxbrbjdq", "wkklgurjncmtfjoshxwo", "kogsokwjnjrthlfxwcmu" });
            // // Console.WriteLine(count);

            // count = sol.NumSpecialEquivGroups(new string[] { "couxuxaubw", "zsptcwcghr", "kkntvvhbcc", "nkhtcvvckb", "crcwhspgzt" });
            // Console.WriteLine(count + "_" + 3);

            // // ["a","b","c","a","c","c"]
            // count = sol.NumSpecialEquivGroups(new string[] { "c", "c", "c" });
            // Console.WriteLine(count + "_" + 1);

            // // ["ababaa","aaabaa"]
            // count = sol.NumSpecialEquivGroups(new string[] { "ababaa", "aaabaa" });
            // Console.WriteLine(count + "_" + 2);

            // // ["demp","cfhp","dzvf","ggxe","hkte","clug","nhgk","hvwj","zozr","datm","hisr","gfry","jknr","laju","emsf","duwe","ilta","gjrd","woaq","zhdm","ujmz","jalu","tkhe","gexg","hrsi","tail","ilta","xegg","srhi","clug","cgul","gexg","tehk","ulcg","xgge","cgul","hrsi","aowq","jalu","laju","vzdf","gexg","hpcf","zhdm","hfcp","zhdm","ulcg","jalu","ggxe","gexg","nkgh","hrsi","vfdz","nkgh","cgul","hpcf","hetk","zrzo","xegg","nkgh","srhi","smef","ulcg","hrsi","ggxe","ggxe","efsm","ggxe","jalu","srhi","dmzh","laju","zmdh","sfem","tehk","srhi","wqao","gknh","jalu","iatl","gexg","ugcl","nkgh","hrsi","srhi","hkte","gdrj","zozr","hisr","sihr","smef","zmdh","clug","iatl","cgul","woaq","jrnk","sihr","xegg","luja"]
            // count = sol.NumSpecialEquivGroups(new string[] { "demp", "cfhp", "dzvf", "ggxe", "hkte", "clug", "nhgk", "hvwj", "zozr", "datm", "hisr", "gfry", "jknr", "laju", "emsf", "duwe", "ilta", "gjrd", "woaq", "zhdm", "ujmz", "jalu", "tkhe", "gexg", "hrsi", "tail", "ilta", "xegg", "srhi", "clug", "cgul", "gexg", "tehk", "ulcg", "xgge", "cgul", "hrsi", "aowq", "jalu", "laju", "vzdf", "gexg", "hpcf", "zhdm", "hfcp", "zhdm", "ulcg", "jalu", "ggxe", "gexg", "nkgh", "hrsi", "vfdz", "nkgh", "cgul", "hpcf", "hetk", "zrzo", "xegg", "nkgh", "srhi", "smef", "ulcg", "hrsi", "ggxe", "ggxe", "efsm", "ggxe", "jalu", "srhi", "dmzh", "laju", "zmdh", "sfem", "tehk", "srhi", "wqao", "gknh", "jalu", "iatl", "gexg", "ugcl", "nkgh", "hrsi", "srhi", "hkte", "gdrj", "zozr", "hisr", "sihr", "smef", "zmdh", "clug", "iatl", "cgul", "woaq", "jrnk", "sihr", "xegg", "luja" });
            // Console.WriteLine(count + "_" + 21);
        }
    }

}



