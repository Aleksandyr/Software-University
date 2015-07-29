using System;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Linq;
using ProductsShop.Data;

namespace ProductsShop.ConsoleClient
{
    class ConsoleClient
    {
        static void Main()
        {
            var db = new ProductsShopEntities();
            var prouctsWithoutBuyer = 
                db.Products
                    .OrderBy(p => p.Price)
                    .Where(p => p.Price <= 1000 && p.Price >= 500 && p.Buyer == null)
                    .Select(p => new
                    {
                        productName = p.Name,
                        price = p.Price,
                        saller = p.Seller.FirstName + " " + p.Seller.LastName
                    })
                    .ToList();
            var serialize = new JavaScriptSerializer();
            var productsJson = serialize.Serialize(prouctsWithoutBuyer);
            //File.WriteAllText("../../products-in-range.json", productsJson);

            var users = db.Users
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Where(u => u.ProductsSold.Count > 1 && u.ProductsSold.Count(p => p.Buyer != null) > 0)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    soldProducts = u.ProductsSold.Select(p => new
                    {
                        p.Name,
                        p.Price,
                        buyerFirstName = p.Buyer.FirstName,
                        buyerLastName = p.Buyer.LastName
                    })
                }).ToList();
            var usersJson = serialize.Serialize(users);
            //File.WriteAllText("../../users-sold-products.json", usersJson);


            var categories = db.Categories
                .OrderByDescending(c => c.Products.Count)
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.Products.Count,
                    averagePrice = c.Products.Select(p => p.Price).Average(),
                    totalRevenu = c.Products.Select(p => p.Price).Sum()
                }).ToList();

            var categoriesJson = serialize.Serialize(categories);
            //File.WriteAllText("../../categories-by-products.json", categoriesJson);

            var usersXml =
                db.Users.Where(u => u.ProductsSold.Count > 1)
                    .OrderByDescending(u => u.ProductsSold.Count)
                    .ThenBy(u => u.LastName)
                    .Select(u => new
                    {
                        firstName = u.FirstName,
                        lastName = u.LastName,
                        age = u.Age,
                        Products = u.ProductsSold.Select(p => new
                        {
                            productName = p.Name,
                            price = p.Price
                        })
                    });

            XElement root = new XElement("users");
            root.SetAttributeValue("count", usersXml.Count());
            foreach (var userNode in usersXml)
            {
                var user = new XElement("user");
                if (userNode.firstName != null)
                {
                    user.SetAttributeValue("first-name", userNode.firstName);
                }
                if (userNode.lastName != null)
                {
                    user.SetAttributeValue("last-name", userNode.lastName);
                }
                if (userNode.age != null)
                {
                    user.SetAttributeValue("age", userNode.age);
                }

                var soldProducts = new XElement("sold-products");
                soldProducts.SetAttributeValue("count", userNode.Products.Count());
                foreach (var productNode in userNode.Products)
                {
                    var product = new XElement("product");
                    if (productNode.productName != null)
                    {
                        product.SetAttributeValue("name", productNode.productName);
                    }
                    if (productNode.price != null)
                    {
                        product.SetAttributeValue("price", productNode.price);
                    }
                    soldProducts.Add(product);
                }   
                user.Add(soldProducts);
                root.Add(user);
            }

            var xmlDoc = new XDocument(root);
            //xmlDoc.Save("../../users-and-product.xml");
        }
    }
}
