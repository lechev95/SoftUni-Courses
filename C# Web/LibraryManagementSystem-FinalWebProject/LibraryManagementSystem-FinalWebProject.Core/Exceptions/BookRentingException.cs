namespace LibraryManagementSystem.Core.Exceptions
{
    public class BookRentingException : ApplicationException
    {
        public BookRentingException()
        {

        }

        public BookRentingException(string errorMessage)
            : base(errorMessage)
        {

        }


    }
}
