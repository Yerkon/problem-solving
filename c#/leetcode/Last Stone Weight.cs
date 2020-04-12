using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode {
    class Last_Stone_Weight {
        int weight = 0;

        // K - number of operations
        // Time: O(N * K), Space O(K)
        public int LastStoneWeight(int[] stones) {
            SmashStones(stones);
            
            return weight;
        }

        // Time: O(N)
        public int[] SmashStones(int[] stones) {
            if (stones.Length <= 1) {
                if (stones.Length == 1) {
                    weight = stones[0];
                }
                return Array.Empty<int>();
            }

            var list = new List<int>();
            int max = 0, maxIndex = -1;
            int max2 = 0, max2Index = -1;

            for (int i = 0; i < stones.Length; i++) {
                if(stones[i] > max) {
                    max2 = max;
                    max2Index = maxIndex;

                    max = stones[i];
                    maxIndex = i;
                } else if(stones[i] > max2) {
                    max2 = stones[i];
                    max2Index = i;
                }
            }

            if (max == max2) {
                for (int i = 0; i < stones.Length; i++) {
                    if(!(i == maxIndex || i == max2Index)) {
                        list.Add(stones[i]);
                    }
                }
            } else {
                int diff = max - max2;

                for (int i = 0; i < stones.Length; i++) {
                    if(i == maxIndex) {
                        list.Add(diff);
                    } else  if(i != max2Index) {
                        list.Add(stones[i]);
                    }
                }
            }

            return SmashStones(list.ToArray());
        }

        // K - number of operations
        // Time: O(nlogn * K), Space: O(K)
        public int LastStoneWeight1(int[] stones) {
            SmashStones1(stones);

            return weight;
        }

        public int[] SmashStones1(int[] stones) {
            if(stones.Length <= 1) { 
                if(stones.Length == 1) {
                    weight = stones[0];
                }
                return Array.Empty<int>(); 
            }

            Array.Sort(stones);

            var list = new List<int>();
            int max = stones[stones.Length - 1];
            int max2 = stones[stones.Length - 2];

            if(max == max2) {
                for (int i = 0; i < stones.Length - 2; i++) {
                    list.Add(stones[i]);
                }
            } else {
                int val = max - max2;

                for (int i = 0; i < stones.Length - 2; i++) {
                    list.Add(stones[i]);
                }

                list.Add(val);
            }

           return SmashStones1(list.ToArray());
        }
    }
}
