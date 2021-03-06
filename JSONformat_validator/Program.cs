﻿using System;

namespace JSONformat_validator
{
    public class Program
    {
        public static void IsStringValid(string word)
        {
            bool checker = false;
            string checkHexadecimalPart = FindHexadecimalPart(word);
            if (checkHexadecimalPart != string.Empty)
                 checker = CheckFirstAndLastCharacters(checkHexadecimalPart) && (CheckSpecialCharacters(checkHexadecimalPart));
            else
                 checker= CheckFirstAndLastCharacters(word) && (CheckSpecialCharacters(word));

            if (checker)
                    Console.Write("Valid"+"\n");
            else
                Console.Write("Invalid"+"\n");
        }

        static void Main(string[] args)
        {
            IsStringValid(Console.ReadLine());
            if (IsStringJSONNumber(Console.ReadLine()))
                Console.Write("Valid");
            else
                Console.Write("Invalid");
            Console.ReadLine();
        }

        public static bool CheckFirstAndLastCharacters(string word)
        {
            int lastIndex = word.Length - 1;
            return !(word[0] != '\"' || word[lastIndex] != '\"');
              
            
        }

        public static bool CheckSpecialCharacters(string word)
        {
            char controlCharacter = (char)127;
            for(int i = 1; i < word.Length-1; i++)
            {
                if (word[i] == '\\')
                {
                    
                    if (!CheckEscapeCharacters(word[i + 1]))
                        return false;
                    else
                        i++;
                  
                }//caracterele backslash(mai putin pt hexadecimal, care e tratat separat

                 if (word[i] == controlCharacter || word[i]=='"'|| word[i]<' ')
                {
                    if (word[i - 1] != '\\')
                        return false;
                }//caracterele control+ " 

                if (word.LastIndexOf('\\') == word.Length - 2)
                {
                    if (word[word.Length - 3] != '\\')
                        return false;
                }
                //trateaza cazul special, de forma "abc\"
            }
            return true;
        }

        public static bool CheckEscapeCharacters(char character)
        {
            string backslashCharacters = "\"\\/bfnrt";
            foreach(var symbol in backslashCharacters)
            {
                if (symbol == character)
                    return true;
            }
            return false;
            
           
        }

       public static string FindHexadecimalPart(string word)
        {
            string result = "";
            for (int i = 1; i < word.Length - 4; i++)
            {
                if (word.IndexOf("\\u") > -1)
                {
                    int index = word.IndexOf("\\u");
                    string checkValue = word.Substring(index + 2, 4);
                    if (word[index - 1] == '\\')
                        return word;
                    else if (CheckUnicodeCharacters(checkValue))
                         result=FormatWord(index, index + 5, word);    
                      
                }

            }
            return result;
            
        }
        public static bool CheckUnicodeCharacters(string word)
        {
            
            for(int i = 0; i < word.Length;i++)
            {
                char hex = word[i];
                bool flag = false;
                if (hex < 47 || hex > 58)
                    flag= true;
                
                if (flag && (hex < 64 || hex > 71))
                        return false;
            }
            
            return true;
        }
        
        public static string FormatWord(int leftPoint,int rightPoint,string word)
        {
            int length = word.Length - 1;
            string leftPart = word.Substring(0, leftPoint);
            string rightPart = word.Substring(rightPoint + 1, length-rightPoint);
            string newWord = leftPart + rightPart;

            return newWord;
        }
        
        public static bool IsStringJSONNumber(string word)
        {
            
            return (word!=string.Empty&&CheckDigitsForJSONNumber(word));
            
        }

        static bool CheckDigitsForJSONNumber(string word)
        {
            if (word[0] == '0' && word.Length > 1)
                return CheckDecimalPart(word.Substring(0, word.Length ));
              
               
            for (int i = 0; i < word.Length; i++)
            {
                if (word[0] == '-'||word[0]=='+')
                {
                    if (word[1] == '0')
                        return false;
                    continue;
                }
                if (word[i] == '.')
                {
                    int index = i;
                    return CheckDecimalPart(word.Substring(index, (word.Length  - index)));
                    
                }
                    
                if (word[i] >= '9' || word[i] < '0')
                    return false;
            }
            return true;
        }

        static bool CheckDecimalPart(string decimalPart)
        {

            int search = decimalPart.IndexOf(".");
            int lastSearch = decimalPart.LastIndexOf(".");
            if (decimalPart.Length == 1||search==-1)
                return false;
            if (search!=lastSearch)
                return false;
            for(int i = 0; i < decimalPart.Length; i++)
            {
                if (decimalPart[i] == 'E'||decimalPart[i]=='e')
                {
                    int length = decimalPart.Length-1;
                    return CheckDigitsForJSONNumber(decimalPart.Substring(i + 1, length - i));
                }
                    
            }
            return true;
        }

    }
}
