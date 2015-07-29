using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Web.Script.Serialization;
using System.Xml.Linq;
using System.Xml.XPath;
using Newtonsoft.Json.Linq;
using ProductsShop.Model;

namespace ProductsShop.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductsShop.Data.ProductsShopEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ProductsShop.Data.ProductsShopEntities context)
        {
            //Fill users
            //var xmlDoc = XDocument.Load("../../users.xml");
            //var rootNode = xmlDoc.XPathSelectElements("users/user");
            //foreach (XElement node in rootNode)
            //{
            //    var user = new User();
            //    if (node.Attribute("first-name") != null)
            //    {
            //        user.FirstName = node.Attribute("first-name").Value;
            //    }
            //    if (node.Attribute("last-name") != null)
            //    {
            //        user.LastName = node.Attribute("last-name").Value;
            //    }
            //    if (node.Attribute("age") != null)
            //    {
            //        user.Age = int.Parse(node.Attribute("age").Value);
            //    }

            //    context.Users.AddOrUpdate(user);
            //}

            //context.SaveChanges();


            //FILL Categories
            //var jsonCategories = File.ReadAllText("../../categories.json");
            //var deserializer = new JavaScriptSerializer();
            //var categories = deserializer.Deserialize<Category[]>(jsonCategories);
            //foreach (var category in categories)
            //{
            //    var currCategory = new Category();
            //    currCategory.Name = category.Name;

            //    context.Categories.AddOrUpdate(currCategory);
            //}

            //context.SaveChanges();


            //FILL Products
            //var json = File.ReadAllText("../../products.json");
            //var deserializer = new JavaScriptSerializer();
            //var products = deserializer.Deserialize<Product[]>(json);
            //var categoryIds = context.Categories.Select(c => c.Id).ToList();
            //var usersIds = context.Users.Select(u => u.Id).ToList();
            //var rnd = new Random();
            //foreach (var product in products)
            //{
            //    var sellerId = usersIds[rnd.Next(0, usersIds.Count + 1)];
            //    var buyerId = usersIds[rnd.Next(0, usersIds.Count + 1)];
            //    var categoryId = categoryIds[rnd.Next(0, categoryIds.Count + 1)];
            //    var saller = context.Users.Find(sellerId);
            //    var buyer = context.Users.Find(buyerId);
            //    var category = context.Categories.Find(categoryId);
            //    var currProduct = new Product()
            //    {
            //        Seller = saller,
            //        Name = product.Name,
            //        Price = product.Price,
            //        Categories = new List<Category>()
            //        {
            //            category
            //        }
            //    };

            //    if (rnd.Next(0, 10) != 0)
            //    {
            //        currProduct.Buyer = buyer;
            //    }

            //    context.Products.AddOrUpdate(currProduct);
            //}

            //context.SaveChanges();
        }
    }
}
