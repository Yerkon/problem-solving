using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DP {
    public class CountSquares {
        public int CountSquares(int[][] matrix) {
            int count = 0;

            for (int i = 0; i < matrix.Length; i++) {
                for (int j = 0; j < matrix[i].Length; j++) {
                    if(matrix[i][j] == 1) {
                        count++;
                    }


                }
            }
        }
    }
}
