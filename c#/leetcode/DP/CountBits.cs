using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DP {
    internal class Count_Bits {
        public int[] CountBits(int num) {
            int[] res = new int[num + 1];
            int[] dp = new int[num + 1];

            dp[1] = 1;
            dp[2] = 1;
            dp[3] = 2;
            dp[4] = 1;
            dp[5] = 2;
            dp[6] = 2;
            dp[7] = 3;


            for (int i = 0; i <= num; i++) {
                if(i == 8 || i == 16 || i == 32) {

                }

                res[i] = dp[i];
            }

            return res;
        }

        // naive
        public int[] CountBits1(int num) {
            int[] res = new int[num + 1];

            for (int i = 0; i <= num; i++) {
                res[i] = countOnes(i);
            }

            return res;
        }

        public int countOnes(int n) {
            int count = 0;
            int i = 0;

            while (i < 32) {
                if ((n & (1 << i)) != 0) {
                    count++;
                
                }
                i++;
            }

            return count;
        }
    }
}
