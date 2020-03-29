using System;
using System.Collections.Generic;
using System.Text;

// https://leetcode.com/problems/flood-fill/

namespace leetcode {
    class Flood_Fill {
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor) {
            if (image.Length == 0) return image;

            int oldColor = image[sr][sc];

            if(oldColor != newColor) {
                Fill(image, sr, sc, newColor, oldColor);
            }

            return image;
        }

        public void Fill(int[][] image, int sr, int sc, int newColor, int oldColor) {
            if (
                sr < 0 || sr >= image.Length
                || sc < 0 || sc >= image[0].Length) {
                return;
            }

            if (image[sr][sc] == oldColor) {
                image[sr][sc] = newColor;


                Fill(image, sr + 1, sc, newColor, oldColor);
                Fill(image, sr - 1, sc, newColor, oldColor);

                Fill(image, sr, sc + 1, newColor, oldColor);
                Fill(image, sr, sc - 1, newColor, oldColor);
            } 
        }
    }
}
