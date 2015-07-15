using System;

class LettersSymbolsNumbers 
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int sumAlphabet = 0;
        int sumNumber = 0;
        int sumSymbols = 0;

        for (int i = 0; i < n; i++)
		{
            
            //Input my string
            string line = Console.ReadLine();
            
            //Make letters big
            line = line.ToUpper();

            //Remove spaces in string.
            line = line.Replace(" ", "");
            
            for (int k = 0; k < line.Length; k++)
            {
                char currentChar = line[k];
                
                if (currentChar >= 'A' && currentChar <= 'Z')
                {
                    sumAlphabet += (currentChar - 'A' + 1) * 10;
                }
           
                else if (currentChar >= '0' && currentChar <= '9')
                {
                    sumNumber += (currentChar - '0') * 20;
                }
           
                else
                {
                    sumSymbols += 200;
                }
            }
		}

        Console.WriteLine(sumAlphabet);
        Console.WriteLine(sumNumber);
        Console.WriteLine(sumSymbols);
    }
}

