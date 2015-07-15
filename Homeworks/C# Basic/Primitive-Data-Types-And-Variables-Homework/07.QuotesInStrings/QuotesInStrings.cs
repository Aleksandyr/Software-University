using System;

class QuotesInStrings
{
    static void Main()
    {
        string withQuoted = @"The ""use"" of quotations causes difficulties.";
        string withoutQuoted = "The \"use\" of quotations causes difficulties.";
        Console.WriteLine(withQuoted);
        Console.WriteLine(withoutQuoted);
    }
}

