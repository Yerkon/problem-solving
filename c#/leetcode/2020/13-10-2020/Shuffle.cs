using System;
using System.Collections.Generic;
using System.Text;

namespace Project._13_10_2020 {
    public class Solution_Shuffle {
        public int[] Shuffle(int[] nums, int n) {
            int[] res = new int[nums.Length];
            int xPos = 0, yPos = n;

            for (int i = 0; i < nums.Length; i++) {
                if (i % 2 == 0) {
                    res[i] = nums[xPos++];
                } else {
                    res[i] = nums[yPos++];
                }
            }

            return res;
        }
    }
}
