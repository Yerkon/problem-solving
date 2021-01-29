using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode {

    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    internal class Middle_of_the_Linked_List {
        public ListNode MiddleNode(ListNode head) {
            if (head == null) return null;

            int count = 0;

            ListNode currNode = head;

            while (currNode != null) {
                count++;
                currNode = currNode.next;
            }

            int middle = count / 2 + 1;
            count = 1;

            currNode = head;

            while (count != middle) {
                currNode = currNode.next;
                count++;
            }

            return currNode;
        }
    }
}
