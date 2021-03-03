using System;
using System.Collections.Generic;
using System.Text;

namespace Project._2021 {
    public class Boats_to_Save_People {


        // [3,2,2,1]
        // [0, 0, 2, 0]
        // 3
        public int NumRescueBoats(int[] people, int limit) {
            int boats = 0;
            int maxI = 0, maxJ = 1;

            for (int i = 0; i < people.Length; i++) {
                if (people[i] == 0) continue;

                if(people[i] == limit) {
                    people[i] = 0;
                    boats++;
                 
                    continue;
                }

                int currMaxW = int.MinValue;
                bool sumFound = false;
                maxI = i; maxJ = -1;

                for (int j = i + 1; j < people.Length; j++) {
                    if (people[j] == 0 || sumFound) continue;

                    int twoSum = people[i] + people[j];
                   
                    if(twoSum == limit) {
                        boats++;
                        people[i] = 0;
                        people[j] = 0;
                        sumFound = true;

                        continue;

                    } else {
                        // find min
                        if(twoSum > currMaxW && twoSum <= limit) {
                            currMaxW = twoSum;
                            maxI = i; maxJ = j;
                        }
                    }
                }

                if (sumFound) continue;

                // max i, j found
                people[maxI] = 0;
                if(maxJ != -1) people[maxJ] = 0;
                boats++;
            }

            return boats;
        }


    }
}


