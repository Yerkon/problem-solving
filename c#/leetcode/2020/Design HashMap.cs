using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode {

    // All keys and values will be in the range of [0, 1000000].

    public class MyHashMap {
        int[] arr = new int[1000001];
        /** Initialize your data structure here. */
        public MyHashMap() {
            
        }

        /** value will always be non-negative. */
        public void Put(int key, int value) {
          
            arr[key] = value + 1;
        }

        /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
        public int Get(int key) {
            return arr[key] - 1;
        }

        /** Removes the mapping of the specified value key if this map contains a mapping for the key */
        public void Remove(int key) {
           
            arr[key] = 0;
        }
    }
}
