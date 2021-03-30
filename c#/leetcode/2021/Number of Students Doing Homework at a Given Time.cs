using System;
using System.Collections.Generic;
using System.Text;

namespace Project._2021 {
    internal class Number_of_Students_Doing_Homework_at_a_Given_Time {
        public int BusyStudent(int[] startTime, int[] endTime, int queryTime) {
            int count = 0;

            for (int i = 0; i < startTime.Length; i++) {
              
                if (startTime[i] <= queryTime && queryTime <= endTime[i]) count++;
            }

            return count;
        }
    }
}
