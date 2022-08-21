using AutoMapper;
using AutoMapper.QueryableExtensions;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Category;
using ProductShop.DTOs.CategoryProduct;
using ProductShop.DTOs.Product;
using ProductShop.DTOs.User;
using ProductShop.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile(typeof(ProductShopProfile)));
            ProductShopContext dbContext = new ProductShopContext();

            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            //Console.WriteLine("DB copy was created");
            //Task 1
            //string inputJson = File.ReadAllText("../../../Datasets/users.json");
            //string output = ImportUsers(dbContext, inputJson);

            //Task 2
            //string inputJson = File.ReadAllText("../../../Datasets/products.json");
            //string output = ImportProducts(dbContext, inputJson);

            //Task 3
            //string inputJson = File.ReadAllText("../../../Datasets/categories.json");
            //string output = ImportCategories(dbContext, inputJson);

            //Task 4
            //string inputJson = File.ReadAllText("../../../Datasets/categories-products.json");
            //string output = ImportCategoryProducts(dbContext, inputJson);

            //Task 5
            //string output = GetProductsInRange(dbContext);
            //File.WriteAllText("../../../ExportResults/products-in-range.json", output);

            //Task 6
            //string output = GetSoldProducts(dbContext);
            //File.WriteAllText("../../../ExportResults/users-sold-products.json", output);

            //Task 7
            //string output = GetCategoriesByProductsCount(dbContext);
            //File.WriteAllText("../../../ExportResults/categories-by-products.json", output);

            //Task 8
            string output = GetUsersWithProducts(dbContext);
            File.WriteAllText("../../../ExportResults/users-and-products.json", output);
        }

        //Task 1
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            ImportUserDTO[] userDtos = JsonConvert.DeserializeObject<ImportUserDTO[]>(inputJson);

            ICollection<User> users = new List<User>();
            foreach (ImportUserDTO uDto in userDtos)
            {
                User user = Mapper.Map<User>(uDto);
                users.Add(user);
            }

            context.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        //Task 2
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            ImportProductDTO[] productsDto = JsonConvert.DeserializeObject<ImportProductDTO[]>(inputJson);
            ICollection<Product> products = new List<Product>();

            foreach (ImportProductDTO pDto in productsDto)
            {
                Product product = Mapper.Map<Product>(pDto);
                products.Add(product);
            }

            context.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //Task 3
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            ImportCategoryDTO[] categoriesDto = JsonConvert.DeserializeObject<ImportCategoryDTO[]>(inputJson);
            ICollection<Category> categories = new List<Category>();

            foreach (ImportCategoryDTO categoryDto in categoriesDto)
            {
                Category category = Mapper.Map<Category>(categoryDto);
                if(category.Name != null)
                {
                    categories.Add(category);
                }
            }

            context.AddRange(categories);
            context.SaveChanges();
            return $"Successfully imported {categories.Count}";
        }

        //Task 4
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            ImportCategoryProductDTO[] catProdDto = JsonConvert.DeserializeObject<ImportCategoryProductDTO[]>(inputJson);
            ICollection<CategoryProduct> catProds = new List<CategoryProduct>();

            foreach (ImportCategoryProductDTO catProd in catProdDto)
            {
                CategoryProduct categoryProduct = Mapper.Map<CategoryProduct>(catProd);
                catProds.Add(categoryProduct);
            }

            context.AddRange(catProds);
            context.SaveChanges();

            return $"Successfully imported {catProds.Count}";
        }

        //Task 5
        public static string GetProductsInRange(ProductShopContext context)
        {
            ExportProductsInRangeDTO[] products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .ProjectTo<ExportProductsInRangeDTO>()
                .ToArray();

            string jsonOutput = JsonConvert.SerializeObject(products, Formatting.Indented);
            return jsonOutput;
        }

        //Task 6
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ProjectTo<ExportUsersWithSoldProductsDTO>()
                .ToArray();

            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            return json;
        }

        //Таск 7
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            ExportCategoryByProductCountDTO[] categories = context
                .Categories
                .Where(c => c.CategoryProducts.Any(cp => cp.Product.BuyerId.HasValue))
                .OrderByDescending(c => c.CategoryProducts.Count)
                .ProjectTo<ExportCategoryByProductCountDTO>()   
                .ToArray();


            string json = JsonConvert.SerializeObject(categories, Formatting.Indented);
            return json;
        }

        //Task 8
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            //AutoMapper
            //ExportUsersDTO[] users = context
            //    .Users
            //    .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
            //    .OrderByDescending(u => u.ProductsSold.Count(p => p.BuyerId.HasValue))
            //    .ProjectTo<ExportUsersDTO>()
            //    .ToArray();

            //Manual Mapping
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
                .OrderByDescending(u => u.ProductsSold.Count(p => p.BuyerId.HasValue))
                .Select(u => new ExportUsersDTO()
                {
                     FirstName = u.FirstName,
                     LastName = u.LastName,
                     Age = u.Age,
                     SoldProducts = new ExportSoldProductsForUserDTO()
                     {
                         Products = u.ProductsSold
                         .Where(p => p.BuyerId.HasValue)
                         .Select(p => new ExportSingleProductDTO()
                         {
                             Name = p.Name,
                             Price = p.Price
                         })
                         .ToArray()
                     }
                })
                .ToArray();

            ExportUsersAndProductsDTO serDto = new ExportUsersAndProductsDTO
            {
                 Users = users
            };

            JsonSerializerSettings serializerSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            string json = JsonConvert.SerializeObject(serDto, Formatting.Indented, serializerSettings);
            return json;

        }
    }
}