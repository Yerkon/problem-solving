using System;
using System.Collections.Generic;
using System.Text;

namespace Occurrences_After_Bigram {
    public class Solution {
        public string[] FindOcurrences(string text, string first, string second) {
            var res = new List<string>();
            int i = 0;
            while (i >= 0) {
                string two = first + " " + second + " ";
                int idx = text.IndexOf(two, i);
                int end = idx + two.Length, start = end;
               
                while (end < text.Length && text[end] != ' ') {
                    ++end;
                }

                if(idx >= 0 && start < text.Length) {
                    if(idx == 0 || text[idx - 1] == ' ') {
                        res.Add(text.Substring(start, end-start));
                    }
                } else {
                    break;
                }

                i = idx + first.Length + 1;
            }

            return res.ToArray();
        }

        public string[] FindOcurrences1(string text, string first, string second) {
            var res = new List<string>();
            string[] textArr = text.Split(" ");

            for (int i = 0; i < textArr.Length - 2; i++) {
                if (textArr[i] == first && textArr[i + 1] == second) {
                    res.Add(textArr[i + 2]);
                }
            }

            return res.ToArray();
        }

    }
}
