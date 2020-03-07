using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode {
    public class MyHashMap {
        int[] arr = new int[1] { -1 };
        /** Initialize your data structure here. */
        public MyHashMap() {
            
        }

        /** value will always be non-negative. */
        public void Put(int key, int value) {
            while (arr.Length < key + 1) {
                var newArr = new int[arr.Length * 2];

                for (int i = 0; i < newArr.Length; i++) {
                    newArr[i] = i < arr.Length ? arr[i]: -1;
                }
            
                arr = newArr;
            }

            arr[key] = value;
        }

        /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
        public int Get(int key) {
            if (arr.Length < key + 1) {
                return -1;
            }

            return arr[key];
        }

        /** Removes the mapping of the specified value key if this map contains a mapping for the key */
        public void Remove(int key) {
            if (Get(key) == -1) return;

            arr[key] = -1;
        }
    }
}
