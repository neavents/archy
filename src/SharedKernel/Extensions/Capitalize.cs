using System;

namespace SharedKernel.Extensions;

public static class Capitalize
{
    public static string CapitalizeFirst(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        return char.ToUpper(input[0]) + input[1..];
    }

}
