using System;
using System.Collections.Generic;
using System.Text;

namespace Find_Words_That_Can_Be_Formed_by_Characters {
    public class Solution {

        // https://leetcode.com/problems/find-words-that-can-be-formed-by-characters/
        public int CountCharacters(string[] words, string chars) {
            int length = 0;

            var dic = new Dictionary<char, int>();
           
            foreach (char letter in chars) {
                dic[letter] = dic.GetValueOrDefault(letter, 0) + 1;
            }

            for (int i = 0; i < words.Length; i++) {
                string word = words[i];
                var wordDic = new Dictionary<char, int>();

                foreach (char letter in word) {
                    wordDic[letter] = wordDic.GetValueOrDefault(letter, 0) + 1;
                }

                bool canBeFormed = true;
                foreach (char wordKey in wordDic.Keys) {
                    if(!dic.ContainsKey(wordKey) || wordDic[wordKey] > dic[wordKey]) {
                        canBeFormed = false;
                        break;
                    }
                }

                if(canBeFormed) {
                    length += word.Length;
                }

            }

            return length;
        }
    }
}
