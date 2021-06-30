using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
/*
 * @lc app=leetcode id=1171 lang=csharp
 *
 * [1171] Remove Zero Sum Consecutive Nodes from Linked List
 */


// @lc code=start
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode RemoveZeroSumSublists(ListNode head) {
        ListNode res = head;
        ListNode start = null;

        while (head != null) {
            if (head.val == 0) {
                if (start == null) {
                    res = head.next;
                } else {
                    start.next = head.next;
                }

                head = head.next;
                continue;
            }

            ListNode second = head.next;
            int sum = head.val;
            bool isFound = false;

            while (second != null) {
                sum += second.val;

                if (sum == 0) {
                    if (start == null) {
                        res = second.next;
                    } else {
                        start.next = second.next;
                    }

                    head = second.next;
                    isFound = true;
                    break;
                }

                second = second.next;
            }

            if (isFound) continue;

            start = head;
            head = head.next;
        }

        return res;
    }
}
// @lc code=end

