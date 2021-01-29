using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode {
    class Perform_String_Shifts {
        public string StringShift(string s, int[][] shift) {
            var sb = new StringBuilder();

            int shiftCount = 0;
            for (int i = 0; i < shift.Length; i++) {
                int[] row = shift[i];
                
                shiftCount = row[0] == 0 
                    ? shiftCount - row[1] 
                    : shiftCount + row[1];
            }

            shiftCount = shiftCount * (-1) % s.Length;

            for (int i = 0; i < s.Length; i++) {
                int idx = (i + shiftCount) % s.Length;

                if (idx < 0) idx = s.Length + idx;

                sb.Append(s[idx]);
            }

            return sb.ToString();
        }
    }
}
