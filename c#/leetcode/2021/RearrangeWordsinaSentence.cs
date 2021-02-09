using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode_2021 {
    public class Solution {
        public string ArrangeWords1(string text) {
            string[] words = text.ToLower().Split(" ");
            words = words.OrderBy(r => r.Length).ToArray();

            var builder = new StringBuilder();

            for (int i = 0; i < words.Length; i++) {
                string word = words[i];

                if (i == 0) word = char.ToUpper(word[0]) + word.Substring(1);
              
                builder.Append(word);
                builder.Append(" ");
            }

            builder.Remove(builder.Length - 1, 1);

            return builder.ToString();
        }

        public string ArrangeWords(string text) {
            string[] words = text.ToLower().Split(" ");
            words = words.OrderBy(r => r.Length).ToArray();

            string res = string.Join(" ", words);

            return char.ToUpper(res[0]) + res.Substring(1);
        }
    }
}
