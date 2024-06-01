using System.Linq;

namespace MyWebApi.Console;

public class NumbersExcercise
{
    public static long[] ReverseNumber(long n)
    {
        var result = n.ToString().Reverse().ToArray();
        
        return result.Select(x => long.Parse(x.ToString())).ToArray();
    }
}