using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode {
    internal class Valid_Parenthesis_String {

        public bool CheckValidString(string s) {
            if (s.Length == 0) return true;

            if (s[0] == ')') return false;

            var stack = new Stack<char>();
            int leftCount = 0, rightCount = 0, starCount = 0;
           
            for (int i = 0; i < s.Length; i++) {
                if(s[i] == ')') {
                    if (stack.Count == 0) return false;

                    if (stack.Count > 0 && stack.Peek() == '(') {
                        stack.Pop();
                    } else {
                        stack.Push(s[i]);
                    }
                } else {
                    stack.Push(s[i]);
                }
            }


            s = string.Join("", stack.ToArray());
            stack.Clear();           


            for (int i = 0; i < s.Length; i++) {
                if (s[i] == '(') {

                    if (rightCount > 0) {
                        
                        // remove all rightCount
                        int count = 0;
                        while (stack.Count > 0 && (rightCount > 0 || count > 0)) {
                            char val = stack.Pop();

                            if (val == '*') {
                                starCount--;
                                //count++;
                            } else if (val == '(') {
                                leftCount--;
                                count--;
                            } else if (val == ')') {
                                rightCount--;
                                count++;
                            }
                        }
                    }

                    stack.Push(s[i]);
                    leftCount++;

                } else if (s[i] == ')') {

                    if (stack.Count == 0) return false;

                    if (stack.Count > 0 && stack.Peek() == '(') {
                        stack.Pop();
                        leftCount--;
                    } else {
                        stack.Push(s[i]);
                        rightCount++;
                    }

                } else if (s[i] == '*') {
                    stack.Push(s[i]);
                    starCount++;
                }

            }

            Console.WriteLine("Hello " + leftCount + " " + starCount + " " + rightCount);

            PrintStack(stack);

            if (stack.Count > 0 && stack.Peek() == '(') return false;

            int diff = Math.Abs(leftCount - rightCount);

            if (diff > starCount) return false;

            return true;
        }

        public void PrintStack(Stack<char> stack) {
            char[] arr = stack.ToArray();
            Array.Reverse(arr);
            string str = string.Join("", arr);
            Console.WriteLine(str);
        }


        public bool CheckValidString(string s) {
            if (s.Length == 0) return true;

            var stack = new Stack<char>();
            int stars = 0;

            for (int i = 0; i < s.Length; i++) {
                if (s[i] == '(') {
                    stack.Push(s[i]);
                } else if (s[i] == ')') {

                    if (stack.Count > 0) {
                        int val = stack.Pop();
                    } else if (stars > 0) {
                        stars--;
                    } else {
                        return false;
                    }

                } else if (s[i] == '*') {
                    stars++;
                }
            }

            while (stars > 0 && stack.Count > 0) {
                stack.Pop();
            }

            if (stack.Count > 0) return false;

            return true;
        }
    }
}
