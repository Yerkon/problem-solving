using System;
using System.Collections.Generic;
using System.Text;

namespace Maximum_Number_of_Balloons {
    public class Solution {
        public int MaxNumberOfBalloons(string text) {
            int count = int.MaxValue;
            string word = "balloon";
            var dic = new Dictionary<char, int>();
            var textDic = new Dictionary<char, int>();

            foreach (char letter in word) {
                dic[letter] = dic.GetValueOrDefault(letter, 0) + 1;
            }

            foreach (char letter in text) {
                textDic[letter] = textDic.GetValueOrDefault(letter, 0) + 1;
            }

            foreach (char key in dic.Keys) {
                int sourceCount = dic[key];
                int textCount = textDic.GetValueOrDefault(key, 0);

                count = Math.Min(count, textCount / sourceCount);
            }

            return count;
        }
    }
}
