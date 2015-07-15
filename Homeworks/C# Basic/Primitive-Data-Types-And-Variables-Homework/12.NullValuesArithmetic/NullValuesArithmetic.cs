using System;

class NullValuesArithmetic
{
    static void Main()
    {
        int? firstVeriable = null;
        double? secondVeriable = null;

        Console.WriteLine("first veriable: " + firstVeriable.GetValueOrDefault());
        Console.WriteLine("second veriable: " + secondVeriable.GetValueOrDefault());

        firstVeriable = 6;
        secondVeriable = 7;
        Console.WriteLine("after adding a few values:");
        Console.WriteLine("first veriable: " + firstVeriable);
        Console.WriteLine("second veriable: " + secondVeriable);
    }
}

