using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * @lc app=leetcode id=316 lang=csharp
 *
 * [316] Remove Duplicate Letters
 */

// @lc code=start
public class Solution {
    public string RemoveDuplicateLetters(string s) {
        if (s.Length <= 1) return s;

        var uniqChars = new HashSet<char>(s);
        var uniqList = new List<string>();
        string arrStr = "";
        for (int i = 0; i < 27; i++)
        {
            arrStr += "0";
        }

        for (int i = 0; i < s.Length; i++) {
            GetUniqStr(s, "", i, uniqList, uniqChars.Count, arrStr);
        }

        // foreach (var item in uniqList) {
        //     Console.WriteLine(item);
        // }

        //  return uniqList.FirstOrDefault();
        return uniqList.OrderBy(r => r).FirstOrDefault();
    }

    // '"thesqtitxyetpxloeevdeqifkz"'
    public void GetUniqStr(string s, string curr, int idx, List<string> uniqList, int length, string arrStr) {

        var currStr = curr.ToString();
        if (idx == s.Length) {
            if (currStr.Length == length) {
                uniqList.Add(currStr);
            }

            return;
        };

        if(arrStr[s[idx] - 'a'] == '0') {
           var strArr = arrStr.ToCharArray();
           strArr[s[idx] - 'a'] = '1';
           arrStr = new string(strArr);
           
         //  curr += s[idx];
        }

        for (int i = idx + 1; i < s.Length + 1; i++) {
            GetUniqStr(s, curr, i, uniqList, length, arrStr);
        }
    }
}
// @lc code=end