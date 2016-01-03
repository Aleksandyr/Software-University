using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace Orders
{
    class Program
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var dataMapper = new DataMapper();
            var allCategories = dataMapper.getAllCategories();
            var allProducts = dataMapper.getAllProducts();
            var allOrders = dataMapper.getAllOrders();

            // Names of the 5 most expensive products
            var FiveMostExpensiveProducts = allProducts
                .OrderByDescending(p => p.UnitPrice)
                .Take(5)
                .Select(p => p.Name);
            Console.WriteLine(string.Join(Environment.NewLine, FiveMostExpensiveProducts));

            Console.WriteLine(new string('-', 10));

            // Number of products in each category
            var NumsOfProductsForEachCategory = allProducts
                .GroupBy(p => p.CategoryId)
                .Select(grp => new 
                { 
                    Category = allCategories.First(c => c.Id == grp.Key).Name, 
                    Count = grp.Count() 
                }).ToList();

            foreach (var item in NumsOfProductsForEachCategory)
            {
                Console.WriteLine("{0}: {1}", item.Category, item.Count);
            }

            Console.WriteLine(new string('-', 10));

            // The 5 top products (by order quantity)
            var FiveTopProductsOrderedByQuantity = allOrders
                .GroupBy(o => o.ProductId)
                .Select(grp => new 
                { 
                    Product = allProducts.First(p => p.Id == grp.Key).Name, 
                    Quantities = grp.Sum(grpgrp => grpgrp.Quantity) 
                })
                .OrderByDescending(q => q.Quantities)
                .Take(5);

            foreach (var item in FiveTopProductsOrderedByQuantity)
            {
                Console.WriteLine("{0}: {1}", item.Product, item.Quantities);
            }

            Console.WriteLine(new string('-', 10));

            // The most profitable category
            var category = allOrders
                .GroupBy(o => o.ProductId)
                .Select(g => new 
                { 
                    CategoryId = allProducts.First(p => p.Id == g.Key).CategoryId, 
                    Price = allProducts.First(p => p.Id == g.Key).UnitPrice, 
                    Quantity = g.Sum(q => q.Quantity) 
                })
                .GroupBy(g => g.CategoryId)
                .Select(grp => new { 
                    CategoryName = allCategories.First(c => c.Id == grp.Key).Name, 
                    TotalQuantity = grp.Sum(g => g.Quantity * g.Price) 
                })
                .OrderByDescending(g => g.TotalQuantity)
                .First();
            Console.WriteLine("{0}: {1}", category.CategoryName, category.TotalQuantity);
        }
    }
}
