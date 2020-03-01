using System;
using System.Collections.Generic;
using System.Text;

namespace UniqueNumberofOccurrences {
    public class Solution {

        // https://leetcode.com/problems/unique-number-of-occurrences/
        public bool UniqueOccurrences(int[] arr) {

            var dic = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++) {
                int el = arr[i];
                dic[el] = dic.GetValueOrDefault(el, 0) + 1;
            }

            return dic.Values.Count == new HashSet<int>(dic.Values).Count;
        }
    }
}
