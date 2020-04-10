using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode {

    class Min_Stack {
        public class MinStack {

            int[] arr = new int[1];
            SortedList<int, int> sortedList = new SortedList<int, int>();
            int it = -1;
            /** initialize your data structure here. */
            public MinStack() {

            }

            public void Push(int x) {

                if(it + 1 < arr.Length) {
                    arr[++it] = x;
                }
                else {
                    while (it + 1 >= arr.Length) {
                        int[] tempArr = new int[arr.Length * 2];

                        for (int i = 0; i < arr.Length; i++) {
                            tempArr[i] = arr[i];
                        }

                        arr = tempArr;
                    }

                    arr[++it] = x;
                }
                
                sortedList[x] = sortedList.GetValueOrDefault(x, 0) + 1;

            }

            // O(n)	
            public void Pop() {
                if (it < 0) return;

                sortedList[arr[it]]--;
               
                if(sortedList[arr[it]] <= 0) {
                    sortedList.Remove(arr[it]);
                }

                arr[it--] = -1;
            }

            // O(1)
            public int Top() {
                if (it < 0) return -1;

                return arr[it];
            }

            // O(1)
            public int GetMin() {
                return sortedList.FirstOrDefault().Key;
            }
        }


    }


}
