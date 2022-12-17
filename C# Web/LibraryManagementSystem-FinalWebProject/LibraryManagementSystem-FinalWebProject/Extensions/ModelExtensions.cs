using LibraryManagementSystem_FinalWebProject.Core.Contracts;
using System.Text;

namespace LibraryManagementSystem_FinalWebProject.Extensions
{
    public static class ModelExtensions
    {
        public static string GetInformation(this IBookModel book)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(book.Title.Replace(" ", "-"));

            return sb.ToString();
        }
    }
}
