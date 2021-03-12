using System;
using System.Collections.Generic;
using System.Text;

namespace Project._2021 {
    public class Repeated_DNA_Sequences {

        // 0000000000111111111122, L: 22

        // 000111 L: 6
        public IList<string> FindRepeatedDnaSequences(string s) {
            var result = new List<string>();

            for (int i = 0; i < s.Length - 10; i++) {
                string substr = s.Substring(i, 10);

                for (int j = i + 10; j < s.Length - 10 + 1; j++) {
                    string nextSubstr = s.Substring(j, 10);
                    
                    if (string.Equals(substr, nextSubstr)) {
                        result.Add(substr);
                    } 
                }
            }

            return result;
        }
    }
}
