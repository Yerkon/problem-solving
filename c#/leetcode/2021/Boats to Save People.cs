using System;
using System.Collections.Generic;
using System.Text;

namespace Project._2021 {
    public class Boats_to_Save_People {

        public int NumRescueBoats(int[] people, int limit) {
            int boats = 0;
            int[] countArr = new int[limit + 1];

            for (int i = 0; i < people.Length; i++) {
                countArr[people[i]]++;
            }

            for (int weight = limit; weight >= 1; weight--) {
                
                while (countArr[weight] > 0) {
                    int rem = limit - weight;
                    countArr[weight]--;
                    bool remFound = false;

                    if (rem == 0) {
                        boats++;
                    } else {
                        
                        int startEl = Math.Min(rem, weight);
                        for (int k = startEl; k >= 1; k--) {
                            if(countArr[k] > 0) {
                                countArr[k]--;
                                boats++;
                                remFound = true;
                                break;
                            }
                        }

                        if (!remFound) boats++;
                       
                    }
                }
            }

            return boats;
        }

     

        // [3,2,2,1]
        // [0, 0, 2, 0]
        // 3
        public int NumRescueBoats1(int[] people, int limit) {
            int boats = 0;
            int maxI = 0, maxJ = 1;

            for (int i = 0; i < people.Length; i++) {
                if (people[i] == 0) continue;

                if(people[i] == limit) {
                    people[i] = 0;
                    boats++;
                 
                    continue;
                }

                int ithMaxW = int.MinValue;
                bool sumFound = false;
                maxI = i; maxJ = -1;

                for (int j = i + 1; j < people.Length; j++) {
                    if (people[j] == 0) continue;

                    int twoSum = people[i] + people[j];
                   
                    if(twoSum == limit) {
                        boats++;
                        people[i] = 0;
                        people[j] = 0;
                        sumFound = true;

                        break;

                    } else {
                        // find min
                        if(twoSum > ithMaxW && twoSum <= limit) {
                            ithMaxW = twoSum;
                            maxI = i; maxJ = j;
                        }
                    }
                }

                if (sumFound) continue;

                // max i, j? found
                people[maxI] = 0;
                if(maxJ != -1) people[maxJ] = 0;
                boats++;
            }

            return boats;
        }
    }
}


