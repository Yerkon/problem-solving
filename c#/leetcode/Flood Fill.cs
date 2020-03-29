using System;
using System.Collections.Generic;
using System.Text;

// https://leetcode.com/problems/flood-fill/

namespace leetcode {
    class Flood_Fill {
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor) {
            if (image.Length == 0) return image;

            int[][] seen = new int[image.Length][];

            for (int i = 0; i < image.Length; i++) {
                int[] row = new int[image[0].Length];
                seen[i] = row;
            }

            Fill(seen, image, sr, sc, newColor, image[sr][sc]);

            return image;
        }

        public void Fill(int[][] seen, int[][] image, int sr, int sc, int newColor, int oldColor) {
            if (
                sr < 0 || sr >= image.Length
                || sc < 0 || sc >= image[0].Length) {
                return;
            }

            if (seen[sr][sc] == 1) {
                return;
            }

            if (image[sr][sc] == oldColor) {
                image[sr][sc] = newColor;
                seen[sr][sc] = 1;
            } else {
                return;
            }

            Fill(seen, image, sr + 1, sc, newColor, oldColor);
            Fill(seen, image, sr - 1, sc, newColor, oldColor);

            Fill(seen, image, sr, sc + 1, newColor, oldColor);
            Fill(seen, image, sr, sc - 1, newColor, oldColor);
        }
    }
}
