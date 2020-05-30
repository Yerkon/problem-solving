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

class MaxSubsetSum {

    // Complete the maxSubsetSum function below.
    static int maxSubsetSum(int[] arr) {
        int max = arr[0];

        if (arr.Length <= 2) {

            for (int i = 0; i < arr.Length; i++) {
                max = Math.Max(max, arr[i]);
            }

            return max;
        }

        int[] sumArr = new int[arr.Length];

        sumArr[0] = arr[0];
        sumArr[1] = arr[1];
        sumArr[2] = Math.Max(sumArr[2], sumArr[2] + sumArr[0]);

        max = Math.Max(max, Math.Max(sumArr[1], sumArr[2]));

        for (int i = 2; i < arr.Length; i++) {
            int max1 = Math.Max(arr[i], arr[i] + sumArr[i - 2]);
            max1 = Math.Max(max1, sumArr[i - 2]);

            int prevPrevVal = (i - 3) < 0 ? 0 : sumArr[i - 3];
            int max2 = Math.Max(arr[i], arr[i] + prevPrevVal);
            max2 = Math.Max(max2, prevPrevVal);

            sumArr[i] = Math.Max(max1, max2);
            max = Math.Max(max, sumArr[i]);
        }

        // for(int i = 0; i< sumArr.Length; i++) {
        //     Console.Write(sumArr[i] + " ");
        // }

        return max;

    }

    //static void Main(string[] args) {
    //    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

    //    int n = Convert.ToInt32(Console.ReadLine());

    //    int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
    //    ;
    //    int res = maxSubsetSum(arr);

    //    textWriter.WriteLine(res);

    //    textWriter.Flush();
    //    textWriter.Close();
    //}
}
