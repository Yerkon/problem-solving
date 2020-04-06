using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode {
    internal class Group_Anagrams {
        public IList<IList<string>> GroupAnagrams(string[] strs) {
            var listOfList = new List<IList<string>>();
            var strList = new List<string>();

            foreach (string str in strs) {
                string orderedStr = string.Join("",str.OrderBy(r => r));                
                int index = strList.IndexOf(orderedStr);
                
                if(index > -1) {
                    listOfList[index].Add(str);
                } else {
                    strList.Add(orderedStr);
                    var list = new List<string>() { str };
                    listOfList.Add(list);
                }
            }

            return listOfList;
        }

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
