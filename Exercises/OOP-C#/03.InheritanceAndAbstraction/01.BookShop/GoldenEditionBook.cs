using System;
using BookInfo;

namespace GoldenEditionBookInfo
{
    public class GoldenEditionBook : Book
    {
        public GoldenEditionBook(string title, string author, double price) : 
            base(title, author, price)
        {
        }

        public override double Price
        {
            get
            {
                return base.Price += (base.Price * 0.30);
            }
            set
            {
                base.Price = value;
            }
        }
    }
}
