using System;

class GravitationOnTheMoon
{
    static void Main()
    {
        float weight = float.Parse(Console.ReadLine());
        float weigthOnTheMoon = weight * 0.17f;
        Console.WriteLine("Weight on the moon: {0:0.000}", weigthOnTheMoon);
    }
}

