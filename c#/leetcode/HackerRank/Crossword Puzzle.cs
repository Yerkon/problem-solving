using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution {

    static bool isFound = false;
    static string[] ans = new string[10];

    // Complete the crosswordPuzzle function below.
    static string[] crosswordPuzzle(string[] crossword, string words) {

        char[][] crossWordChars = new char[crossword.Length][];

        for (int i = 0; i < crossword.Length; i++) {
            char[] rowArr = crossword[i].ToCharArray();
            crossWordChars[i] = rowArr;
        }

        Fill(crossWordChars, words);

        return ans;
    }

    public static void Fill(char[][] crossword, string words) {
        if (isFound) return;

        string[] wordsArr = words.Split(new char[] { ';' });

        PrintCrossowrd(crossword);
        Console.WriteLine(words);

        bool isAllFilled = true;

        for (int i = 0; i < crossword.Length; i++) {
            for (int j = 0; j < crossword[i].Length; j++) {

                if (crossword[i][j] == '-') {
                    isAllFilled = false;

                    // fill right and bottom

                    bool fillRight = true;

                    if (j + 1 == crossword[i].Length
                        || crossword[i][j + 1] == '+' || crossword[i][j + 1] == 'X') {

                        fillRight = false;
                    }

                    // Console.WriteLine("fill right" + fillRight);
                    // Console.WriteLine("i: " + i + " j:" + j + " fill right: " + fillRight);

                    for (int k = 0; k < wordsArr.Length; k++) {
                        string word = wordsArr[k];
                        string newWordsStr = string.Join(";", wordsArr.Where(w => w != word));

                        if (fillRight) {
                            bool isFilled = FillRight(crossword, i, j, word);

                            if (isFilled) {
                                Fill(crossword, newWordsStr);
                            } else {
                                ClearRight(crossword, i, j);
                            }

                        } else {
                            // bottom
                            bool isFilled = FillBottom(crossword, i, j, word);
                            // Console.WriteLine("fill bottom " + isFilled );

                            if (isFilled) {
                                Fill(crossword, newWordsStr);
                            } else {
                                ClearBottom(crossword, i, j);
                            }
                        }
                    }
                }
            }
        }

        if (isAllFilled) {
            isFound = true;
            Console.WriteLine("Done!");
            // PrintCrossowrd(crossword);     
            for (int i = 0; i < crossword.Length; i++) {
                char[] rowArr = crossword[i];

                string row = new string(rowArr);
                ans[i] = row;
            }

            return;
        }
    }

    public static bool FillRight(char[][] crossword, int r, int index, string word) {

        char[] row = crossword[r];

        if (index != 0 && row[index - 1] == '-') {
            return false;
        }

        if (index != 0 && !(row[index - 1] == '+' || row[index - 1] == 'X')) {
            index--;
        }

        int rowFillLength = row.Length - index;
        if (word.Length > rowFillLength) {
            return false;
        }

        for (int i = 0; i < word.Length; i++) {
            if (row[index] == '-') {
                row[index++] = word[i];
            } else if (row[index] == word[i]) {
                index++;
                continue;
            } else {
                return false;
            }
        }

        if (index != row.Length && row[index] == '-') {
            return false;
        }

        return true;
    }

    public static void ClearRight(char[][] crossword, int r, int index) {
        char[] row = crossword[r];

        //  Console.WriteLine(" before clear " + new string(crossword[r]));

        while (index != row.Length && !(row[index] == '-' || row[index] == '+' || row[index] == 'X')) {
            row[index++] = '-';
        }
        //  Console.WriteLine(" after clear " + new string(crossword[r]));
    }

    public static bool FillBottom(char[][] crossword, int r, int c, string word) {

        if (r != 0 && crossword[r - 1][c] == '-') {
            return false;
        }

        if (r != 0 && !(crossword[r - 1][c] == '+' || crossword[r - 1][c] == 'X')) {
            r--;
        }

        int colFillLength = crossword.Length - r;

        if (word.Length > colFillLength) {
            return false;
        }

        //Console.WriteLine(word);

        for (int i = 0; i < word.Length; i++) {
            if (crossword[r][c] == '-') {
                crossword[r++][c] = word[i];
            } else if (crossword[r][c] == word[i]) {
                r++;
                continue;
            } else {
                return false;
            }
        }

        if (r != crossword.Length && crossword[r][c] == '-') {
            return false;
        }


        return true;
    }

    public static void ClearBottom(char[][] crossword, int r, int c) {

        while (r != crossword.Length && !(crossword[r][c] == '-' || crossword[r][c] == '+' || crossword[r][c] == 'X')) {
            //  Console.WriteLine("ClearBottom r:" + r + ". col: " + c);
            crossword[r++][c] = '-';
        }
    }

    public static void PrintCrossowrd(char[][] crossword) {
        Console.WriteLine("PrintCrossowrd");
        for (int i = 0; i < crossword.Length; i++) {
            for (int j = 0; j < crossword[i].Length; j++) {
                Console.Write(crossword[i][j] + " ");
            }

            Console.WriteLine();
        }
        Console.WriteLine("------------");
    }

    //static void Main(string[] args) {
    //    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

    //    string[] crossword = new string[10];

    //    for (int i = 0; i < 10; i++) {
    //        string crosswordItem = Console.ReadLine();
    //        crossword[i] = crosswordItem;
    //    }

    //    string words = Console.ReadLine();

    //    string[] result = crosswordPuzzle(crossword, words);

    //    textWriter.WriteLine(string.Join("\n", result));

    //    textWriter.Flush();
    //    textWriter.Close();
    //}
}
