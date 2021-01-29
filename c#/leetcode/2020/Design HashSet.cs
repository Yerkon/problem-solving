using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode {
    // https://leetcode.com/problems/design-hashset/
    // All values will be in the range of [0, 1000000].

    public class MyHashSet {

        int[] arr = new int[1000001];
        /** Initialize your data structure here. */
        public MyHashSet() {

        }

        public void Add(int key) {
            arr[key] = 1;
        }

        public void Remove(int key) {
            arr[key] = 0;
        }

        /** Returns true if this set contains the specified element */
        public bool Contains(int key) {
            return arr[key] == 1;
        }
    }
}
