using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode {
    class Backspace_String_Compare {
            public bool BackspaceCompare(string S, string T) {

                int i = S.Length - 1, j = T.Length - 1;
                int iGridCount = 0, jGridCount = 0;

                while (i >= 0 && j >= 0) {
                    if (S[i] == '#') {
                        iGridCount++;
                        i--;
                        continue;
                    }

                    if (T[j] == '#') {
                        jGridCount++;
                        j--;
                        continue;
                    }

                    // clear # first
                    if (iGridCount > 0) {
                        i--;
                        iGridCount--;
                        continue;
                    }

                    if (jGridCount > 0) {
                        j--;
                        jGridCount--;
                        continue;
                    }

                    if (S[i] == T[j]) {
                        i--;
                        j--;
                    } else {
                        return false;
                    }
                }


                while (i >= 0 && (S[i] == '#' || iGridCount > 0)) {

                    if (S[i] == '#') {
                        i--;
                        iGridCount++;
                    } else if (iGridCount > 0) {
                        i--;
                        iGridCount--;
                    }
                }

                // 

                while (j >= 0 && (T[j] == '#' || jGridCount > 0)) {

                    if (T[j] == '#') {
                        j--;
                        jGridCount++;
                    } else if (jGridCount > 0) {
                        j--;
                        jGridCount--;
                    }
                }

                return i == j;
            }
    }
}
