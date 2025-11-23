namespace Passwords;

using System;
using System.Collections.Generic;

public class CaseAlternatorTask
{
    public static List<string> AlternateCharCases(string lowercaseWord)
    {
        var result = new HashSet<string>(); 
        AlternateCharCases(lowercaseWord.ToCharArray(), 0, result);
        var resultList = new List<string>(result);
        resultList.Sort();
        return resultList;
    }

    static void AlternateCharCases(char[] word, int startIndex, HashSet<string> result)
    {
        if (startIndex == word.Length)
        {
            result.Add(new string(word));
            return;
        }

        AlternateCharCases(word, startIndex + 1, result);

        if (char.IsLetter(word[startIndex]))
        {
            word[startIndex] = char.IsLower(word[startIndex]) ? char.ToUpper(word[startIndex]) : char.ToLower(word[startIndex]);
            AlternateCharCases(word, startIndex + 1, result);
            word[startIndex] = char.IsLower(word[startIndex]) ? char.ToUpper(word[startIndex]) : char.ToLower(word[startIndex]);
        }
    }
}
