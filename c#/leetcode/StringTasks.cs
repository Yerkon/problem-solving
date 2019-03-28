using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringTasks
{
    public class Solution
    {

        // https://leetcode.com/problems/repeated-substring-pattern/
        public bool RepeatedSubstringPattern(string s)
        {

        }
        // https://leetcode.com/problems/count-and-say/
        public string CountAndSay(int n)
        {
            StringBuilder sb = new StringBuilder("1");
            return this.CountAndSayRec(n, 1, sb);
        }

        public string CountAndSayRec(int n, int it, StringBuilder result)
        {
            if (it == n) return result.ToString();

            else
            {
                StringBuilder sb = new StringBuilder();
                int count = 1;
                for (int i = 0; i < result.Length - 1; i++)
                {
                    if (result[i] == result[i + 1])
                    {
                        count++;
                    }
                    else
                    {
                        string res = count.ToString() + result[i];
                        sb.Append(res);
                        count = 1;
                    }
                }

                // last number
                string rem = count.ToString() + result[result.Length - 1];
                sb.Append(rem);
                count = 1;

                return this.CountAndSayRec(n, ++it, sb);
            }
        }

        // https://leetcode.com/problems/reverse-vowels-of-a-string/
        public string ReverseVowels(string s)
        {
            StringBuilder resultSb = new StringBuilder();
            StringBuilder vowelsSb = new StringBuilder();

            for (int i = 0; i < s.Length; i++)
            {
                if (this.isVowel(s[i])) vowelsSb.Append(s[i]);
            }

            int it = vowelsSb.Length - 1;
            for (int i = 0; i < s.Length; i++)
            {
                if (!this.isVowel(s[i]))
                {
                    resultSb.Append(s[i]);
                }
                else
                {
                    resultSb.Append(vowelsSb[it--]);
                }
            }

            return resultSb.ToString();
        }

        public bool isVowel(char c)
        {
            return "aeiouAEIOU".IndexOf(c) >= 0;
        }

        // https://leetcode.com/problems/most-common-word/
        public string MostCommonWord(string paragraph, string[] banned)
        {
            StringBuilder wordSb = new StringBuilder();
            List<string> paragraphList = new List<string>();

            for (int i = 0; i < paragraph.Length; i++)
            {
                if (char.IsLetter(paragraph[i]))
                {
                    wordSb.Append(paragraph[i]);
                }
                else if (wordSb.Length > 0)
                {
                    paragraphList.Add(wordSb.ToString().ToLower());
                    wordSb.Clear();
                }
            }

            if (wordSb.Length > 0) paragraphList.Add(wordSb.ToString().ToLower());

            Dictionary<string, int> wordCounts = new Dictionary<string, int>();
            int count = 0;
            string mostCommonWord = "";

            foreach (string word in paragraphList)
            {
                wordCounts[word] = wordCounts.GetValueOrDefault(word, 0) + 1;

                if (!banned.Contains(word) && wordCounts[word] > count)
                {
                    count = wordCounts[word];
                    mostCommonWord = word;
                }
            }

            return mostCommonWord;
        }


        // https://leetcode.com/problems/add-strings/
        public string AddStrings(string num1, string num2)
        {
            StringBuilder sb = new StringBuilder();
            int carry = 0;

            for (int i = num1.Length - 1, j = num2.Length - 1; i >= 0 || j >= 0 || carry == 1; i--, j--)
            {
                int a = i < 0 ? 0 : (int)Char.GetNumericValue(num1[i]);
                int b = j < 0 ? 0 : (int)Char.GetNumericValue(num2[j]);
                sb.Insert(0, (a + b + carry) % 10);
                carry = (a + b + carry) / 10;
            }

            return sb.ToString();
        }
        // https://leetcode.com/problems/add-strings/
        public string AddStringsOld(string num1, string num2)
        {
            int i = num1.Length - 1;
            int j = num2.Length - 1;

            StringBuilder sb = new StringBuilder();
            int count = 0;

            while (i >= 0 && j >= 0)
            {
                int a = (int)Char.GetNumericValue(num1[i]);
                int b = (int)Char.GetNumericValue(num2[j]);

                int sum = a + b + count;
                count = 0;

                if (sum > 9)
                {
                    sb.Insert(0, sum - 10);
                    count++;
                }
                else
                {
                    sb.Insert(0, sum);
                }

                i--;
                j--;
            }

            this.SumRemaining(i, sb, ref count, num1);
            this.SumRemaining(j, sb, ref count, num2);

            if (count > 0) sb.Insert(0, count);

            return sb.ToString();
        }

        public void SumRemaining(int it, StringBuilder sb, ref int count, string remain)
        {
            while (it >= 0)
            {
                int a = (int)Char.GetNumericValue(remain[it]);
                int sum = a + count;
                count = 0;

                if (sum > 9)
                {
                    sb.Insert(0, sum - 10);
                    count++;
                }
                else
                {
                    sb.Insert(0, sum);
                }

                it--;
            }
        }


        // https://leetcode.com/problems/long-pressed-name/
        public bool IsLongPressedName(string name, string typed)
        {
            int i = 0, j = 0;
            char prevLetter = name.ElementAtOrDefault(i);

            while (i < name.Length && j < typed.Length)
            {
                if (name[i] == typed[j])
                {
                    prevLetter = name[i];
                    i++; j++;
                }
                else
                {
                    if (typed[j] == prevLetter) j++;
                    else return false;
                }
            }

            if (i < name.Length) return false;

            if (j < typed.Length)
            {
                // check last typed letters with "prevLetter" of name string
                while (j < typed.Length)
                {
                    if (prevLetter == typed[j]) j++;
                    else return false;
                }
            }

            return true;
        }
        // https://leetcode.com/problems/student-attendance-record-i/
        public bool CheckRecord(string s)
        {
            int lateCount = 0;
            int absentCount = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'L') lateCount++;
                else
                {
                    if (s[i] == 'A') absentCount++;

                    lateCount = 0;
                }


                if (lateCount > 2 || absentCount > 1) return false;
            }

            return true;
        }


        // https://leetcode.com/problems/reverse-string-ii/
        public string ReverseStr(string s, int k)
        {
            StringBuilder sb = new StringBuilder();
            int skipCount = 0;
            bool isSkip = false;
            int it = Math.Min(k, s.Length);

            for (int i = 0; i < s.Length; i++)
            {
                if (skipCount == k)
                {
                    skipCount = 0;
                    isSkip = !isSkip;

                    if (isSkip == false)
                    {
                        it = Math.Min(s.Length, it + k * 2);
                    }
                }

                if (isSkip)
                {
                    sb.Append(s[i]);
                }
                else
                {
                    // reversed
                    char currLetter = s[it - 1 - skipCount];
                    sb.Append(currLetter);
                }

                skipCount++;
            }

            return sb.ToString();
        }

        // https://leetcode.com/problems/first-unique-character-in-a-string/
        public int FirstUniqChar(string s)
        {

            Dictionary<char, int> dic = new Dictionary<char, int>();

            foreach (char letter in s)
            {
                dic[letter] = dic.GetValueOrDefault(letter, 0) + 1;
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (dic[s[i]] == 1) return i;
            }

            return -1;
        }

        // https://leetcode.com/problems/ransom-note/
        public bool CanConstruct(string ransomNote, string magazine)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();

            foreach (char letter in magazine)
            {
                dic[letter] = dic.GetValueOrDefault(letter, 0) + 1;
            }

            for (int i = 0; i < ransomNote.Length; i++)
            {

                if (!dic.ContainsKey(ransomNote[i]) || dic[ransomNote[i]] <= 0)
                {
                    return false;
                }
                else
                {
                    dic[ransomNote[i]]--;
                }
            }

            return true;
        }
        // https://leetcode.com/problems/count-binary-substrings/
        public int CountBinarySubstrings(string s)
        {
            int count = 0;
            int zeroCount = 0;
            int oneCount = 0;
            bool isOneCounting = false;

            for (int i = 0; i < s.Length; i++)
            {
                CountContiguous(s, i, ref count, ref isOneCounting, ref zeroCount, ref oneCount);
            }

            count += Math.Min(zeroCount, oneCount);
            zeroCount = 0;
            oneCount = 0;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                CountContiguous(s, i, ref count, ref isOneCounting, ref zeroCount, ref oneCount);
            }

            count += Math.Min(zeroCount, oneCount);

            return count;
        }

        public void CountContiguous(
            string s,
            int i,
            ref int count,
            ref bool isOneCounting,
            ref int zeroCount,
            ref int oneCount)
        {

            if (s[i] == '0')
            {
                // count contiguous
                if (isOneCounting)
                {
                    count += Math.Min(zeroCount, oneCount);
                    zeroCount = 0;
                    oneCount = 0;
                    isOneCounting = false;
                }
                zeroCount++;
            }
            else
            {
                isOneCounting = true;
                oneCount++;
            }
        }


        public bool isContigious(string s, int startIdx, int endIdx)
        {
            if (endIdx >= s.Length) return false;

            // int middle = (endIdx + startIdx) / 2;            
            int first = s[startIdx];
            int next = s[endIdx];

            while (startIdx < endIdx)
            {
                if (s[startIdx] == s[endIdx] || s[startIdx] == next || s[endIdx] == first)
                {
                    return false;
                }

                startIdx++;
                endIdx--;
            }

            return true;
        }


        // https://leetcode.com/problems/detect-capital/ 
        public bool DetectCapitalUse(string word)
        {
            if (word.Length == 1) return true;

            bool isUpper = false;
            if (char.IsUpper(word[0]) && char.IsUpper(word[1]))
            {
                isUpper = true;
            }
            else if (!char.IsUpper(word[0]) && char.IsUpper(word[1]))
            {
                return false;
            }

            for (int i = 2; i < word.Length; i++)
            {
                if (
                    (isUpper && !char.IsUpper(word[i]))
                    || (!isUpper && char.IsUpper(word[i]))
                    )
                {
                    return false;
                }
            }

            return true;
        }

        // https://leetcode.com/problems/rotated-digits/
        public int RotatedDigits(int N)
        {
            int count = 0;

            for (int i = 1; i <= N; i++)
            {
                if (this.IsGoodNumber(i))
                {
                    count++;
                }
            }

            return count;
        }

        public bool IsGoodNumber(int num)
        {
            return this.IsValidNumber(num) && this.GetRotatedNumber(num) != num;
        }

        public int GetRotatedNumber(int num)
        {
            string numStr = num.ToString();
            StringBuilder sb = new StringBuilder();

            foreach (char n in numStr)
            {
                switch (n)
                {
                    case '0':
                    case '1':
                    case '8':
                        sb.Append(n);
                        break;
                    case '2':
                        sb.Append('5');
                        break;
                    case '5':
                        sb.Append('2');
                        break;
                    case '6':
                        sb.Append('9');
                        break;
                    case '9':
                        sb.Append('6');
                        break;
                    default:
                        break;
                }
            }

            return int.Parse(sb.ToString());
        }

        public bool IsValidNumber(int num)
        {
            string numStr = num.ToString();

            foreach (char n in numStr)
            {
                if ("0182569".IndexOf(n) < 0)
                {
                    return false;
                }
            }

            return true;
        }


        // https://leetcode.com/problems/reverse-only-letters/
        public string ReverseOnlyLetters(string S)
        {
            Stack<char> stack = new Stack<char>();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < S.Length; i++)
            {
                if (char.IsLetter(S[i]))
                {
                    stack.Push(S[i]);
                }
            }

            for (int i = 0; i < S.Length; i++)
            {
                if (!char.IsLetter(S[i]))
                {
                    sb.Append(S[i]);
                }
                else
                {
                    sb.Append(stack.Pop());
                }
            }

            return sb.ToString();
        }
        // https://leetcode.com/problems/longest-uncommon-subsequence-i/
        public int FindLUSlength(string a, string b)
        {
            if (a.Length > b.Length) return a.Length;
            else if (b.Length > a.Length) return b.Length;

            else
            {
                // the same length
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] != b[i])
                    {
                        return a.Length;
                    }
                }

                return -1;
            }
        }

        // https://leetcode.com/problems/goat-latin/
        public string ToGoatLatin(string S)
        {
            if (S.Length == 0) return S;

            StringBuilder postfix = new StringBuilder("a");
            StringBuilder result = new StringBuilder();
            string[] wordArr = S.Split(' ');

            foreach (string word in wordArr)
            {
                if ("aeiouAEIOU".IndexOf(word[0]) >= 0)
                {
                    result.Append(word)
                        .Append("ma")
                        .Append(postfix)
                        .Append(" ");
                }
                else
                {
                    string first = word.Substring(0, 1);
                    string others = word.Substring(1);

                    result.Append(others)
                        .Append(first)
                        .Append("ma")
                        .Append(postfix)
                        .Append(" ");
                }

                postfix.Append('a');
            }

            return result.ToString().TrimEnd();
        }


        // https://leetcode.com/problems/reorder-log-files/
        public string[] ReorderLogFiles(string[] logs)
        {
            List<string> digitLogs = new List<string>();
            List<string> letterLogs = new List<string>();

            foreach (string log in logs)
            {
                string[] words = log.Split(' ');
                if (char.IsDigit(words[1][0]))
                    digitLogs.Add(log);
                else
                    letterLogs.Add(log);
            }

            letterLogs.Sort((string a, string b) =>
            {
                string aComp = a.Substring(a.IndexOf(' '));
                string bComp = b.Substring(b.IndexOf(' '));
                return string.Compare(aComp, bComp);
            });

            letterLogs.AddRange(digitLogs);

            return letterLogs.ToArray();
        }

        public int NumSpecialEquivGroups(string[] A)
        {
            HashSet<string> set = new HashSet<string>();
            foreach (string word in A)
            {
                int[] count = new int[52];
                for (int i = 0; i < word.Length; i++)
                {
                    count[word[i] - 'a' + 26 * (i % 2)]++;
                }

                set.Add(string.Join(',', count));
            }

            return set.Count;
        }

        // https://leetcode.com/problems/groups-of-special-equivalent-strings/
        public int NumSpecialEquivGroupsOld(string[] A)
        {
            var list = new List<string>(A);
            ArrayList result = new ArrayList();
            ArrayList evenOdds = new ArrayList();

            for (int i = 0; i < A.Length; i++)
            {
                string currWord = A[i];
                evenOdds.Add(this.GetOddEvenWords(currWord));
            }


            while (evenOdds.Count > 0)
            {
                var removingList = new List<ArrayList>();
                ArrayList currEvenOdds = evenOdds[0] as ArrayList;
                List<ArrayList> chunk = new List<ArrayList>() { currEvenOdds };

                evenOdds.RemoveAt(0);

                for (int i = 0; i < evenOdds.Count; i++)
                {
                    ArrayList nextEvenOdds = evenOdds[i] as ArrayList;
                    if (this.IsEvenOddsEqual(currEvenOdds, nextEvenOdds))
                    {
                        removingList.Add(nextEvenOdds);
                    }
                }

                foreach (ArrayList removingItm in removingList)
                {
                    evenOdds.Remove(removingItm);
                }

                result.Add(chunk);
            }

            return result.Count;
        }

        public bool IsEvenOddsEqual(ArrayList currEvenOdds, ArrayList nextEvenOdds)
        {
            List<char> currEvens = currEvenOdds[0] as List<char>;
            List<char> currOdds = currEvenOdds[1] as List<char>;

            List<char> nextEvens = nextEvenOdds[0] as List<char>;
            List<char> nextOdds = nextEvenOdds[1] as List<char>;

            if (currEvens.Count != nextEvens.Count || currOdds.Count != nextOdds.Count)
            {
                return false;
            }

            for (int i = 0; i < currEvens.Count; i++)
            {
                if (currEvens[i] != nextEvens[i]) return false;
            }

            for (int i = 0; i < currOdds.Count; i++)
            {
                if (currOdds[i] != nextOdds[i]) return false;
            }

            return true;
        }

        public ArrayList GetOddEvenWords(string currWord)
        {
            var result = new ArrayList();
            var evens = new List<char>();
            var odds = new List<char>();

            for (int i = 0; i < currWord.Length; i++)
            {
                if (i % 2 == 0)
                    evens.Add(currWord[i]);
                else
                    odds.Add(currWord[i]);
            }

            evens.Sort();
            odds.Sort();

            result.Add(evens);
            result.Add(odds);

            return result;
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


}
