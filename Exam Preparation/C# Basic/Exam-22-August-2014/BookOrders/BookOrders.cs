using System;

class BookOrders
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        
        double finalPrice = 0;
        int allBoughtBooks = 0;

        for (int i = 0; i < n; i++)
        {
            int packets = int.Parse(Console.ReadLine());
            int booksPerPacket = int.Parse(Console.ReadLine());
            float bookPrice = float.Parse(Console.ReadLine());

            int allOrderBooks = packets * booksPerPacket;
            allBoughtBooks += allOrderBooks;

            double discount = 0;
            if (packets >= 10 && packets < 110)
            {
                discount = (packets / 10) + 4;
            }
            else if (packets >= 110)
            {
                discount = 15;
            }
            double priceWithDiscount = bookPrice * (100 - discount) / 100;
            
            finalPrice += priceWithDiscount * allOrderBooks;
        }
        Console.WriteLine(allBoughtBooks);
        Console.WriteLine("{0:F2}", finalPrice);


        //My decision
        //int oreders = int.Parse(Console.ReadLine());

        //int allBoughtBooks = 0;
        //double allPrice = 0;
        //for (int i = 0; i < oreders; i++)
        //{
        //    int packets = int.Parse(Console.ReadLine());
        //    int booksInPacket = int.Parse(Console.ReadLine());
        //    double price = double.Parse(Console.ReadLine());

        //    int allOrderBooks = packets * booksInPacket;
        //    allBoughtBooks += packets * booksInPacket;

        //    double priceWithDiscount = 0;
        //    if (packets < 10)
        //    {
        //        priceWithDiscount = price * (100 - 0) / 100;
        //    }
        //    else if (packets >= 10 && packets <= 19)
        //    {
        //        priceWithDiscount = price * (100 - 5) / 100;
        //    }
        //    else if (packets >= 20 && packets <= 29)
        //    {
        //        priceWithDiscount = price * (100 - 6) / 100;
        //    }
        //    else if (packets >= 30 && packets <= 39)
        //    {
        //        priceWithDiscount = price * (100 - 7) / 100;
        //    }
        //    else if (packets >= 40 && packets <= 49)
        //    {
        //        priceWithDiscount = price * (100 - 8) / 100;
        //    }
        //    else if (packets >= 50 && packets <= 59)
        //    {
        //        priceWithDiscount = price * (100 - 9) / 100;
        //    }
        //    else if (packets >= 60 && packets <= 69)
        //    {
        //        priceWithDiscount = price * (100 - 10) / 100;
        //    }
        //    else if (packets >= 70 && packets <= 79)
        //    {
        //        priceWithDiscount = price * (100 - 11) / 100;
        //    }
        //    else if (packets >= 80 && packets <= 89)
        //    {
        //        priceWithDiscount = price * (100 - 12) / 100;
        //    }
        //    else if (packets >= 90 && packets <= 99)
        //    {
        //        priceWithDiscount = price * (100 - 13) / 100;
        //    }
        //    else if (packets >= 100 && packets <= 109)
        //    {
        //        priceWithDiscount = price * (100 - 14) / 100;
        //    }
        //    else if (packets >= 110)
        //    {
        //        priceWithDiscount = price * (100 - 15) / 100;
        //    }

        //    allPrice += allOrderBooks * priceWithDiscount;
        //}

        //Console.WriteLine(allBoughtBooks);
        //Console.WriteLine("{0:0.00}", allPrice);
    }
}

