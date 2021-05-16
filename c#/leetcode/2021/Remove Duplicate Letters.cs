using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// https://leetcode.com/problems/remove-duplicate-letters/


namespace Project._2021 {
    internal class Remove_Duplicate_Letters {
        public string RemoveDuplicateLetters(string s) {
            var uniqChars = new HashSet<char>(s);
            var uniqList = new List<string>();

            uniqList = GetUniqStr(s);

            uniqList = uniqList.Where(r => r.Length == uniqChars.Count).ToList();
          

            return uniqList.OrderBy(r => r).FirstOrDefault(); 
        }

        // "ecbacba"
        public List<string> GetUniqStr(string s) {
            var uniqStrSet = new HashSet<string>();
         
            for (int i = 0; i < s.Length; i++) {

                StringBuilder sb = new StringBuilder(s[i].ToString());
                var set = new HashSet<char>() { s[i] };

                // inner 2
                for (int j = i + 1; j < s.Length; j++) {
                    if(set.Add(s[j])) {
                        sb.Append(s[j]);
                    }

                    // innnr 3
                    for (int k = j + 1; k < s.Length; k++) {
                        if(set.Add(s[k])) {
                            sb.Append(s[k]);
                        }
                    }

                    // end of 
                    Console.WriteLine(sb.ToString());
                    uniqStrSet.Add(sb.ToString());

                } // 2
            }

            return uniqStrSet.ToList();
        }
    }
}
