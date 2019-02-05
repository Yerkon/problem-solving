using System;
using System.Collections.Generic;
using System.Linq;

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
        // https://leetcode.com/problems/robot-return-to-origin/
        public bool JudgeCircle(string moves)
        {
            Point origin = new Point();
            foreach (char direction in moves)
            {
                origin.Move(direction);
            }

            return origin.IsOrigin();
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
