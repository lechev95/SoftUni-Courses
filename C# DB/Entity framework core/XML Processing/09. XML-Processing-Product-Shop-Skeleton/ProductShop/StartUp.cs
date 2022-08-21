using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ProductShopContext dbContext = new ProductShopContext();
            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();
            //Console.WriteLine("DB Reset successfully");

            //Import Xml
            //Task 1
            //string xml = File.ReadAllText("../../../Datasets/users.xml");
            //string result = ImportUsers(dbContext, xml);
            //Console.WriteLine(result);

            //Task 2
            //string xml = File.ReadAllText("../../../Datasets/products.xml");
            //string result = ImportProducts(dbContext, xml);
            //Console.WriteLine(result);

            //Task 3
            //string xml = File.ReadAllText("../../../Datasets/categories.xml");
            //string result = ImportCategories(dbContext, xml);
            //Console.WriteLine(result);

            //Task 4
            //string xml = File.ReadAllText("../../../Datasets/categories-products.xml");
            //string result = ImportCategoryProducts(dbContext, xml);
            //Console.WriteLine(result);

            //Export Xml
            //Task 5
            //string result = GetProductsInRange(dbContext);

            //Task6
            //string result = GetSoldProducts(dbContext);

            //Task 7
            //string result = GetCategoriesByProductsCount(dbContext);

            //Task 8
            string result = GetUsersWithProducts(dbContext);
            Console.WriteLine(result);

        }

        //Task 1
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            string rootName = "Users";
            ImportUsersDto[] usersDtos = Deserialize<ImportUsersDto[]>(inputXml, rootName);
            ICollection<User> users = new List<User>();
            foreach (var userDto in usersDtos)
            {
                User user = new User()
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Age = userDto.Age
                };
                users.Add(user);
            }
            context.Users.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {users.Count}";
        }

        //Task 2 On test - merge conflict for FK but 100/100 in judge!
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            string rootName = "Products";
            ImportProductsDto[] productsDtos = Deserialize<ImportProductsDto[]>(inputXml, rootName);
            ICollection<Product> products = new List<Product>();
            foreach (var productDto in productsDtos)
            {
                Product product = new Product()
                {
                    Name = productDto.Name,
                    Price = productDto.Price,
                    SellerId = productDto.SellerId,
                    BuyerId = productDto.BuyerId
                };
                products.Add(product);
            }
            context.Products.AddRange(products);
            context.SaveChanges();
            return $"Successfully imported {products.Count}";
        }

        //Task 3
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            string rootName = "Categories";
            ImportCategoriesDto[] categoriesDtos = Deserialize<ImportCategoriesDto[]>(inputXml, rootName);
            ICollection<Category> categories = new List<Category>();
            foreach (var categoryDto in categoriesDtos)
            {
                //if(!context.Categories.Any(c => c.Name == categoryDto.Name))
                //{
                //    continue;
                //}
                Category category = new Category()
                {
                    Name = categoryDto.Name
                };
                categories.Add(category);
            }
            context.Categories.AddRange(categories);
            context.SaveChanges();
            return $"Successfully imported {categories.Count}";
        }

        //Task 4 On test - merge conflict for FK but 100/100 in judge!
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            string rootName = "CategoryProducts";
            ImportCategoriesProductsDto[] categoriesProductsDtos = 
                Deserialize<ImportCategoriesProductsDto[]>(inputXml, rootName);
            ICollection<CategoryProduct> categoryProducts = new List<CategoryProduct>();
            foreach (var dto in categoriesProductsDtos)
            {
                //if(!context.CategoryProducts.Any(cp => cp.CategoryId == dto.CategoryId
                //|| cp.ProductId == dto.ProductId))
                //{
                //    continue;
                //}
                CategoryProduct categoryProduct = new CategoryProduct()
                {
                    CategoryId = dto.CategoryId,
                    ProductId = dto.ProductId
                };
                categoryProducts.Add(categoryProduct);
            }
            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();
            return $"Successfully imported {categoryProducts.Count}";
        }

        //Task 5 On test false result but 100/100 in judge!
        public static string GetProductsInRange(ProductShopContext context)
        {
            ExportGetProductsInRange[] productsDto = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new ExportGetProductsInRange()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = $"{p.Buyer.FirstName} {p.Buyer.LastName}"
                })
                .Take(10)
                .ToArray();

            return Serialize(productsDto, "Products");
        }

        //Task 6 On test Index out of range but 100/100 in judge!
        public static string GetSoldProducts(ProductShopContext context)
        {
            ExportGetSoldProducts[] soldProducts = context
                .Users
                .Where(p => p.ProductsSold.Count() > 1)
                .OrderBy(p => p.LastName)
                .ThenBy(p => p.LastName)
                .Select(p => new ExportGetSoldProducts()
                {
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    SoldProducts = p.ProductsSold
                        .Select(ps => new ExportGetProductsForUser()
                        {
                            Name = ps.Name,
                            Price = ps.Price
                        })
                        .ToArray()
                })
                .Take(5)
                .ToArray();

            return Serialize(soldProducts, "Users");
                
        }

        //Task 7 On test Sequence contains no elements but 100/100 in judge!
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            ExportGetCategoriesByProductsCount[] productsDtos = context
                .Categories
                .Select(p => new ExportGetCategoriesByProductsCount
                {
                    Name = p.Name,
                    Count = p.CategoryProducts.Count(),
                    AveragePrice = p.CategoryProducts.Average(a => a.Product.Price),
                    TotalRevenue = p.CategoryProducts.Sum(a => a.Product.Price)
                })
                .OrderByDescending(o => o.Count)
                .ThenBy(o => o.TotalRevenue)
                .ToArray();

            return Serialize(productsDtos, "Categories");
        }

        //Task 8
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            ExportGetUsers[] usersDto = context
                .Users
                .Where(u => u.ProductsSold.Count > 1)
                    .OrderByDescending(o => o.ProductsSold)
                    .Select(u => new ExportGetUsers
                    {
                        Users = u.ProductsSold.Select(ss => new ExportGetProductsUser
                        {
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            SoldProducts = u.ProductsSold
                                        .Select(p => new ExportGetProductSold
                                        {
                                            Count = p.Name.Count(),
                                            Products = p.CategoryProducts
                                            .Select(cp => new ExportGetProducts
                                            {
                                                Name = p.Name,
                                                Price = p.Price
                                            })
                                            .OrderBy(o => o.Price)
                                            .ToArray()
                                        })
                                        .ToArray()
                        })
                        .ToArray()

                    })
                    .Take(10)
                    .ToArray();

            return Serialize(usersDto, "Users");


        }

        //Helper to Deserialize Xml - only for imports
        private static T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);
            using StringReader reader = new StringReader(inputXml);
            T dtos = (T)xmlSerializer
                .Deserialize(reader);
            return dtos;
        }

        //Helper to Serialize Xml - only for exports
        private static string Serialize<T>(T dto, string rootName)
        {
            StringBuilder sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);

            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

            xmlSerializer.Serialize(writer, dto, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}