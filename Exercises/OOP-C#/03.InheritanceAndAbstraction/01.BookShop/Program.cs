using System;
using BookInfo;
using GoldenEditionBookInfo;

namespace BookShop
{
    class Program
    {
        static void Main()
        {
            Book book = new Book("Pod Igoto", "Ivan Vazov", 15.90);
            Console.WriteLine(book);

            Console.WriteLine();

            GoldenEditionBook goldBook = new GoldenEditionBook("Tutun", "Dimitar Dimov", 22.90);
            Console.WriteLine(goldBook);
        }
    }
}
