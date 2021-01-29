using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode {

    class Min_Stack {

        class Node {
            public int Value { get; set; }
            public int Min { get; set; }
            public Node Next { get; set; }

            public Node(int val, int min) {
                this.Value = val;
                this.Min = min;
            }

            public Node(int val, int min, Node next) {
                this.Value = val;
                this.Min = min;
                this.Next = next;
            }
        }

        // Linked list
        public class MinStack {

            Node head;
            /** initialize your data structure here. */
            public MinStack() {

            }

            // O(1)
            public void Push(int x) {
                if(head == null) {
                    head = new Node(x, x);
                } else {
                    head = new Node(x, Math.Min(head.Min, x), head);
                }
            }

            // O(1)
            public void Pop() {
                head = head.Next;
            }

            // O(1)
            public int Top() {
                return head.Value;
            }

            // O(1)
            public int GetMin() {
                return head.Min;
            }
        }


        // Sorted list, array
        public class MinStack1 {

            int[] arr = new int[1];
            SortedList<int, int> sortedList = new SortedList<int, int>();
            int it = -1;
            /** initialize your data structure here. */
            public MinStack1() {

            }

            // O(n)
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

            // O(logn) in average case, O(N) when remove from sorted list	
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
                return sortedList.Keys[0];
            }
        }


    }


}
