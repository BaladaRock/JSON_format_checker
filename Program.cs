using System;

namespace JSONformat_validator
{
    public class Program
    {

        public static bool CheckJSONString(string word)
        {
            int lastIndex = word.Length - 1;
            if (word[0] != '\"' || word[lastIndex] != '\"')
                return false;
            return true;
        }

        static void Main(string[] args)
        {
            IsStringValid(Console.ReadLine()); 
        }

        static void IsStringValid(string word)
        {
            if (CheckJSONString(word))
                Console.Write("Valid");
            else
                Console.Write("Invalid");
        }
    }
}
