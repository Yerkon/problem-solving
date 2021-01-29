using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode {
    class Class1 {
        static int sockMerchant(int n, int[] ar) {
            var dic = new Dictionary<int, int> ();
            int ans = 0;

            for (int i = 0; i < ar.Length; i++) {
                int color = ar[i];

                dic[color] = dic.GetValueOrDefault(dic[color], 0) + 1;

            }

            foreach (var key in dic.Keys) {
                ans += dic[key] / 2;
            }

            return ans;

        }
    }
}
