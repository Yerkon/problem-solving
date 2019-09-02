using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace MathType {
    public class Solution {

        // https://leetcode.com/problems/self-dividing-numbers/
        public IList<int> SelfDividingNumbers(int left, int right) {

            var result = new List<int>();

            for (int i = left; i <= right; i++) {

                int currVal = i;
                bool selfDividable = true;

                while (currVal > 0) {
                    int val = currVal % 10;
                    if (val == 0 || i % val != 0) {
                        selfDividable = false;
                        break;
                    }

                    currVal /= 10;
                }

                if (selfDividable) {
                    result.Add(i);
                }
            }

            return result;
        }
    }
}