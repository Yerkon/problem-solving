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
            int count = (11 + 8) / 2;


            count = sol.CountBinarySubstrings("1100");
            Console.WriteLine(count);

           

            Console.WriteLine(count);
            count = sol.CountBinarySubstrings("110011111011011001111111111111001100101111111110011011111111110101001001111000111111011110111111010111010000111100111001110101100011101110101111111010110010111111010110110111111100111111100001111011010111111111101010100111110001000000100110100110010111111011011111011111101001100111011110111000101110011001101000101110000000110100001110011111101011010111011000001111011011110101011001010111110101111111111111010011010111110111100110101110111111111110011101101101001011011111110111001101111111111000111011000010111111111110111001111101110001011111001111011111111011100011010101110110101110101101110001110110111111011100011111010110011011111100111111011111110110111001110111011111011111110100111110011101011101111001101110010110010101011000101110011011110111111011111111111001010110010011111010101111101010110110111111011111101101100100111100111100011101011110010011001111111110010011110001111101110000100110111101101111001010111000111101000000111111000101100011011011111100011000111010110011111110001");
            Console.WriteLine(count);

            // count = sol.CountBinarySubstrings("001011");
            //   Console.WriteLine(count);
            //sol.UniqueMorseRepresentations(new string[]{"gin", "zen", "gig", "msg"});
            // sol.ReverseString(new char[] { 'h', 'e', 'l', 'l', 'o' });

            // int count;
            // count = sol.NumSpecialEquivGroups(new string[] { "aaaa", "aaaa" });
            // Console.WriteLine(count + "_" + 1);
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

            // string[] result;
            // result = sol.ReorderLogFiles(new string[]{"a1 9 2 3 1","g1 act car","zo4 4 7","ab1 off key dog","a8 act zoo"});

            // Console.WriteLine(string.Join(',', result));
        }
    }

}



