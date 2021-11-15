using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yandex_Test {
    internal class Program
    {
        private static void Main(string[] args)
        {
            //string input = "osljjaooouqphokrnf     lsdoioccbdhbsqkm b     qmqoitpqnpqwnebsou     llvfotmazegriuigrs     vjpbgaqifwo  kaqto     dsupahycdgbyoubsu";
            //int rows = 6;
            //string res = DecodeCiphertext(input, rows);


            //Console.WriteLine(res);
        }

        public string DecodeCiphertext(string encodedText, int rows)
        {
            if(rows == 1)
            {
                return encodedText;
            }

            int cols = encodedText.Length / rows;
            char[,] matrix = new char[rows, cols];
            int it = 0;
            StringBuilder sb = new();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = encodedText[it++];
                }
            }


            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int sI = 0, sJ = i;

                while (sI < matrix.GetLength(0) && sJ < matrix.GetLength(1))
                {
                    sb.Append(matrix[sI, sJ]);
                    sI++; sJ++;
                }
            }

            string res = sb.ToString().TrimEnd();

            return res;
        }


        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        //        Input:
        //[0,4,2,1,3]
        //        Output:
        //[0,2,4,1,3]
        //        Expected:
        //[0,2,4,3,1]
        public ListNode ReverseEvenLengthGroups(ListNode head)
        {
            int groupSize = 1;

            ListNode curr = head;
            ListNode prevNode = null;

            while (curr?.next != null)
            {
                int grpSizeIt = groupSize;
                int grpCount = 0;
                ListNode tempIt = curr;
                while (grpSizeIt > 0 && tempIt != null)
                {
                    tempIt = tempIt.next;
                    grpSizeIt--;
                    grpCount++;
                }

                if(grpCount % 2 == 0)
                {
                    int grpIt = groupSize;
                    List<ListNode> listNodes = new List<ListNode>();

                    while (grpIt > 0 && curr != null)
                    {
                        listNodes.Add(curr);
                        curr = curr.next;
                        grpIt--;
                    }

                    prevNode.next = listNodes.Count > 0 ? listNodes[listNodes.Count - 1] : prevNode.next;
                    ListNode nextGroupNode = listNodes[listNodes.Count - 1]?.next;

                    for (int i = listNodes.Count - 1; i >= 1; i--)
                    {
                        listNodes[i].next = listNodes[i - 1];
                    }

                    ListNode firstNode = listNodes.FirstOrDefault();

                    if(firstNode != null)
                    {
                        firstNode.next = nextGroupNode;
                    }
                    prevNode = firstNode;

                } else
                {
                    int grpIt = groupSize;
                    while (grpIt > 0 && curr != null)
                    {
                        prevNode = curr;
                        curr = curr.next;
                        grpIt--;
                    }
                }
                
                groupSize++;
            }

            return head;
        }



        // [84,49,5,24,70,77,87,8]
        // 3
        //
        public int TimeRequiredToBuy(int[] tickets, int k)
        {
            int ans = 0;

            while (tickets[k] > 0)
            {
                for (int i = 0; i < tickets.Length; i++)
                {
                    if(tickets[i] > 0)
                    {
                        tickets[i]--;
                        ans++;

                        if(tickets[k] == 0)
                        {
                            return ans;
                        }
                    }
                }
            }

            return ans;
        }

        //private static void Main(string[] args) {
        //    int res = 0;

        //    int[] size =  Console.ReadLine().Split(' ').Select(r => int.Parse(r)).ToArray();
        //    int mines = int.Parse(Console.ReadLine());

        //    var totalCords = new List<int[]>();

        //    for (int i = 0; i < mines; i++) {
        //        int[] cords = Console.ReadLine().Split(' ').Select(r => int.Parse(r)).ToArray();
        //        totalCords.Add(cords);
        //    }

        //    int[,] matrix = new int[size[0], size[1]];
        //    foreach (int[] cord in totalCords) {
        //        matrix[cord[0] - 1, cord[1] - 1] = 1;
        //    }

        //    for (int i = 0; i < matrix.GetLength(0); i++) {
        //        for (int j = 0; j < matrix.GetLength(1); j++) {
        //            if(matrix[i, j] == 0) {
        //                OpenCell(matrix, i, j);
        //                res++;
        //            } 
        //        }
        //    }


        //    Console.WriteLine(res);

        //    //for (int i = 0; i < matrix.GetLength(0); i++) {
        //    //    for (int j = 0; j < matrix.GetLength(1); j++) {
        //    //        Console.Write(matrix[i,j] + " ");
        //    //    }

        //    //    Console.WriteLine();
        //    //}
        //}

        //public static void OpenCell(int[,] matrix, int i, int j) {
        //    if(i < 0 || i >= matrix.GetLength(0) || j < 0 || j >= matrix.GetLength(1)) {
        //        return;
        //    }

        //    if(matrix[i,j] == 0) {
        //        matrix[i, j] = 1;
        //        OpenCell(matrix, i + 1, j);
        //        OpenCell(matrix, i - 1, j);
        //        OpenCell(matrix, i, j + 1);
        //        OpenCell(matrix, i, j - 1);
        //    }
        //}


        //private static void Main(string[] args) {
        //    int count = int.Parse(Console.ReadLine());
        //    int[] ranks = new int[count];

        //    for (int i = 0; i < count; i++) {
        //        ranks[i] = int.Parse(Console.ReadLine());
        //    }

        //    var orderedRanks = ranks.OrderBy(r => r).ToArray();
        //    int[] sumArr = new int[ranks.Length];

        //    for (int i = 0; i < orderedRanks.Length; i++) {
        //        sumArr[i] += 500;
        //    }

        //    for (int i = 0; i < orderedRanks.Length - 1; i++) {
        //        if (orderedRanks[i] < orderedRanks[i + 1]) {
        //            sumArr[i + 1] = sumArr[i] + 500;
        //        } else if (orderedRanks[i] == orderedRanks[i + 1]) {
        //            sumArr[i + 1] = sumArr[i];
        //        }
        //    }

        //    //// 2 3 3 4
        //    /// 4 3 3 2
        //    //for (int i = 0; i < sumArr.Length; i++) {
        //    //    Console.Write(sumArr[i] + " ");
        //    //}
        //    //Console.WriteLine();

        //    Console.WriteLine(sumArr.Sum());
        //}

        //private static void Main(string[] args) {
        //    string[] input1 = Console.ReadLine().Split(' ');
        //    string[] input2 = Console.ReadLine().Split(' ');

        //    int[] input1Vals = input1.Select(r => int.Parse(r)).ToArray();
        //    int checkDay = input1Vals[1], finishDay = input1Vals[2], taskCount = input1Vals[0];
        //    int dayCount = checkDay;
        //    int[] dedlines = input2.Select(r => int.Parse(r)).ToArray();
        //    int[] sumArr = dedlines.Select(r => r).ToArray();

        //    var set = new HashSet<int>();

        //    while (finishDay > 0) {

        //        bool hasReport = false;
        //        for (int i = 0; i < dedlines.Length; i++) {

        //            if (dedlines[i] < checkDay) {
        //                set.Add(sumArr[i]);
        //                hasReport = true;
        //                sumArr[i] += dayCount;
        //            }
        //        }

        //        checkDay *= 2;
        //        if (hasReport) finishDay--;
        //    }


        //    int[] orderedReport = set.OrderBy(r => r).ToArray();

        //    Console.WriteLine(orderedReport[input1Vals[2] - 1]);
        //}

    }
}
