using System;
using System.Collections.Generic;
using System.Linq;

namespace StringTasks
{
    public class Solution
    {
        public int NFact(int n)
        {
            if (n <= 0) return 1;
            else
            {
                return n * NFact(n - 1);
            }
        }

        public int NumUniqueEmails(string[] emails)
        {
            Dictionary<string, int> uniqEmails = new Dictionary<string, int>();

            foreach (string email in emails)
            {
                string validEmail = this.getValidEmail(email);
                uniqEmails.TryAdd(validEmail, 1);
            }

            return uniqEmails.Count;
        }

        // split form
        // public string getValidEmail(string email)
        // {
        //     string[] emailArr = email.Split("@");
        //     string domain = emailArr[emailArr.Length - 1];
        //     string localName = emailArr[0].Split("+").First();

        //     localName = localName.Replace(".", "");

        //     return localName + "@" + domain;
        // }

        // substring form
        public string getValidEmail(string email)
        {
            int idx = email.IndexOf("@");
            string localName = email.Substring(0, idx);
            string domain = email.Substring(idx);

            if (localName.Contains("+"))
            {
                localName = localName.Substring(0, localName.IndexOf("+"));
            }


            localName = localName.Replace(".", "");
            return localName + "@" + domain;
        }
    }

}
