namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var context = new BookShopContext();
            DbInitializer.ResetDatabase(context);

            //var command = Console.ReadLine();
            //Console.WriteLine(GetBooksByAgeRestriction(context, command));
            //Console.WriteLine(GetGoldenBooks(context));
            //Console.WriteLine(GetBooksByPrice(context));
            //Console.WriteLine(GetBooksNotReleasedIn(context, int.Parse(command)));
            //Console.WriteLine(GetBooksByCategory(context, command));
            //Console.WriteLine(GetBooksReleasedBefore(context, command));
            //Console.WriteLine(GetAuthorNamesEndingIn(context, command));
            //Console.WriteLine(GetBookTitlesContaining(context, command));
            //Console.WriteLine(GetBooksByAuthor(context, command));
            //Console.WriteLine(CountBooks(context, int.Parse(command)));
            //Console.WriteLine(CountCopiesByAuthor(context));
            //Console.WriteLine(GetTotalProfitByCategory(context));
            //Console.WriteLine(GetMostRecentBooks(context));
            //IncreasePrices(context);
            Console.WriteLine(RemoveBooks(context));
        }

        //Task 2
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();

            AgeRestriction ageRestriction;
            bool tryParseSuccess = Enum.TryParse<AgeRestriction>(command, true, out ageRestriction);
            if (!tryParseSuccess)
            {
                return string.Empty;
            }

            var result = context
                .Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToArray();

            foreach (var book in result)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }

        //Task 3
        public static string GetGoldenBooks(BookShopContext context)
        {
            var sb = new StringBuilder();

            var result = context
                .Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            foreach (var b in result)
            {
                sb.AppendLine(b);
            }

            return sb.ToString().TrimEnd();
        }

        //Task 4
        public static string GetBooksByPrice(BookShopContext context)
        {
            var result = context
                .Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    Title = b.Title,
                    Price = b.Price
                })
                .ToArray();

            var sb = new StringBuilder();

            foreach (var book in result)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Task 5
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var result = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, result);
        }

        //Task 6
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var category = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var result = context
                .Books
                .OrderBy(b => b.Title)
                .Where(b => b.BookCategories.Any(c => category
                .Select(x => x
                .ToLower())
                .ToArray()
                .Contains(c.Category.Name.ToLower())))
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, result);
        }

        //Task 7
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime dateTime = new DateTime();
            DateTime.TryParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime);

            var result = context
                .Books
                .Where(b => b.ReleaseDate <= dateTime)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToArray();

            var sb = new StringBuilder();

            foreach (var item in result)
            {
                sb.AppendLine($"{item.Title} - {item.EditionType} - ${item.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Task 8
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var result = context
                .Authors
                .Where(a => a.FirstName.EndsWith(input))
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName
                })
                .ToArray();

            var sb = new StringBuilder();

            foreach (var a in result)
            {
                sb.AppendLine($"{a.FirstName} {a.LastName}");
            }

            return sb.ToString().TrimEnd();
        }

        //Task 9
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var result = context
                .Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, result);
        }

        //Task 10
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var result = context
                .Books
                .Where(a => a.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(a => new
                {
                    a.Title,
                    a.Author.FirstName,
                    a.Author.LastName
                })
                .ToArray();

            var sb = new StringBuilder();

            foreach (var item in result)
            {
                sb.AppendLine($"{item.Title} ({item.FirstName} {item.LastName})");
            }

            return sb.ToString().TrimEnd();
        }

        //Task 11
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var result = context
                .Books
                .Where(b => b.Title.Length > lengthCheck)
                .Select(b => b.Title);

            return result.Count();
        }

        //Task 12
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var result = context
                .Authors
                .Select(b => new
                {
                    Author = b.FirstName + " " + b.LastName,
                    Copies = b.Books.Sum(c => c.Copies)
                })
                .OrderByDescending(b => b.Copies)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var item in result)
            {
                sb.AppendLine($"{item.Author} - {item.Copies}");
            }

            return sb.ToString().TrimEnd();
        }

        //Task 13
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var result = context
                .Categories
                .Select(c => new
                {
                    Category = c.Name,
                    Profit = c.CategoryBooks.Sum(b => b.Book.Price * b.Book.Copies)
                })
                .OrderByDescending(p => p.Profit)
                .ThenBy(c => c.Category)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var item in result)
            {
                sb.AppendLine($"{item.Category} ${item.Profit:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Task 14
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var result = context
                .Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    Category = c.Name,
                    Book = c.CategoryBooks
                    .Select(b => new
                    {
                        Book = b.Book.Title,
                        Date = b.Book.ReleaseDate
                    })
                    .OrderByDescending(b => b.Date)
                    .Take(3)
                    .ToArray()
                })
                .ToArray();

            var sb = new StringBuilder();

            foreach (var item in result)
            {
                sb.AppendLine($"--{item.Category}");

                foreach (var c in item.Book)
                {
                    sb.AppendLine($"{c.Book} ({c.Date.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //Task 15
        public static void IncreasePrices(BookShopContext context)
        {
            var result = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToArray();

            foreach (var book in result)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        //Task 16
        public static int RemoveBooks(BookShopContext context)
        {
            var result = context
                .Books
                .Where(b => b.Copies < 4200)
                .ToArray();

            context.Books.RemoveRange(result);
            context.SaveChanges();

            return result.Length;
        }
    }
}
