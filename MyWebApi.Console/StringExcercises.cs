using System;

namespace MyWebApi.Console;

public class StringExcercises
{
    public static string GetReverseString(string str)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(str);
        if (str.Length == 1) return str;
        
        var charArray = str.ToCharArray();
        Array.Reverse(charArray);
        return new String(charArray);
    }
    
    // []                                -->  "no one likes this"
    // ["Peter"]                         -->  "Peter likes this"
    // ["Jacob", "Alex"]                 -->  "Jacob and Alex like this"
    // ["Max", "John", "Mark"]           -->  "Max, John and Mark like this"
    // ["Alex", "Jacob", "Mark", "Max"]  -->  "Alex, Jacob and 2 others like this"
    
    public static string Likes(string[] names)
    {
        if (names.Length == 0) return "no one likes this";
        if (names.Length == 1) return $"{names[0]} likes this";
        if (names.Length == 2) return $"{names[0]} and {names[1]} like this";
        if (names.Length == 3) return $"{names[0]}, {names[1]} and {names[2]} like this";
        return $"{names[0]}, {names[1]} and {names.Length - 2} others like this";
    }
}