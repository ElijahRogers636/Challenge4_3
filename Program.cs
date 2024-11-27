﻿

namespace Challenge4_3
{
    internal class Program
    {
        // Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        //Make sure stack is clear at end
        static void Main(string[] args)
        {
            string s = "{([])}";
            string t = "}(}[])";
            string z = "[}";
            string w = "{{{{{";

            var bracketPairs = new Dictionary<char, char>()
            {
                { ')', '(' },
                { '}', '{' },
                { ']', '[' }
            };

            Console.WriteLine(ValidBrackets(s, bracketPairs));
            Console.WriteLine(ValidBrackets(t, bracketPairs));
            Console.WriteLine(ValidBrackets(z, bracketPairs));
            Console.WriteLine(ValidBrackets(w, bracketPairs));
        }

        static bool ValidBrackets(string s, Dictionary<char, char> dict)
        {
            Stack<char> stack = new Stack<char>();

            // If the string is empty or Null return false
            if (string.IsNullOrEmpty(s)) return false;

            foreach (char c in s)
            {
                // If it's a closing bracket, check for match
                if (dict.ContainsKey(c))
                {
                    // Check if the stack is empty or the top doesn't match
                    if (stack.Count == 0 || stack.Pop() != dict[c])
                    {
                        return false;
                    }
                }
                else
                {
                    // If it's an opening bracket, push to stack
                    stack.Push(c);
                }
            }

            // If the stack is empty, all parentheses are matched
            return stack.Count == 0;
        }
    }

}
