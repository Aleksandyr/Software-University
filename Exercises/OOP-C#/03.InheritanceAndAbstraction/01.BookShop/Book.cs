using System;

namespace BookInfo
{
    public class Book
    {
        private string title;
        private string author;
        private double price;

        public Book(string title, string author, double price)
        {
            this.Title = title;
            this.Author = author;
            this.Price = price;
        }

        public string Title 
        { 
            get
            {
                return this.title;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Title can not be null or empty");
                }

                this.title = value;
            }
        }

        public string Author
        {
            get
            {
                return this.author;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Title can not be null or empty");
                }

                this.author = value;
            }
        }

        public virtual double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price can not be negative!");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            string result = string.Format("-Type: {0} \n-Title: {1} \n-Author: {2} \n-Price: {3}",this.GetType().Name, this.Title, this.Author, this.Price);
            return result;
        }
    }
}
