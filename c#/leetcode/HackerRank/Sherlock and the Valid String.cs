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

class Solution2 {

    // Complete the isValid function below.
    static string isValid(string s) {
        int[] arr = new int[26];
        double common = 0;
        int maxCount = 0, minCount = 0;
        int min = int.MaxValue, max = int.MinValue;

        for (int i = 0; i < s.Length; i++) {
            int idx = s[i] - 'a';
            arr[idx]++;
        }

        for (int i = 0; i < s.Length; i++) {
            int idx = s[i] - 'a';

            min = Math.Min(min, arr[idx]);
            max = Math.Max(max, arr[idx]);
        }

        for (int i = 0; i < s.Length; i++) {
            int idx = s[i] - 'a';

            if (arr[idx] == min) minCount++;
            else if (arr[idx] == max) maxCount++;
        }

        common = minCount > maxCount ? min : max;
        int count = 0;

        for (int i = 0; i < 26; i++) {

            if (arr[i] > 0) {
                double diff = Math.Abs(common - arr[i]);

                if (diff > 0) {
                    count++;
                }

                if (count > 1) {
                    return "NO";
                }
            }
        }

        return "YES";
    }

    //static void Main(string[] args) {
    //    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

    //    string s = Console.ReadLine();

    //    string result = isValid(s);

    //    textWriter.WriteLine(result);

    //    textWriter.Flush();
    //    textWriter.Close();
    //}
}
