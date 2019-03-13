using System;

namespace JSONformat_validator
{
    public class Program
    {
        public static void IsStringValid(string word)
        {
            if (CheckFirstAndLastCharacters(word))
                Console.Write("Valid");
            else
                Console.Write("Invalid");
        }

        static void Main(string[] args)
        {
            IsStringValid(Console.ReadLine()); 
        }

        public static bool CheckFirstAndLastCharacters(string word)
        {
            int lastIndex = word.Length - 1;
            if (word[0] != '\"' || word[lastIndex] != '\"')
            {
                return false;
            }
            if (!CheckSpecialCharacters(word))
                return false;

            return true;     
            
        }

        public static bool CheckSpecialCharacters(string word)
        {
            for(int i = 1; i < word.Length; i++)
            {
                if (word[i] < 32 || word[i] == 127)
                {
                    if (word[i - 1] != '\\')
                        return false;
                }
                if (word[i] == '\\' && word[i - 1] != '\\')
                    return false;

                    
            }
            return true;
        }

        public static bool CheckUnicodeCharacters(string word)
        {

            return true;
        }
        
        
        


    }
}
