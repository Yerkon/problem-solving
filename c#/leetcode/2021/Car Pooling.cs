using System;
using System.Collections.Generic;
using System.Text;

// https://leetcode.com/problems/car-pooling/


namespace Project._2021 {
    public class Car_Pooling {
        public bool CarPooling(int[][] trips, int capacity) {
            int[] road = new int[1001];
            
            for (int i = 0; i < trips.Length; i++) {

                int[] trip = trips[i];
              
                for (int k = trip[1]; k <= trip[2]; k++) {
                    road[k] += trip[0];
                }
            }

            for (int i = 0; i < trips.Length; i++) {

                int[] trip = trips[i];
                road[trip[2]] -= trip[0];
            }


            for (int i = 0; i < road.Length; i++) {
                if (road[i] > capacity) return false;
            }

            return true;
        }
    }
}
