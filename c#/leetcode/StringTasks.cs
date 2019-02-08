using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringTasks
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public void constructor()
        {
            X = 0;
            Y = 0;
        }

        public void Move(char direction)
        {
            switch (direction)
            {
                case 'L':
                    this.X--;
                    break;
                case 'R':
                    this.X++;
                    break;
                case 'U':
                    this.Y++;
                    break;
                case 'D':
                    this.Y--;
                    break;
                default:
                    break;
            }
        }

        public bool IsOrigin()
        {
            return this.X == 0 && this.Y == 0;
        }
    }
    public class Solution
    {
        // https://leetcode.com/problems/groups-of-special-equivalent-strings/
        public int NumSpecialEquivGroups(string[] A)
        {
            var list = new List<string>(A);
            ArrayList result = new ArrayList();

            while (list.Count > 0)
            {
                string currWord = list.ElementAt(0);
                list.RemoveAt(0);

                ArrayList chunk = new ArrayList();
                chunk.Add(currWord);

                if (currWord.Length == 1)
                {
                    while (list.IndexOf(currWord) > -1)
                    {
                        int foundIdx = list.IndexOf(currWord);
                        chunk.Add(list.ElementAt(foundIdx));
                        list.RemoveAt(foundIdx);
                    }
                }

                for (int j = 0; j < currWord.Length / 2; j++) // 0, 1
                {
                    for (int k = currWord.Length / 2; k < currWord.Length; k++) // 2, 3
                    {
                        // odds or evens
                        if (j % 2 == k % 2)
                        {
                            var currSb = new StringBuilder(currWord);
                            // Console.WriteLine(j + " " + k);
                            char temp = currSb[j];
                            currSb[j] = currSb[k];
                            currSb[k] = temp;

                            // Console.WriteLine(currSB.ToString());

                            while (list.IndexOf(currSb.ToString()) > -1)
                            {
                                int foundIdx = list.IndexOf(currSb.ToString());
                                chunk.Add(list.ElementAt(foundIdx));
                                list.RemoveAt(foundIdx);
                            }
                        }
                    }
                }

                for (int i = 0; i < chunk.Count; i++)
                {
                    currWord = chunk[i] as string;
                    for (int j = 0; j < currWord.Length / 2; j++) // 0, 1
                    {
                        for (int k = currWord.Length / 2; k < currWord.Length; k++) // 2, 3
                        {
                            // odds or evens
                            if (j % 2 == k % 2)
                            {
                                var currSb = new StringBuilder(currWord);
                                // Console.WriteLine(j + " " + k);
                                char temp = currSb[j];
                                currSb[j] = currSb[k];
                                currSb[k] = temp;

                                // Console.WriteLine(currSB.ToString());

                                while (list.IndexOf(currSb.ToString()) > -1)
                                {
                                    int foundIdx = list.IndexOf(currSb.ToString());
                                    chunk.Add(list.ElementAt(foundIdx));
                                    list.RemoveAt(foundIdx);
                                }
                            }
                        }
                    }
                }

                result.Add(chunk);
            }

            return result.Count;
        }

        // https://leetcode.com/problems/reverse-string/
        public void ReverseString(char[] s)
        {
            int half = s.Length / 2;
            for (int i = 0; i < half; i++)
            {
                char temp = s[i];
                s[i] = s[s.Length - 1 - i];
                s[s.Length - 1 - i] = temp;
            }
        }

        // https://leetcode.com/problems/reverse-words-in-a-string-iii/
        public string ReverseWords(string s)
        {
            if (!s.Contains(' '))
            {
                return this.ReverseWord(s);
            }

            StringBuilder result = new StringBuilder();
            StringBuilder word = new StringBuilder();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    result.Append(this.ReverseWord(word.ToString()));
                    result.Append(' ');
                    word.Clear();
                }
                else
                {
                    word.Append(s[i]);
                }
            }

            result.Append(this.ReverseWord(word.ToString()));

            return result.ToString();
        }

        public string ReverseWord(string word)
        {
            StringBuilder sb = new StringBuilder(word.Length);
            for (int i = word.Length - 1; i >= 0; i--)
            {
                sb.Append(word[i]);
            }

            return sb.ToString();
        }


        // https://leetcode.com/problems/robot-return-to-origin/
        public bool JudgeCircle(string moves)
        {
            Point position = new Point();
            foreach (char direction in moves)
            {
                position.Move(direction);
            }

            return position.IsOrigin();
        }


        // https://leetcode.com/problems/unique-morse-code-words/
        public int UniqueMorseRepresentations(string[] words)
        {
            var hash = new HashSet<string>();
            string[] morseCodes = new string[]{
                ".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",
                ".-.","...","-","..-","...-",".--","-..-","-.--","--.."
            };

            foreach (string word in words)
            {
                string morseCode = this.getMorseCode(morseCodes, word);
                hash.Add(morseCode);
            }

            return hash.Count;
        }

        public string getMorseCode(string[] morseCodes, string word)
        {
            string morseResult = "";

            for (int i = 0; i < word.Length; i++)
            {
                morseResult += morseCodes[word[i] - 'a'];
            }

            return morseResult;
        }

        public string ToLowerCase(string str)
        {
            string result = "";

            foreach (char letter in str)
            {
                if (letter >= 65 && letter <= 90)
                {
                    char lowerLetter = (char)((int)letter + 32);
                    result += lowerLetter;
                }
                else
                {
                    result += letter;
                }
            }

            return result;
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

        public int NFact(int n)
        {
            if (n <= 0) return 1;
            else
            {
                return n * NFact(n - 1);
            }
        }
    }

}
