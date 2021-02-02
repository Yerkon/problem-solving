using System;
using System.Collections.Generic;
using System.Text;

namespace Project.January_2021 {
    internal class Max_Chunks_To_Make_Sorted {
        public int MaxChunksToSorted(int[] arr) {
            int chunks = 0;
            int value = -1;
            
            for (int i = 0; i < arr.Length; i++) {
                if (arr[i] == i && value == -1) {
                    chunks++;
                
                } else {

                    if (value == i) {
                        chunks++;
                        value = -1;
                    } else if (value == -1) {
                        value = arr[i];
                    }

                }
            }

            return  chunks;
        }
    }
}
