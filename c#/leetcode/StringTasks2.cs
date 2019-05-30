using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringTasks
{

    public class StrTasks2
    {
        // "abab"
        // "abab"

        // https://leetcode.com/problems/buddy-strings/
        public bool BuddyStrings(string A, string B)
        {
            if (A.Length != B.Length || A.Length == 0) return false;

            int mismatch = 0;
            bool isAllEqual = true;
            List<char> aList = new List<char>();
            List<char> bList = new List<char>();
            Dictionary<char, int> dic = new Dictionary<char, int>();
            int count = 0;

            for (int i = 0; i < A.Length; i++)
            {
                dic[A[i]] = dic.GetValueOrDefault(A[i], 0) + 1;
                count = Math.Max(count, dic[A[i]]);
                if (A[i] != B[i])
                {
                    aList.Add(A[i]);
                    bList.Add(B[i]);
                    mismatch++;
                }

                if (isAllEqual && A[i] != A[0])
                {
                    isAllEqual = false;
                }
            }

            if (mismatch == 2)
            {
                if (aList[0] == bList[1] && aList[1] == bList[0]) return true;
                else return false;
            }

            return isAllEqual || (count > 1 && mismatch == 0);
        }

        public bool isArrEqual(char[] a, string b)
        {
            bool isEqual = true;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    isEqual = false;
                    break;
                }
            }

            return isEqual;
        }
        // https://leetcode.com/problems/valid-palindrome/
        public bool IsPalindromeWithFor(string s)
        {
            s = s.ToLower().Trim();
            if (s.Length == 0) return true;

            bool isValid = true;

            for (int i = 0, j = s.Length - 1; i < j && isValid;)
            {
                if (!char.IsLetterOrDigit(s[i]))
                {
                    i++;
                    continue;
                }
                if (!char.IsLetterOrDigit(s[j]))
                {
                    j--;
                    continue;
                }

                if (s[i] == s[j])
                {
                    i++;
                    j--;
                }
                else
                {
                    isValid = false;
                }
            }

            return isValid;
        }

        // https://leetcode.com/problems/valid-palindrome/
        public bool IsPalindrome(string s)
        {
            s = s.ToLower().Trim();
            if (s.Length == 0) return true;

            int i = 0;
            int j = s.Length - 1;
            bool isValid = true;

            while (i < j && isValid)
            {
                if (!char.IsLetterOrDigit(s[i]))
                {
                    i++;
                    continue;
                }
                if (!char.IsLetterOrDigit(s[j]))
                {
                    j--;
                    continue;
                }

                if (s[i] == s[j])
                {
                    i++;
                    j--;
                }
                else
                {
                    isValid = false;
                }
            }

            return isValid;
        }

        // https://leetcode.com/problems/repeated-string-match/
        public int RepeatedStringMatch(string A, string B)
        {
            if (A.Length == 0 || B.Length == 0 ||
                B.Distinct().Count() > A.Distinct().Count()
             ) return -1;

            StringBuilder sbA = new StringBuilder(A);
            int count = 1;
            string chunk = A;

            // B should be subst of A
            while (sbA.Length < B.Length)
            {
                sbA.Append(chunk);
                count++;
            }

            if (sbA.ToString().Contains(B)) return count;
            if (sbA.Append(chunk).ToString().Contains(B)) return ++count;

            return -1;
        }

        // https://leetcode.com/problems/implement-strstr/
        public int StrStr(string haystack, string needle)
        {
            if (needle.Length == 0) return 0;

            int it = 0;
            bool isEqual = false;
            int startIdx = 0;

            for (int i = 0; i < haystack.Length; i++)
            {
                int lastIdx = i + needle.Length - 1;
                if (lastIdx < haystack.Length &&
                    haystack[i] == needle[it] &&
                    haystack[lastIdx] == needle[needle.Length - 1] &&
                    isEqual == false
                )
                {
                    isEqual = true;
                    startIdx = i;
                }
                if (isEqual)
                {
                    if (haystack[i] == needle[it])
                    {
                        it++;
                    }
                    else
                    {
                        isEqual = false;
                        it = 0;
                        i = startIdx;
                    }
                }


                if (it == needle.Length) return i - (needle.Length - 1);
            }

            return -1;
        }
    }
}