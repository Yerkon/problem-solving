using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode {
    class Last_Stone_Weight {
        int weight = 0;

        public class Pair {
            public int Key { get; set; }
            public int Value { get; set; }

            public Pair(int k, int v) {
                this.Key = k;
                this.Value = v;
            }
        }

        public class PairComparer : IComparer<Pair> {
            public int Compare(Pair x, Pair y) {
                if (x.Key == y.Key) {
                    return x.Value - y.Value;
                } else {
                    return x.Key - y.Key;
                }

            }
        }

        // Time Complexity: O(nlogn), space: O(N)
        public int LastStoneWeight(int[] stones) {
            var sortedSet = new SortedSet<Pair>(new PairComparer());
            

            for (int i = 0; i < stones.Length; i++) {
                sortedSet.Add(new Pair(stones[i], i));
            }

            int it = sortedSet.Count;

            while (sortedSet.Count >= 2) {
                var maxPair = sortedSet.Max;
                int max1 = maxPair.Key;
                sortedSet.Remove(maxPair);

                var max2Pair = sortedSet.Max;
                int max2 = max2Pair.Key;
                sortedSet.Remove(max2Pair); // O(log n)

                int diff = max1 - max2;
                if(diff > 0) {
                    var newPair = new Pair(diff, it++);
                    sortedSet.Add(newPair); // O(log n)
                }
            }

            return sortedSet.Count > 0 ? sortedSet.Min.Key : 0;
        }


        // K - number of operations
        // Time: O(N * K), Space O(K)
        public int LastStoneWeight2(int[] stones) {
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
