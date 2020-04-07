using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode {
    internal class Group_Anagrams {

        // better solution on Java
        //public List<List<String>> groupAnagrams(String[] strs) {
        //    if (strs.length == 0) return new ArrayList();
        //    Map<String, List> ans = new HashMap<String, List>();
        //    int[] count = new int[26];
        //    for (String s : strs) {
        //        Arrays.fill(count, 0);
        //        for (char c : s.toCharArray()) count[c - 'a']++;

        //        StringBuilder sb = new StringBuilder("");
        //        for (int i = 0; i < 26; i++) {
        //            sb.append('#');
        //            sb.append(count[i]);
        //        }
        //        String key = sb.toString();
        //        if (!ans.containsKey(key)) ans.put(key, new ArrayList());
        //        ans.get(key).add(s);
        //    }
        //    return new ArrayList(ans.values());
        //}

        // Time: O(NKLogK). K - max size of word in strs, N - strs.length
        // Space: O(NK)
        public IList<IList<string>> GroupAnagrams(string[] strs) {
            var sortedDic = new Dictionary<string, IList<string>>();

            for (int i = 0; i < strs.Length; i++) {
                IOrderedEnumerable<char> orderedArr = strs[i].OrderBy(r => r);
                var sb = new StringBuilder();
                
                foreach (var item in orderedArr) {
                    sb.Append(item);
                }
               
                string sorted = sb.ToString();

                if(!sortedDic.ContainsKey(sorted)) {
                    sortedDic.Add(sorted, new List<string>() { });
                } 

                sortedDic[sorted].Add(strs[i]);
            }

            return sortedDic.Values.ToList();
        }

        

        public IList<IList<string>> GroupAnagrams3(string[] strs) {

            var listOfList = new List<IList<string>>();
            if (strs.Length == 0) return listOfList;

            //  var listOfSet = new List<HashSet>
            var anagramList = new List<string>() { strs[0] };
            listOfList.Add(new List<string>() { strs[0] });

            for (int i = 1; i < strs.Length; i++) {

                bool anagramFound = false;

                for (int j = 0; j < anagramList.Count; j++) {
                    if (isAnagram(strs[i], anagramList[j])) {
                        listOfList[j].Add(strs[i]);

                        anagramFound = true;
                        break;
                    }
                }

                if (!anagramFound) {
                    anagramList.Add(strs[i]);
                    var list = new List<string>() { strs[i] };
                    listOfList.Add(list);
                }
            }

            return listOfList;
        }

        public bool isAnagram(string str1, string str2) {
            if (str1.Length != str2.Length) return false;

            int[] arr = new int[26];

            for (int i = 0; i < str1.Length; i++) {
                char l1 = str1[i];
                char l2 = str2[i];

                arr[l1 - 'a']++;
                arr[l2 - 'a']--;
            }

            for (int i = 0; i < arr.Length; i++) {
                if (arr[i] != 0) return false;
            }

            return true;
        }

        //public bool isAnagram(string str1, string str2) {
        //    if (str1.Length != str2.Length) return false;

        //    var dic = new Dictionary<char, int>();

        //    for (int i = 0; i < str1.Length; i++) {
        //        char l1 = str1[i];
        //        char l2 = str2[i];

        //        dic[l1] = dic.GetValueOrDefault(l1, 0) + 1;
        //        dic[l2] = dic.GetValueOrDefault(l2, 0) - 1;
        //    }

        //    foreach (var key in dic.Keys) {
        //        if (dic[key] != 0) return false;
        //    }

        //    return true;
        // }


        // by sort
        public IList<IList<string>> GroupAnagrams2(string[] strs) {
            var listOfList = new List<IList<string>>();
            var strList = new List<string>();

            foreach (string str in strs) {
                string orderedStr = string.Join("", str.OrderBy(r => r));
                int index = strList.IndexOf(orderedStr);

                if (index > -1) {
                    listOfList[index].Add(str);
                } else {
                    strList.Add(orderedStr);
                    var list = new List<string>() { str };
                    listOfList.Add(list);
                }
            }

            return listOfList;
        }

        // time limit
        public IList<IList<string>> GroupAnagrams1(string[] strs) {
            var listOfList = new List<IList<string>>();
            var listOfDic = new List<Dictionary<char, int>>();

            foreach (string str in strs) {
                var wordDic = new Dictionary<char, int>();

                if (str.Length == 0) {
                    char empty = ' ';
                    wordDic[empty] = wordDic.GetValueOrDefault(empty, 0) + 1;
                }

                foreach (char letter in str) {
                    wordDic[letter] = wordDic.GetValueOrDefault(letter, 0) + 1;
                }

                // check in dictionary
                bool hasInDict = false;
                int i = 0;

                for (i = 0; i < listOfDic.Count; i++) {
                    Dictionary<char, int> dic = listOfDic[i];
                    bool isFound = true;

                    foreach (char key in wordDic.Keys) {
                        if (wordDic.Count != dic.Count || !dic.ContainsKey(key) || wordDic[key] != dic[key]) {
                            isFound = false;
                            break;
                        }
                    }

                    if (isFound) {
                        hasInDict = true;
                        break;
                    }
                }

                if (!hasInDict) {
                    listOfDic.Add(wordDic);
                    var groupStrs = new List<string>() { str };
                    listOfList.Add(groupStrs);
                } else {
                    listOfList[i].Add(str);
                }
            }

            return listOfList;
        }

    }
}
