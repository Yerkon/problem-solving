using System;
using System.Collections.Generic;
using System.Text;

namespace Project._2021 {
    public class Repeated_DNA_Sequences {

        // 0000000000111111111122, L: 22

        // 000111 L: 6

        public IList<string> FindRepeatedDnaSequences(string s) {
            var set = new HashSet<string>();
            var resultSet = new HashSet<string>();
            var sb = new StringBuilder();
         
            for (int i = 0; i < s.Length - 10 + 1; i++) {

                if (sb.Length > 0) sb.Remove(0, 1);

                while (sb.Length < 10) {
                    char ch = s[i + sb.Length];
                    sb.Append(ch);
                }

                string substr = sb.ToString();
                if (!set.Add(substr)) {
                    resultSet.Add(substr);
                };
            }

            var result = new List<string>();

            foreach (string item in resultSet) {
                result.Add(item);
            }

            return result;
        }


        public IList<string> FindRepeatedDnaSequences2(string s) {
            var set = new HashSet<string>();
            var resultSet = new HashSet<string>();
            var sb = new StringBuilder();
            var secondSb = new StringBuilder();

            for (int i = 0; i < s.Length - 10; i++) {

                if(sb.Length > 0) sb.Remove(0, 1);

                while(sb.Length < 10) {
                    char ch = s[i + sb.Length];
                    sb.Append(ch);
                }

                string substr = sb.ToString();
                if (set.Contains(substr)) continue;

                secondSb.Clear();
                for (int j = i + 1; j < s.Length - 10 + 1; j++) {

                    if (secondSb.Length > 0) secondSb.Remove(0, 1);

                    while (secondSb.Length < 10) {
                        char ch = s[j + secondSb.Length];
                        secondSb.Append(ch);
                    }

                    if(sb.Equals(secondSb)) {
                        set.Add(substr);
                        break;
                    }
                }
            }
                
            var result = new List<string>();

            foreach (string item in set) {
                result.Add(item);
            }

            return result;
        }
    }
}
