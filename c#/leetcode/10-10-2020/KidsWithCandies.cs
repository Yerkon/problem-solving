using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project._10_10_2020 {
    public class Solution {
        public IList<bool> KidsWithCandies(int[] candies, int extraCandies) {
            var res = new List<bool>();

            int maxCandy = candies.Max();

            for (int i = 0; i < candies.Length; i++) {
                int currAmount = candies[i] + extraCandies;

                bool hasGreater = currAmount >= maxCandy;
                res.Add(hasGreater);
            }

            return res;
        }
    }
}
