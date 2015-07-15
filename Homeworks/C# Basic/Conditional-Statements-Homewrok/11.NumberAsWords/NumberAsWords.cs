using System;

class NumberAsWords
{
    static void Main()
    {
        int num;
        do
        {
            Console.Write("The number must be between[0...999]: ");
            num = int.Parse(Console.ReadLine());    
        } 
        while (num < 0 || num > 999);
        
        string[] numsWords = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", 
        "eleven", "twelve", "thirteen", "foutreen", "fiftheen", "sixteen", "seventeen", "eihteen", "nineteen"};
        
        if(num >= 0 && num <= 19)
        {
            Console.WriteLine(numsWords[num]);
        }

        string[] tens = { "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eightty", "ninety" };
        if (num >= 20 && num <= 99)
        {
            Console.Write(tens[num / 10 - 2]);
            if (num % 10 > 0)
            {
                Console.WriteLine(" " + numsWords[num % 10]);
            }
        }

        if (num >= 100 & num <= 999)
        {
            string[] thousandth = { "one hundred and ", "two hundred and ", "three hundred and ", "four hundred and ", "five hundred and ", "six hundred and " 
                                  , "seven hundred and ", "eight hundred and ", "nine hundred and "};

            Console.Write(thousandth[num / 100 - 1]);
            if ((num / 10) % 10 > 0)
            {
                if ((num / 10) % 10 < 2)
                {
                    Console.WriteLine(numsWords[num % 100]);
                    return;
                }
                else
                {
                    Console.Write(tens[(num / 10) % 10 - 2]);
                }
            }
            if (num % 10 > 0)
            {
                Console.WriteLine(" " + numsWords[num % 10]);
            }
        }
    }
}

