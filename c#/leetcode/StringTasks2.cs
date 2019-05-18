using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringTasks
{
    public class StrTasks2
    {
        // "abbabaaaabbbaabaabaabbbaaabaaaaaabbbabbaabbabaabbabaaaaababbabbaaaaabbbbaaabbaaabbbbabbbbaaabbaaaaababbaababbabaaabaabbbbbbbaabaabaabbbbababbbababbaaababbbabaabbaaabbbba"
        // "bbbbbbaa"
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